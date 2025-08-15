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
    /// 升级结果通知
    /// </summary>
    public class Scanner_0x06 : ScannerBodies,IScannerMessagePackFormatter<Scanner_0x06>, IScannerAnalyze, IScannerWithReplyMsgNum, IScannerSendTime
    {
        /// <summary>
        /// 0x06
        /// </summary>
        public override byte MsgId => 0x06;

        /// <summary>
        /// 升级结果通知
        /// </summary>
        public override string Description => "升级结果通知";

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
        /// 升级结果:
        /// 0x00：成功
        /// 0x01：失败
        /// 0x02：无效的升级包
        /// 0x03：未找到目标部件
        /// 0x04：硬件型号不支持
        /// 0x05：软件版本相同
        /// 0x06：软件版本不支持
        /// </summary>
        public ScannerUpgradeResult UpgradeResult { get; set; }

        /// <summary>
        /// 升级结果详细信息，最多255个字节
        /// </summary>
        public string UpgradeDetail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public Scanner_0x06 Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            Scanner_0x06 scanner_0x06 = new Scanner_0x06();
            scanner_0x06.SendTime = reader.ReadDateTime_yyMMddHHmmss();
            scanner_0x06.SendTimeZoneId = reader.ReadByte();
            scanner_0x06.ReplyMsgNum = reader.ReadUInt16();
            scanner_0x06.UpgradeResult = (ScannerUpgradeResult)reader.ReadByte();

            var upgradeDetailLen = reader.ReadByte();
            if (upgradeDetailLen > 0)
                scanner_0x06.UpgradeDetail = reader.ReadString(upgradeDetailLen);

            return scanner_0x06;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, Scanner_0x06 value, IScannerConfig config)
        {
            writer.WriteDateTime_yyMMddHHmmss(value.SendTime);
            writer.WriteByte(value.SendTimeZoneId);
            writer.WriteUInt16(value.ReplyMsgNum);
            writer.WriteByte((byte)value.UpgradeResult);

            if (String.IsNullOrEmpty(value.UpgradeDetail))
            {
                writer.WriteByte(0);
            }
            else
            {
                writer.WriteByte((byte)value.UpgradeDetail.Length);
                writer.WriteString(value.UpgradeDetail);
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
