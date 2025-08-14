using Scanner.Protocol.MessagePack;
using System;
using System.Text.Json;

namespace Scanner.Protocol.Interfaces
{
    /// <summary>
    /// Scanner上传的指令必须实现此接口
    /// </summary>
    public interface IScannerSendTime
    {
        /// <summary>
        /// 消息发送时间（读卡器本地时间）
        /// </summary>
        DateTime SendTime { get; set; }

        /// <summary>
        /// 消息发送时读卡器时区
        /// </summary>
        byte SendTimeZoneId { get; set; }
    }
}
