namespace Scanner.Protocol.Interfaces
{
    /// <summary>
    /// 压缩接口
    /// </summary>
    public interface IScannerCompress
    {
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] Compress(byte[] data);
        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="compressData"></param>
        /// <returns></returns>

        byte[] Decompress(byte[] compressData);
    }
}
