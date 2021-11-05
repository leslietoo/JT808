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
    /// 设置状态量配置信息
    /// 返回：状态量配置信息
    /// </summary>
    public class JT808_CarDVR_Up_0x84 : JT808CarDVRUpBodies
    {
        /// <summary>
        /// 0x84
        /// </summary>
        public override byte CommandId =>  JT808CarDVRCommandID.设置状态量配置信息.ToByteValue();
        /// <summary>
        /// 状态量配置信息
        /// </summary>
        public override string Description => "状态量配置信息";
        /// <summary>
        /// 
        /// </summary>
        public override bool SkipSerialization { get; set; } = true;
    }
}
