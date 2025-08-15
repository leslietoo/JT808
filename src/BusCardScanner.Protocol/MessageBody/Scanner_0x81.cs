using Scanner.Protocol.Enums;
using Scanner.Protocol.MessagePack;
using Scanner.Protocol.Formatters;
using Scanner.Protocol.Interfaces;
using System.Text.Json;
using Scanner.Protocol.Extensions;
using System;
using System.Globalization;

namespace Scanner.Protocol.MessageBody
{
    /// <summary>
    /// 平台通用应答
    /// </summary>
    public class Scanner_0x81 : ScannerBodies,IScannerMessagePackFormatter<Scanner_0x81>, IScannerAnalyze
    {
        /// <summary>
        /// 0x81
        /// </summary>
        public override byte MsgId => 0x81;

        /// <summary>
        /// 平台通用应答
        /// </summary>
        public override string Description => "平台通用应答";

        /// <summary>
        /// 应答流水号
        /// 对应的读卡器消息的流水号
        /// </summary>
        public ushort ReplyMsgNum { get; set; }
        
        /// <summary>
        /// 应答ID
        /// 对应的读卡器消息的ID
        /// <see cref="Scanner.Protocol.Enums.ScannerMsgId"/>
        /// </summary>
        public byte ReplyMsgId { get; set; }

        /// <summary>
        /// 结果
        /// 0：成功/确认；1：失败；2：消息有误；3：不支持
        /// </summary>
        public ScannerPlatformResult PlatformResult { get; set; }

        /// <summary>
        /// 应答错误原因，最多255个字节
        /// </summary>
        public string AckError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public Scanner_0x81 Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            Scanner_0x81 scanner_0x81 = new Scanner_0x81();
            scanner_0x81.ReplyMsgNum = reader.ReadUInt16();
            scanner_0x81.ReplyMsgId = reader.ReadByte();
            scanner_0x81.PlatformResult = (ScannerPlatformResult)reader.ReadByte();

            var ackErrLen = reader.ReadByte();
            if (ackErrLen > 0)
                scanner_0x81.AckError = reader.ReadString(ackErrLen);

            return scanner_0x81;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, Scanner_0x81 value, IScannerConfig config)
        {
            writer.WriteUInt16(value.ReplyMsgNum);
            writer.WriteByte(value.ReplyMsgId);
            writer.WriteByte((byte)value.PlatformResult);

            if (String.IsNullOrEmpty(value.AckError))
            {
                writer.WriteByte(0);
            }
            else
            {
                writer.WriteByte((byte)value.AckError.Length);
                writer.WriteString(value.AckError);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref ScannerMessagePackReader reader, Utf8JsonWriter writer, IScannerConfig config)
        {
            var replyMsgNum = reader.ReadUInt16();
            var replyMsgId = reader.ReadByte();
            var platformResult = reader.ReadByte();
            var ackErrLen = reader.ReadByte();
            string ackError = null;
            
            if (ackErrLen > 0)
                ackError = reader.ReadString(ackErrLen);

            writer.WriteNumber($"[{replyMsgNum.ReadNumber()}]应答流水号", replyMsgNum);
            writer.WriteNumber($"[{replyMsgId.ReadNumber()}]应答消息Id", replyMsgId);
            writer.WriteString($"[{platformResult.ReadNumber()}]结果", ((ScannerPlatformResult)platformResult).ToString());
            writer.WriteNumber($"[{ackErrLen.ReadNumber()}]错误原因字节数", ackErrLen);
            writer.WriteString($"错误原因", ackError);
        }
    }
}
