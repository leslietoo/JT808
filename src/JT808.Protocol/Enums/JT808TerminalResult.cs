using System.ComponentModel;

namespace JT808.Protocol.Enums
{
    /// <summary>
    /// 通用应答返回
    /// </summary>
    public enum JT808TerminalResult : byte
    {
        /// <summary>
        /// 成功/确认
        /// </summary>
        [Description("succeed")]
        Success = 0x00,

        [Description("failed")]
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 0x01,

        [Description("message error")]
        /// <summary>
        /// 消息有误
        /// </summary>
        MessageError = 0x02,

        [Description("not supported")]
        /// <summary>
        /// 不支持
        /// </summary>
        NotSupport = 0x03
    }
}
