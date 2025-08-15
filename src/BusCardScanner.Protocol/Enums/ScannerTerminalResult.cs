using System.ComponentModel;

namespace Scanner.Protocol.Enums
{
    /// <summary>
    /// 通用应答返回
    /// </summary>
    public enum ScannerTerminalResult : byte
    {
        /// <summary>
        /// 成功/确认
        /// </summary>
        [Description("succeed")]
        Succeed = 0x00,

        /// <summary>
        /// 失败
        /// </summary>
        [Description("failed")]
        Fail = 0x01,

        /// <summary>
        /// 消息有误
        /// </summary>
        [Description("message error")]
        MessageError = 0x02,

        /// <summary>
        /// 不支持
        /// </summary>
        [Description("not supported")]
        NotSupport = 0x03
    }
}
