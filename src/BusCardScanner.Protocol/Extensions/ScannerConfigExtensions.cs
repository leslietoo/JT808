using Scanner.Protocol.Enums;
using Scanner.Protocol.Exceptions;
using Scanner.Protocol.Formatters;
using Scanner.Protocol.Interfaces;
using System;
using System.Collections.Concurrent;

namespace Scanner.Protocol
{
    /// <summary>
    /// Scanner配置扩展
    /// </summary>
    public static class ScannerConfigExtensions
    {
        private readonly static ConcurrentDictionary<string, ScannerSerializer> scannerSerializerDict = new ConcurrentDictionary<string, ScannerSerializer>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// 通过类型获取对应的消息序列化器
        /// </summary>
        /// <param name="scannerConfig"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object GetMessagePackFormatterByType(this IScannerConfig scannerConfig,Type type)
        {
            if (!scannerConfig.FormatterFactory.FormatterDict.TryGetValue(type.GUID, out var formatter))
            {
                throw new ScannerException(ScannerErrorCode.NotGlobalRegisterFormatterAssembly, type.FullName);
            }
            return formatter;
        }
        /// <summary>
        /// 通过类型获取对应的消息分析器
        /// </summary>
        /// <param name="scannerConfig"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object GetAnalyzeByType(this IScannerConfig scannerConfig, Type type)
        {
            if (!scannerConfig.FormatterFactory.FormatterDict.TryGetValue(type.GUID, out var analyze))
            {
                throw new ScannerException(ScannerErrorCode.NotGlobalRegisterFormatterAssembly, type.FullName);
            }
            return analyze;
        }
        /// <summary>
        /// 获取对应的消息序列化器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scannerConfig"></param>
        /// <returns></returns>
        public static IScannerMessagePackFormatter<T> GetMessagePackFormatter<T>(this IScannerConfig scannerConfig)
        {
            return (IScannerMessagePackFormatter<T>)GetMessagePackFormatterByType(scannerConfig,typeof(T));
        }
        /// <summary>
        /// 获取对应的消息分析器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scannerConfig"></param>
        /// <returns></returns>
        public static IScannerAnalyze GetAnalyze<T>(this IScannerConfig scannerConfig)
        {
            return (IScannerAnalyze)GetAnalyzeByType(scannerConfig, typeof(T));
        }
        /// <summary>
        /// 获取Scanner序列化器
        /// </summary>
        /// <param name="scannerConfig"></param>
        /// <returns></returns>
        public static ScannerSerializer GetSerializer(this IScannerConfig scannerConfig)
        {
            if(!scannerSerializerDict.TryGetValue(scannerConfig.ConfigId,out var serializer))
            {
                serializer = new ScannerSerializer(scannerConfig);
                scannerSerializerDict.TryAdd(scannerConfig.ConfigId, serializer);
            }
            return serializer;
        }
    }
}
