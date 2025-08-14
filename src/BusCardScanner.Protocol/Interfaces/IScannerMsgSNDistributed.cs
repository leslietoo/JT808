namespace Scanner.Protocol.Interfaces
{
    /// <summary>
    /// Scanner分布式自增流水号
    /// </summary>
    public interface IScannerMsgSNDistributed
    {
        /// <summary>
        /// 根据读卡器ID自增
        /// </summary>
        /// <param name="scannerId"></param>
        /// <returns></returns>
        ushort Increment(string scannerId);
    }
}
