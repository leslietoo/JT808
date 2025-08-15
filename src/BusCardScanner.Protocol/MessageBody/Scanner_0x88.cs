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
    /// 读取刷卡最小时间间隔
    /// </summary>
    public class Scanner_0x88 : ScannerBodies,IScannerMessagePackFormatter<Scanner_0x88>, IScannerAnalyze
    {
        /// <summary>
        /// 0x88
        /// </summary>
        public override byte MsgId => 0x88;

        /// <summary>
        /// 读取刷卡最小时间间隔
        /// </summary>
        public override string Description => "读取刷卡最小时间间隔";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public Scanner_0x88 Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            return new Scanner_0x88();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, Scanner_0x88 value, IScannerConfig config)
        {
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
