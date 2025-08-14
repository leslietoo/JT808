using Scanner.Protocol.MessagePack;
using System;
using System.Text.Json;

namespace Scanner.Protocol.Interfaces
{
    /// <summary>
    /// 带有平台消息流水号的Scanner应答指令实现此接口
    /// </summary>
    public interface IScannerWithReplyMsgNum
    {
        /// <summary>
        /// 平台下发的消息流水号
        /// </summary>
        ushort ReplyMsgNum { get; set; }
    }
}
