﻿using JT808.Protocol.Enums;
using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT808.Protocol.MessageBody.CarDVR
{
    /// <summary>
    /// 采集记录仪脉冲系数
    /// 返回：实时时间及设定的脉冲系数
    /// </summary>
    public class JT808_CarDVR_Down_0x04 : JT808CarDVRDownBodies
    {
        /// <summary>
        /// 0x04
        /// </summary>
        public override byte CommandId =>  JT808CarDVRCommandID.采集记录仪脉冲系数.ToByteValue();
        /// <summary>
        /// 实时时间及设定的脉冲系数
        /// </summary>
        public override string Description => "实时时间及设定的脉冲系数";
        /// <summary>
        /// 
        /// </summary>
        public override bool SkipSerialization { get; set; } = true;
    }
}
