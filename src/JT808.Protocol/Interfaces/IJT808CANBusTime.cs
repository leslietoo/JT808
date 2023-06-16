using JT808.Protocol.MessagePack;
using System;
using System.Text.Json;

namespace JT808.Protocol.Interfaces
{
    /// <summary>
    /// 带有CANBus接收时间的808指令必须实现此接口
    /// </summary>
    public interface IJT808CANBusTime
    {
        /// <summary>
        /// CANBus接收时间（设备本地时间）
        /// </summary>
        DateTime CANBusTime { get; set; }
    }
}
