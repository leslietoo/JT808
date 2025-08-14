using Scanner.Protocol.Interfaces;
using Scanner.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Scanner.Protocol.Extensions
{
    /// <summary>
    /// Scanner分析器扩展
    /// </summary>
    public static class ScannerAnalyzeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public static void Analyze(this object instance, ref ScannerMessagePackReader reader, Utf8JsonWriter writer, IScannerConfig config)
        {
            if(instance is IScannerAnalyze analyze)
            {
                analyze.Analyze(ref reader, writer, config);
            }
            else
            {
                throw new NotImplementedException($"Not Implemented {instance.GetType().FullName} {nameof(IScannerAnalyze)}");
            }
        }
    }
}
