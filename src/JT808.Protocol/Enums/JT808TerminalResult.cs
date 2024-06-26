﻿using System.ComponentModel;

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
