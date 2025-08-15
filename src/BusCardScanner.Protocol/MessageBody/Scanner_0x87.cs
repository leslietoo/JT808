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
    /// 设置刷卡最小时间间隔
    /// </summary>
    public class Scanner_0x87 : ScannerBodies,IScannerMessagePackFormatter<Scanner_0x87>, IScannerAnalyze
    {
        /// <summary>
        /// 0x87
        /// </summary>
        public override byte MsgId => 0x87;

        /// <summary>
        /// 设置刷卡最小时间间隔
        /// </summary>
        public override string Description => "设置刷卡最小时间间隔";

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
        public Scanner_0x87 Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            Scanner_0x87 scanner_0x87 = new Scanner_0x87();
            scanner_0x87.MinSwipeInterval = reader.ReadUInt16();

            return scanner_0x87;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, Scanner_0x87 value, IScannerConfig config)
        {
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
