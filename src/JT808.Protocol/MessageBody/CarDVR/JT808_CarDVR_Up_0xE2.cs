﻿using JT808.Protocol.Enums;
using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT808.Protocol.MessageBody.CarDVR
{
    /// <summary>
    /// 进入脉冲系数误差测量
    /// 返回：通过 DB9 的 7 脚输出车速传感器信号（TTL 电平）
    /// </summary>
    public class JT808_CarDVR_Up_0xE2 : JT808CarDVRUpBodies
    {
        /// <summary>
        /// 0xE2
        /// </summary>
        public override byte CommandId => JT808CarDVRCommandID.进入脉冲系数误差测量.ToByteValue();
        /// <summary>
        /// 通过DB9的7脚输出车速传感器信号（TTL 电平）
        /// </summary>
        public override string Description => "通过 DB9 的 7 脚输出车速传感器信号（TTL 电平）";
        /// <summary>
        /// 
        /// </summary>
        public override bool SkipSerialization { get; set; } = true;
    }
}
