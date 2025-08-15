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
    /// 设置读卡器时间
    /// </summary>
    public class Scanner_0x82 : ScannerBodies,IScannerMessagePackFormatter<Scanner_0x82>, IScannerAnalyze
    {
        /// <summary>
        /// 0x82
        /// </summary>
        public override byte MsgId => 0x82;

        /// <summary>
        /// 设置读卡器时间
        /// </summary>
        public override string Description => "设置读卡器时间";

        /// <summary>
        /// 读卡器时间（读卡器本地时间）
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 读卡器时区
        /// </summary>
        public byte TimeZoneId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public Scanner_0x82 Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            Scanner_0x82 scanner_0x82 = new Scanner_0x82();
            scanner_0x82.Time = reader.ReadDateTime_yyMMddHHmmss();
            scanner_0x82.TimeZoneId = reader.ReadByte();

            return scanner_0x82;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, Scanner_0x82 value, IScannerConfig config)
        {
            writer.WriteDateTime_yyMMddHHmmss(value.Time);
            writer.WriteByte(value.TimeZoneId);
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
