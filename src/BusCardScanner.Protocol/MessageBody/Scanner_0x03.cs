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
    /// 刷卡事件通知
    /// </summary>
    public class Scanner_0x03 : ScannerBodies,IScannerMessagePackFormatter<Scanner_0x03>, IScannerAnalyze, IScannerSendTime
    {
        /// <summary>
        /// 0x03
        /// </summary>
        public override byte MsgId => 0x03;

        /// <summary>
        /// 刷卡事件通知
        /// </summary>
        public override string Description => "刷卡事件通知";

        /// <summary>
        /// 消息发送时间（读卡器本地时间）
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 消息发送时读卡器时区
        /// </summary>
        public byte SendTimeZoneId { get; set; }

        /// <summary>
        /// 本次发送是第几次重传
        /// 0表示初次发送（即事件发生时实时发送），1表示第一次重传，2表示第二次重传等等。
        /// </summary>
        public ushort ResendCount { get; set; }

        /// <summary>
        /// 每次刷卡或二维码都要生成新的唯一的事件ID
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// 事件发生时间（读卡器本地时间）
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// 消息发送时读卡器时区
        /// </summary>
        public byte EventTimeZoneId { get; set; }

        /// <summary>
        /// 事件源, 0:刷卡；1：刷二维码
        /// </summary>
        public byte EventSource { get; set; }

        /// <summary>
        /// 卡ID/二维码ID, 8字节
        /// </summary>
        public byte[] CardId { get; set; }

        /// <summary>
        /// 验证结果，0：失败；1：通过
        /// </summary>
        public byte Verified { get; set; }

        /// <summary>
        /// 乘客ID, 验证结果为通过是为16字节，否则为空
        /// </summary>
        public string PassengerId { get; set; }

        /// <summary>
        /// 还未成功传送到平台的刷卡及二维码的事件记录条数
        /// </summary>
        public uint UnsentEventCount { get; set; }

        /// <summary>
        /// AES-128密钥，16字节。读卡时用来认证，刷二维码时用来解密二维码。注意：该密钥值为事件发生时的密钥，重传时保持不变（即重传时不能改成当前密钥）
        /// </summary>
        public byte[] AES { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public Scanner_0x03 Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            Scanner_0x03 scanner_0x03 = new Scanner_0x03();
            scanner_0x03.SendTime = reader.ReadDateTime_yyMMddHHmmss();
            scanner_0x03.SendTimeZoneId = reader.ReadByte();
            scanner_0x03.ResendCount = reader.ReadUInt16();
            scanner_0x03.EventId = new Guid(reader.ReadArray(16).ToArray());
            scanner_0x03.EventTime = reader.ReadDateTime_yyMMddHHmmss();
            scanner_0x03.EventTimeZoneId = reader.ReadByte();
            scanner_0x03.EventSource = reader.ReadByte();
            scanner_0x03.CardId = reader.ReadArray(8).ToArray();
            scanner_0x03.Verified = reader.ReadByte();

            if (scanner_0x03.Verified != 0)
                scanner_0x03.PassengerId = reader.ReadString(16);

            scanner_0x03.UnsentEventCount = reader.ReadUInt32();
            scanner_0x03.AES = reader.ReadArray(16).ToArray();

            return scanner_0x03;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, Scanner_0x03 value, IScannerConfig config)
        {
            writer.WriteDateTime_yyMMddHHmmss(value.SendTime);
            writer.WriteByte(value.SendTimeZoneId);
            writer.WriteUInt16(value.ResendCount);
            writer.WriteArray(value.EventId.ToByteArray());
            writer.WriteDateTime_yyMMddHHmmss(value.EventTime);
            writer.WriteByte(value.EventTimeZoneId);
            writer.WriteByte(value.EventSource);
            writer.WriteArray(value.CardId);
            writer.WriteByte(value.Verified);

            if (value.Verified != 0)
                writer.WriteString(value.PassengerId);

            writer.WriteUInt32(value.UnsentEventCount);
            writer.WriteArray(value.AES);
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
