using JT808.Protocol.MessagePack;
using System;
using System.Text.Json;

namespace JT808.Protocol.Interfaces
{
    /// <summary>
    /// 带有平台消息流水号的808应答指令实现此接口
    /// </summary>
    public interface IJT808WithReplyMsgNum
    {
        /// <summary>
        /// 平台下发的消息流水号
        /// </summary>
        ushort ReplyMsgNum { get; set; }
    }
}
