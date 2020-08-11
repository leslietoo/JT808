using System.ComponentModel;

namespace JT808.Protocol.Enums
{
    /// <summary>
    /// 升级结果
    /// </summary>
    public enum JT808UpgradeResult : byte
    {
        [Description("succeed")]
        成功 = 0,

        [Description("failed")]
        失败 = 1,

        [Description("canceled")]
        取消 = 2,

        /// 以下为苏标扩展

        [Description("target not found")]
        未找到目标设备 = 0x10,

        [Description("unsupported hardware model")]
        硬件型号不支持 = 0x11,

        [Description("same firmware version")]
        软件版本相同 = 0x12,

        [Description("unsupported firmware version")]
        软件版本不支持 = 0x13,
    }
}
