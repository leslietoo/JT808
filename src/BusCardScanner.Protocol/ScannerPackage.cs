using Scanner.Protocol.Enums;
using Scanner.Protocol.Exceptions;
using Scanner.Protocol.Extensions;
using Scanner.Protocol.Formatters;
using Scanner.Protocol.Interfaces;
using Scanner.Protocol.MessagePack;
using System;
using System.Text.Json;

namespace Scanner.Protocol
{
    /// <summary>
    /// Scanner数据包
    /// </summary>
    public class ScannerPackage : IScannerMessagePackFormatter<ScannerPackage>, IScannerAnalyze
    {
        /// <summary>
        /// 起始符
        /// </summary>
        public const byte BeginFlag = 0xD0;

        /// <summary>
        /// 终止符
        /// </summary>
        public const byte EndFlag = 0xD1;

        /// <summary>
        /// 起始符
        /// </summary>
        public byte Begin { get; set; } = BeginFlag;

        /// <summary>
        /// 头数据
        /// </summary>
        public ScannerHeader Header { get; set; }

        /// <summary>
        /// 数据体
        /// </summary>
        public ScannerBodies Bodies { get; set; }

        /// <summary>
        /// 校验码
        /// 从消息头开始，同后一字节异或，直到校验码前一个字节，占用一个字节。
        /// </summary>
        public byte CheckCode { get; set; }

