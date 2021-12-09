using JT808.Protocol.MessagePack;
using System;
using System.Text.Json;

namespace JT808.Protocol.Interfaces
{
    /// <summary>
    /// 带有实时GPS时间的808指令必须实现此接口
    /// </summary>
    public interface IJT808GpsTime
    {
        /// <summary>
        /// 实时GPS时间
        /// </summary>
        DateTime GPSTime { get; set; }
    }
}
