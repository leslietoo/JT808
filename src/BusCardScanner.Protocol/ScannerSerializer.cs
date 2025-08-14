using Scanner.Protocol.Enums;
using Scanner.Protocol.Extensions;
using Scanner.Protocol.Formatters;
using Scanner.Protocol.Interfaces;
using Scanner.Protocol.Internal;
using Scanner.Protocol.MessagePack;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Scanner.Protocol
{
    /// <summary>
    /// Scanner序列化器
    /// </summary>
    public  class ScannerSerializer
    {
        private readonly static ScannerPackage scannerPackage = new ScannerPackage();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scannerConfig"></param>
        public ScannerSerializer(IScannerConfig scannerConfig)
        {
            this.scannerConfig = scannerConfig;
        }
        /// <summary>
        /// 
        /// </summary>
        public ScannerSerializer():this(new DefaultGlobalConfig())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public string SerializerId => scannerConfig.ConfigId;

        private readonly IScannerConfig scannerConfig;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="package"></param>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public byte[] Serialize(ScannerPackage package, int minBufferSize = 4096)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                ScannerMessagePackWriter scannerMessagePackWriter = new ScannerMessagePackWriter(buffer);
                scannerPackage.Serialize(ref scannerMessagePackWriter, package, scannerConfig);
                return scannerMessagePackWriter.FlushAndGetEncodingArray();
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="package"></param>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public ReadOnlySpan<byte> SerializeReadOnlySpan(ScannerPackage package, int minBufferSize = 4096)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                ScannerMessagePackWriter scannerMessagePackWriter = new ScannerMessagePackWriter(buffer);
                scannerPackage.Serialize(ref scannerMessagePackWriter, package, scannerConfig);
                return scannerMessagePackWriter.FlushAndGetEncodingReadOnlySpan();
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public ScannerPackage Deserialize(ReadOnlySpan<byte> bytes, int minBufferSize = 4096)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                ScannerMessagePackReader scannerMessagePackReader = new ScannerMessagePackReader(bytes);
                scannerMessagePackReader.Decode(buffer);
                return scannerPackage.Deserialize(ref scannerMessagePackReader, scannerConfig);
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public byte [] Serialize<T>(T obj, int minBufferSize = 4096)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                var formatter = scannerConfig.GetMessagePackFormatter<T>();
                ScannerMessagePackWriter scannerMessagePackWriter = new ScannerMessagePackWriter(buffer);
                formatter.Serialize(ref scannerMessagePackWriter, obj, scannerConfig);
                return scannerMessagePackWriter.FlushAndGetEncodingArray();
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public ReadOnlySpan<byte> SerializeReadOnlySpan<T>(T obj, int minBufferSize = 4096)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                var formatter = scannerConfig.GetMessagePackFormatter<T>();
                ScannerMessagePackWriter scannerMessagePackWriter = new ScannerMessagePackWriter(buffer);
                formatter.Serialize(ref scannerMessagePackWriter, obj, scannerConfig);
                return scannerMessagePackWriter.FlushAndGetEncodingReadOnlySpan();
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public T Deserialize<T>(ReadOnlySpan<byte> bytes, int minBufferSize = 4096)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                ScannerMessagePackReader scannerMessagePackReader = new ScannerMessagePackReader(bytes);
                if(CheckPackageType(typeof(T)))
                    scannerMessagePackReader.Decode(buffer);
                var formatter = scannerConfig.GetMessagePackFormatter<T>();
                return formatter.Deserialize(ref scannerMessagePackReader, scannerConfig);
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool CheckPackageType(Type type)
        {
            return type == typeof(ScannerPackage) || type == typeof(ScannerHeaderPackage);
        }

        /// <summary>
        /// 用于负载或者分布式的时候，在网关只需要解到头部。
        /// 根据头部的消息Id进行分发处理，可以防止小部分性能损耗。
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public ScannerHeaderPackage HeaderDeserialize(ReadOnlySpan<byte> bytes, int minBufferSize = 4096)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                ScannerMessagePackReader scannerMessagePackReader = new ScannerMessagePackReader(bytes);
                scannerMessagePackReader.Decode(buffer);
                return new ScannerHeaderPackage(ref scannerMessagePackReader,scannerConfig);
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public dynamic Deserialize(ReadOnlySpan<byte> bytes, Type type, int minBufferSize = 4096)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                var formatter = scannerConfig.GetMessagePackFormatterByType(type);
                ScannerMessagePackReader scannerMessagePackReader = new ScannerMessagePackReader(bytes);
                if (CheckPackageType(type))
                    scannerMessagePackReader.Decode(buffer);
                return ScannerMessagePackFormatterResolverExtensions.ScannerDynamicDeserialize(formatter,ref scannerMessagePackReader, scannerConfig);
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="options"></param>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public string Analyze(ReadOnlySpan<byte> bytes, JsonWriterOptions options = default, int minBufferSize = 8096)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                ScannerMessagePackReader scannerMessagePackReader = new ScannerMessagePackReader(bytes);
                scannerMessagePackReader.Decode(buffer);
                using MemoryStream memoryStream = new MemoryStream();
                using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream, options);
                scannerPackage.Analyze(ref scannerMessagePackReader, utf8JsonWriter, scannerConfig);
                utf8JsonWriter.Flush();
                string value = Encoding.UTF8.GetString(memoryStream.ToArray());
                return value;
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }       
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <param name="options"></param>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public string Analyze<T>(ReadOnlySpan<byte> bytes, JsonWriterOptions options = default, int minBufferSize = 8096)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                ScannerMessagePackReader scannerMessagePackReader = new ScannerMessagePackReader(bytes);
                if (CheckPackageType(typeof(T)))
                    scannerMessagePackReader.Decode(buffer);
                var analyze = scannerConfig.GetAnalyze<T>();
                using MemoryStream memoryStream = new MemoryStream();
                using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream, options);
                if (!CheckPackageType(typeof(T))) utf8JsonWriter.WriteStartObject();
                analyze.Analyze(ref scannerMessagePackReader, utf8JsonWriter, scannerConfig);
                if (!CheckPackageType(typeof(T))) utf8JsonWriter.WriteEndObject();
                utf8JsonWriter.Flush();
                string value = Encoding.UTF8.GetString(memoryStream.ToArray());
                return value;
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }

        /// <summary>
        /// 用于分包组合
        /// </summary>
        /// <param name="msgid">对应消息id</param>
        /// <param name="bytes">组合的数据体</param>
        /// <param name="options">序列化选项</param>
        /// <param name="minBufferSize">默认65535</param>
        /// <returns></returns>
        public string Analyze(byte msgid,ReadOnlySpan<byte> bytes, JsonWriterOptions options = default, int minBufferSize = 65535)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                if(scannerConfig.MsgIdFactory.TryGetValue(msgid,out object msgHandle))
                {
                    if (scannerConfig.FormatterFactory.FormatterDict.TryGetValue(msgHandle.GetType().GUID, out object instance))
                    {
                        using MemoryStream memoryStream = new MemoryStream();
                        using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream, options);
                        ScannerMessagePackReader scannerMessagePackReader = new ScannerMessagePackReader(bytes);
                        utf8JsonWriter.WriteStartObject();
                        instance.Analyze(ref scannerMessagePackReader, utf8JsonWriter, scannerConfig);
                        utf8JsonWriter.WriteEndObject();
                        utf8JsonWriter.Flush();
                        string value = Encoding.UTF8.GetString(memoryStream.ToArray());
                        return value;
                    }
                    return $"未找到对应的0x{msgid:X2}消息数据体类型";
                }
                return $"未找到对应的0x{msgid:X2}消息数据体类型";
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }

        /// <summary>
        /// 用于分包组合
        /// </summary>
        /// <param name="msgid">对应消息id</param>
        /// <param name="bytes">组合的数据体</param>
        /// <param name="options">序列化选项</param>
        /// <param name="minBufferSize">默认65535</param>
        /// <returns></returns>
        public byte[] AnalyzeJsonBuffer(byte msgid, ReadOnlySpan<byte> bytes, JsonWriterOptions options = default, int minBufferSize = 65535)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                if (scannerConfig.MsgIdFactory.TryGetValue(msgid, out object msgHandle))
                {
                    if (scannerConfig.FormatterFactory.FormatterDict.TryGetValue(msgHandle.GetType().GUID, out object instance))
                    {
                        using MemoryStream memoryStream = new MemoryStream();
                        using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream, options);
                        ScannerMessagePackReader scannerMessagePackReader = new ScannerMessagePackReader(bytes);
                        utf8JsonWriter.WriteStartObject();
                        instance.Analyze(ref scannerMessagePackReader, utf8JsonWriter, scannerConfig);
                        utf8JsonWriter.WriteEndObject();
                        utf8JsonWriter.Flush();
                        return memoryStream.ToArray();
                    }
                    return Encoding.UTF8.GetBytes($"未找到对应的0x{msgid:X2}消息数据体类型");
                }
                return Encoding.UTF8.GetBytes($"未找到对应的0x{msgid:X2}消息数据体类型");
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="options"></param>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public byte[] AnalyzeJsonBuffer(ReadOnlySpan<byte> bytes, JsonWriterOptions options = default, int minBufferSize = 8096)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                ScannerMessagePackReader scannerMessagePackReader = new ScannerMessagePackReader(bytes);
                scannerMessagePackReader.Decode(buffer);
                using MemoryStream memoryStream = new MemoryStream();
                using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream, options);
                scannerPackage.Analyze(ref scannerMessagePackReader, utf8JsonWriter, scannerConfig);
                utf8JsonWriter.Flush();
                return memoryStream.ToArray();
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <param name="options"></param>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public byte[] AnalyzeJsonBuffer<T>(ReadOnlySpan<byte> bytes, JsonWriterOptions options = default, int minBufferSize = 8096)
        {
            byte[] buffer = ScannerArrayPool.Rent(minBufferSize);
            try
            {
                ScannerMessagePackReader scannerMessagePackReader = new ScannerMessagePackReader(bytes);
                if (CheckPackageType(typeof(T)))
                    scannerMessagePackReader.Decode(buffer);
                var analyze = scannerConfig.GetAnalyze<T>();
                using MemoryStream memoryStream = new MemoryStream();
                using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream, options);
                if (!CheckPackageType(typeof(T))) utf8JsonWriter.WriteStartObject();
                analyze.Analyze(ref scannerMessagePackReader, utf8JsonWriter, scannerConfig);
                if (!CheckPackageType(typeof(T))) utf8JsonWriter.WriteEndObject();
                utf8JsonWriter.Flush();
                return memoryStream.ToArray();
            }
            finally
            {
                ScannerArrayPool.Return(buffer);
            }
        }
    }
}
