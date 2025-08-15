using System.ComponentModel;

namespace Scanner.Protocol.Enums
{
    /// <summary>
    /// 升级目标
    /// </summary>
    public enum ScannerUpgradeType : byte
    {
        /// <summary>
        /// 终端
        /// </summary>
        [Description("Scanner")]
        Scanner = 0,
    }
}
