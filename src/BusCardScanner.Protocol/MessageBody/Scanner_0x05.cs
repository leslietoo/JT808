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
    /// 读取读卡器工作状态应答
    /// </summary>
    public class Scanner_0x05 : ScannerBodies,IScannerMessagePackFormatter<Scanner_0x05>, IScannerAnalyze, IScannerWithReplyMsgNum, IScannerSendTime
    {
        /// <summary>
        /// 0x05
        /// </summary>
        public override byte MsgId => 0x05;

        /// <summary>
        /// 读取读卡器工作状态应答
        /// </summary>
        public override string Description => "读取读卡器工作状态应答";

        /// <summary>
        /// 消息发送时间（读卡器本地时间）
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 消息发送时读卡器时区
        /// </summary>
        public byte SendTimeZoneId { get; set; }

        /// <summary>
        /// 应答流水号
        /// 对应的平台消息的流水号
        /// </summary>
        public ushort ReplyMsgNum { get; set; }

        /// <summary>
        /// 还未成功传送到平台的刷卡及二维码的事件记录条数
        /// </summary>
        public uint UnsentEventCount { get; set; }

        /// <summary>
        /// AES-128密钥，16字节。读卡时用来认证，刷二维码时用来解密二维码。注意：该密钥值为事件发生时的密钥，重传时保持不变（即重传时不能改成当前密钥）
        /// </summary>
        public byte[] AES { get; set; }

        /// <summary>
        /// 刷卡最小时间间隔，单位毫秒，0表示无时间间隔要求。
        /// </summary>
        public ushort MinSwipeInterval { get; set; }

        /// <summary>
        /// 固件版本号
        /// </summary>
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public Scanner_0x05 Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            Scanner_0x05 scanner_0x05 = new Scanner_0x05();
            scanner_0x05.SendTime = reader.ReadDateTime_yyMMddHHmmss();
            scanner_0x05.SendTimeZoneId = reader.ReadByte();
            scanner_0x05.ReplyMsgNum = reader.ReadUInt16();
            scanner_0x05.UnsentEventCount = reader.ReadUInt32();
            scanner_0x05.AES = reader.ReadArray(16).ToArray();
            scanner_0x05.MinSwipeInterval = reader.ReadUInt16();

            var firmwareVersionLen = reader.ReadByte();
            if (firmwareVersionLen > 0)
                scanner_0x05.FirmwareVersion = reader.ReadString(firmwareVersionLen);

            return scanner_0x05;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, Scanner_0x05 value, IScannerConfig config)
        {
            writer.WriteDateTime_yyMMddHHmmss(value.SendTime);
            writer.WriteByte(value.SendTimeZoneId);
            writer.WriteUInt16(value.ReplyMsgNum);
            writer.WriteUInt32(value.UnsentEventCount);
            writer.WriteArray(value.AES);
            writer.WriteUInt16(value.MinSwipeInterval);

            if (String.IsNullOrEmpty(value.FirmwareVersion))
            {
                writer.WriteByte(0);
            }
            else
            {
                writer.WriteByte((byte)value.FirmwareVersion.Length);
                writer.WriteString(value.FirmwareVersion);
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
            throw new NotImplementedException("Analyzer is not available yet.");
        }
    }
}
