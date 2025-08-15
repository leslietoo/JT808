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
    /// 读取刷卡最小时间间隔应答
    /// </summary>
    public class Scanner_0x08 : ScannerBodies,IScannerMessagePackFormatter<Scanner_0x08>, IScannerAnalyze, IScannerWithReplyMsgNum, IScannerSendTime
    {
        /// <summary>
        /// 0x08
        /// </summary>
        public override byte MsgId => 0x08;

        /// <summary>
        /// 读取刷卡最小时间间隔应答
        /// </summary>
        public override string Description => "读取刷卡最小时间间隔应答";

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
        /// 刷卡最小时间间隔，单位毫秒，0表示无时间间隔要求。
        /// </summary>
        public ushort MinSwipeInterval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public Scanner_0x08 Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            Scanner_0x08 scanner_0x08 = new Scanner_0x08();
            scanner_0x08.SendTime = reader.ReadDateTime_yyMMddHHmmss();
            scanner_0x08.SendTimeZoneId = reader.ReadByte();
            scanner_0x08.ReplyMsgNum = reader.ReadUInt16();
            scanner_0x08.MinSwipeInterval = reader.ReadUInt16();

            return scanner_0x08;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, Scanner_0x08 value, IScannerConfig config)
        {
            writer.WriteDateTime_yyMMddHHmmss(value.SendTime);
            writer.WriteByte(value.SendTimeZoneId);
            writer.WriteUInt16(value.ReplyMsgNum);
            writer.WriteUInt16(value.MinSwipeInterval);
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
