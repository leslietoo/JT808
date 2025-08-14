using Scanner.Protocol.MessagePack;
using System;
using System.Text.Json;

namespace Scanner.Protocol.Interfaces
{
    /// <summary>
    /// Scanner分析器
    /// </summary>
    public interface IScannerAnalyze
    {
        /// <summary>
        /// 分析器
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        void Analyze(ref ScannerMessagePackReader reader, Utf8JsonWriter writer, IScannerConfig config);
    }
}
