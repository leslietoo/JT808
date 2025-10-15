using System.ComponentModel;

namespace Scanner.Protocol.Enums
{
    /// <summary>
    /// 升级结果
    /// </summary>
    public enum ScannerUpgradeResult : byte
    {
        /// <summary>
        /// 升级成功
        /// </summary>
        [Description("succeed")]
        Succeed = 0x00,

        /// <summary>
        /// 分包数据有错或升级失败
        /// </summary>
        [Description("failed")]
        Fail = 0x01,

        /// <summary>
        /// 无效的升级包
        /// </summary>
        [Description("invalid firmware")]
        InvalidFirmware = 0x02,

        /// <summary>
        /// 未找到目标设备
        /// </summary>
        [Description("target not found")]
        TargetNotFound = 0x03,

        /// <summary>
        /// 硬件型号不支持
        /// </summary>
        [Description("unsupported hardware model")]
        UnsupportedHardwareModel = 0x04,

        /// <summary>
        /// 软件版本相同
        /// </summary>
        [Description("same firmware version")]
        SameFirmwareVersion = 0x05,

        /// <summary>
        /// 软件版本不支持
        /// </summary>
        [Description("unsupported firmware version")]
        UnsupportedFirmwareVersion = 0x06,

        /// <summary>
        /// 分包数据接收成功
        /// </summary>
        [Description("sub-package received OK")]
        SubPackageReceivedOK = 0x07,
    }
}
