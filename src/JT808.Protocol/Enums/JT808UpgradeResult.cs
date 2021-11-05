using System.ComponentModel;

namespace JT808.Protocol.Enums
{
    /// <summary>
    /// 升级结果
    /// </summary>
    public enum JT808UpgradeResult : byte
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("succeed")]
        成功 = 0x00,

        /// <summary>
        /// 失败
        /// </summary>
        [Description("failed")]
        失败 = 0x01,

        /// <summary>
        /// 取消
        /// </summary>
        [Description("canceled")]
        取消 = 0x02,

        /// 以下为苏标扩展

        /// <summary>
        /// 粤标主动安全-未找到目标设备
        /// </summary>
        [Description("target not found")]
        未找到目标设备 = 0x10,

        /// <summary>
        /// 粤标主动安全-硬件型号不支持
        /// </summary>
        [Description("unsupported hardware model")]
        硬件型号不支持 = 0x11,

        /// <summary>
        /// 粤标主动安全-软件版本相同
        /// </summary>
        [Description("same firmware version")]
        软件版本相同 = 0x12,

        /// <summary>
        /// 粤标主动安全-软件版本不支持
        /// </summary>
        [Description("unsupported firmware version")]
        软件版本不支持 = 0x13,
    }
}
