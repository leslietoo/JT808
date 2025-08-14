using Scanner.Protocol.MessagePack;

namespace Scanner.Protocol.Formatters
{
    /// <summary>
    /// 序列化器接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IScannerMessagePackFormatter<T> : IScannerFormatter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        void Serialize(ref ScannerMessagePackWriter writer, T value, IScannerConfig config);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        T Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IScannerFormatter
    {

    }
}
