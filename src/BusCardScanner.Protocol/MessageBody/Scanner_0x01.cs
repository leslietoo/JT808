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
    /// 读卡器通用应答
    /// </summary>
    public class Scanner_0x01 : ScannerBodies,IScannerMessagePackFormatter<Scanner_0x01>, IScannerAnalyze, IScannerWithReplyMsgNum, IScannerSendTime
    {
        /// <summary>
        /// 0x0001
        /// </summary>
        public override byte MsgId => 0x01;

        /// <summary>
        /// 读卡器通用应答
        /// </summary>
        public override string Description => "读卡器通用应答";

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
        /// 应答 ID
        /// 对应的平台消息的 ID
        /// <see cref="Scanner.Protocol.Enums.ScannerMsgId"/>
        /// </summary>
        public byte ReplyMsgId { get; set; }

        /// <summary>
        /// 结果
        /// 0：成功/确认；1：失败；2：消息有误；3：不支持
        /// </summary>
        public ScannerTerminalResult TerminalResult { get; set; }

        /// <summary>
        /// 应答错误原因
        /// </summary>
        public string AckError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public Scanner_0x01 Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            Scanner_0x01 scanner_0X01 = new Scanner_0x01();
            scanner_0X01.SendTime = reader.ReadDateTime_yyMMddHHmmss();
            scanner_0X01.SendTimeZoneId = reader.ReadByte();
            scanner_0X01.ReplyMsgNum = reader.ReadUInt16();
            scanner_0X01.ReplyMsgId = reader.ReadByte();
            scanner_0X01.TerminalResult = (ScannerTerminalResult)reader.ReadByte();

            var ackErrLen = reader.ReadByte();
            if (ackErrLen > 0)
                scanner_0X01.AckError = reader.ReadString(ackErrLen);

            return scanner_0X01;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, Scanner_0x01 value, IScannerConfig config)
        {
            writer.WriteDateTime_yyMMddHHmmss(value.SendTime);
            writer.WriteByte(value.SendTimeZoneId);
            writer.WriteUInt16(value.ReplyMsgNum);
            writer.WriteByte(value.ReplyMsgId);
            writer.WriteByte((byte)value.TerminalResult);

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
            var sendTime = reader.ReadDateTime_yyMMddHHmmss();
            var sendTimeZoneId = reader.ReadByte();
            var replyMsgNum = reader.ReadUInt16();
            var replyMsgId = reader.ReadByte();
            var terminalResult = reader.ReadByte();
            var ackErrLen = reader.ReadByte();
            string ackError = null;
            
            if (ackErrLen > 0)
                ackError = reader.ReadString(ackErrLen);

            writer.WriteString($"发送时间", sendTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
            writer.WriteNumber($"[{sendTimeZoneId.ReadNumber()}]读卡器时区", sendTimeZoneId);
            writer.WriteNumber($"[{replyMsgNum.ReadNumber()}]应答流水号", replyMsgNum);
            writer.WriteNumber($"[{replyMsgId.ReadNumber()}]应答消息Id", replyMsgId);
            writer.WriteString($"[{terminalResult.ReadNumber()}]结果", ((ScannerTerminalResult)terminalResult).ToString());
            writer.WriteNumber($"[{ackErrLen.ReadNumber()}]错误原因字符串长度", ackErrLen);
            writer.WriteString($"错误原因", ackError);
        }
    }
}