        /// <summary>
        /// 终止符
        /// </summary>
        public byte End { get; set; } = EndFlag;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public ScannerPackage Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            // 1. 验证校验和
            if (!config.SkipCRCCode)
            {
                if (!reader.CheckXorCodeVali)
                {
                    throw new ScannerException(ScannerErrorCode.CheckCodeNotEqual, $"{reader.RealCheckXorCode}!={reader.CalculateCheckXorCode}");
                }
            }
            ScannerPackage scannerPackage = new ScannerPackage();
            // ---------------开始解包--------------
            // 2.读取起始位置
            scannerPackage.Begin = reader.ReadStart();
            // 3.读取头部信息
            scannerPackage.Header = new ScannerHeader();
            //  3.1.读取消息Id
            scannerPackage.Header.MsgId = reader.ReadByte();
            //  3.2.读取消息流水号
            scannerPackage.Header.MsgNum = reader.ReadUInt16();
            //  3.3.读取协议版本号
            scannerPackage.Header.ProtocolVersion = reader.ReadByte();
            //  3.4.读取读卡器ID
            scannerPackage.Header.ScannerId = reader.ReadString(16);
            //  3.5.读取消息体长度
            scannerPackage.Header.MsgBodyLen = reader.ReadUInt32();
            // 4.处理数据体
            //  4.1.判断有无数据体
            if (scannerPackage.Header.MsgBodyLen > 0)
            {
                if (config.MsgIdFactory.TryGetValue(scannerPackage.Header.MsgId, out object instance))
                {
                    try
                    {
                        //4.2.处理消息体
                        scannerPackage.Bodies = ScannerMessagePackFormatterResolverExtensions.ScannerDynamicDeserialize(
                            instance, ref reader, config);
                        scannerPackage.Bodies.ScannerId = scannerPackage.Header.ScannerId;
                    }
                    catch (Exception ex)
                    {
                        throw new ScannerException(ScannerErrorCode.BodiesParseError, ex);
                    }
                }
            }
            // 5.读取校验码
            scannerPackage.CheckCode = reader.ReadByte();
            // 6.读取终止位置
            scannerPackage.End = reader.ReadEnd();
            // ---------------解包完成--------------
            return scannerPackage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, ScannerPackage value, IScannerConfig config)
        {
            // ---------------开始组包--------------
            // 1.起始符
            writer.WriteStart();
            // 2.写入头部 //部分有带数据体的长度，那么先跳过写入头部部分
            //  2.1.消息ID
            writer.WriteByte(value.Header.MsgId);
            //  2.2 消息流水号
            if (value.Header.ManualMsgNum.HasValue)
            {
                writer.WriteUInt16(value.Header.ManualMsgNum.Value);
            }
            else
            {
                value.Header.MsgNum = config.MsgSNDistributed.Increment(value.Header.ScannerId);
                writer.WriteUInt16(value.Header.MsgNum);
            }
            //  2.3 协议版本号
            writer.WriteByte(value.Header.ProtocolVersion);
            //  2.4 读卡器ID
            writer.WriteString(value.Header.ScannerId);
            //  2.5 消息体长度（消息体需要序列化后才能确定长度所以先跳过）
            writer.Skip(4, out int msgBodyLenPosition);

            int headerLength = writer.GetCurrentPosition();
            // 3.处理数据体部分
            if (value.Bodies != null)
            {
                if (!value.Bodies.SkipSerialization)
                {
                    ScannerMessagePackFormatterResolverExtensions.ScannerDynamicSerialize(value.Bodies,
                        ref writer, value.Bodies, config);
                }
            }
            //  3.1.处理数据体长度
            value.Header.MsgBodyLen = (uint)(writer.GetCurrentPosition() - headerLength);
            // 2.2.回写消息体属性
            writer.WriteUInt32Return(value.Header.MsgBodyLen, msgBodyLenPosition);
            // 4.校验码
            writer.WriteXor();
            // 5.终止符
            writer.WriteEnd();
            // 6.编码
            writer.WriteEncode();
            // ---------------组包结束--------------
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref ScannerMessagePackReader reader, Utf8JsonWriter writer, IScannerConfig config)
        {
            // ---------------开始解析对象--------------
            writer.WriteStartObject();
            // 1. 验证校验和
            if (!reader.CheckXorCodeVali)
            {
                writer.WriteString("检验和错误", $"{reader.RealCheckXorCode}!={reader.CalculateCheckXorCode}");
            }
            // 2.读取起始位置
            byte start = reader.ReadEnd();
            writer.WriteNumber($"[{start.ReadNumber()}]开始", start);
            // 3.读取头部信息
            //  3.1.读取消息Id
            var msgid = reader.ReadByte();
            writer.WriteNumber($"[{msgid.ReadNumber()}]消息Id", msgid);
            //  3.2.读取消息流水号
            var msgNum = reader.ReadUInt16();
            writer.WriteNumber($"[{msgNum.ReadNumber()}]消息流水号", msgNum);
            //  3.3.读取协议版本号
            var protocolVersion = reader.ReadByte();
            writer.WriteNumber($"[{protocolVersion.ReadNumber()}]协议版本号", protocolVersion);
            //  3.4.读取读卡器ID
            var scannerId = reader.ReadString(16);
            writer.WriteString($"读卡器ID", scannerId);
            //  3.5.读取消息体长度
            var msgBodyLen = reader.ReadUInt16();
            writer.WriteNumber($"[{msgBodyLen.ReadNumber()}]消息体长度", msgBodyLen);

            // 4.处理数据体
            //  4.1.判断有无数据体
            if (msgBodyLen > 0)
            {
                //数据体属性对象 开始
                writer.WriteStartObject("数据体对象");
                string description = "数据体";

                if (config.MsgIdFactory.TryGetValue(msgid, out object instance))
                {
                    if (instance is IScannerDescription scannerDescription)
                    {
                        //4.2.处理消息体
                        description = scannerDescription.Description;
                    }

                    try
                    {
                        //数据体长度正常
                        writer.WriteString($"{description}", reader.ReadVirtualArray(reader.ReadCurrentRemainContentLength()).ToArray().ToHexString());
                        if (instance is IScannerAnalyze analyze)
                        {
                            //4.2.处理消息体
                            analyze.Analyze(ref reader, writer, config);
                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        writer.WriteString($"数据体解析异常,无可用数据体进行解析", ex.StackTrace);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        writer.WriteString($"数据体解析异常,无可用数据体进行解析", ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteString($"数据体异常", ex.StackTrace);
                    }
                }
                else
                {
                    writer.WriteString($"[未知]数据体", reader.ReadArray(reader.ReadCurrentRemainContentLength()).ToArray().ToHexString());
                }

                //数据体属性对象 结束
                writer.WriteEndObject();
            }
            else
            {
                if (config.MsgIdFactory.TryGetValue(msgid, out object instance))
                {
                    //数据体属性对象 开始
                    writer.WriteStartObject("数据体对象");
                    string description = "[Null]数据体";
                    if (instance is IScannerDescription scannerDescription)
                    {
                        //4.2.处理消息体
                        description = scannerDescription.Description;
                    }
                    writer.WriteNull(description);
                    //数据体属性对象 结束
                    writer.WriteEndObject();
                }
                else
                {
                    writer.WriteNull($"[Null]数据体");
                }
            }

            try
            {
                // 5.读取校验码
                reader.ReadByte();
                writer.WriteNumber($"[{reader.RealCheckXorCode.ReadNumber()}]校验码", reader.RealCheckXorCode);
                // 6.读取终止位置
                byte end = reader.ReadEnd();
                writer.WriteNumber($"[{end.ReadNumber()}]结束", end);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                writer.WriteString($"数据解析异常,无可用数据进行解析", ex.StackTrace);
            }
            catch (Exception ex)
            {
                writer.WriteString($"数据解析异常", ex.StackTrace);
            }
            finally
            {
                writer.WriteEndObject();
            }
        }
    }
}
