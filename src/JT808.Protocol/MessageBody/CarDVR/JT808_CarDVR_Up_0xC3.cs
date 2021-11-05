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
    /// 设置记录仪脉冲系数
    /// 返回：记录仪脉冲系数
    /// </summary>
    public class JT808_CarDVR_Up_0xC3 : JT808CarDVRUpBodies
    {
        /// <summary>
        /// 0xC3
        /// </summary>
        public override byte CommandId =>  JT808CarDVRCommandID.设置记录仪脉冲系数.ToByteValue();
        /// <summary>
        /// 记录仪脉冲系数
        /// </summary>
        public override string Description => "记录仪脉冲系数";
        /// <summary>
        /// 
        /// </summary>
        public override bool SkipSerialization { get; set; } = true;
    }
}
