using System.ComponentModel;

namespace JT808.Protocol.Enums
{
    /// <summary>
    /// 升级类型
    /// </summary>
    public enum JT808UpgradeType : byte
    {
        [Description("Terminal")]
        终端 = 0,

        [Description("IC Card Reader")]
        道路运输证IC卡读卡器 = 0x0C,

        [Description("Beidou module")]
        北斗卫星定位模块 = 0x34,

        /// 以下为苏标扩展

        [Description("ADAS")]
        高级驾驶辅助系统 = 0x64,

        [Description("DSM")]
        驾驶状态监控系统 = 0x65,

        [Description("TPMS")]
        胎压监测系统 = 0x66,

        [Description("BSD")]
        盲点监测系统 = 0x67,
    }
}
