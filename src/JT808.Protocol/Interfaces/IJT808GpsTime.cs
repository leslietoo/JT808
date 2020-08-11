using JT808.Protocol.MessagePack;
using System;
using System.Text.Json;

namespace JT808.Protocol.Interfaces
{
    public interface IJT808GpsTime
    {
        DateTime GPSTime { get; set; }
    }
}
