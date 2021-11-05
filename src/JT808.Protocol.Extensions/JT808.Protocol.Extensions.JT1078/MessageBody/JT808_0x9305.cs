﻿using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT808.Protocol.Extensions.JT1078.MessageBody
{
    /// <summary>
    /// 红外补光控制
    /// </summary>
    public class JT808_0x9305 : JT808Bodies, IJT808MessagePackFormatter<JT808_0x9305>, IJT808Analyze
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public override string Description => "红外补光控制";
        public override ushort MsgId => 0x9305;
        /// <summary>
        /// 逻辑通道号
        /// </summary>
        public byte ChannelNo { get; set; }
        /// <summary>
        /// 启停标识
        /// </summary>
        public byte StartOrStop  { get; set; }

        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x9305 value = new JT808_0x9305();
            value.ChannelNo = reader.ReadByte();
            writer.WriteString($"[{value.ChannelNo.ReadNumber()}]逻辑通道号", LogicalChannelNoDisplay(value.ChannelNo));
            value.StartOrStop = reader.ReadByte();
            writer.WriteString($"[{value.StartOrStop.ReadNumber()}]启停标识", value.StartOrStop == 0 ? "停止" : "启动");

            static string LogicalChannelNoDisplay(byte LogicalChannelNo)
            {
                return LogicalChannelNo switch
                {
                    1 => "驾驶员",
                    2 => "车辆正前方",
                    3 => "车前门",
                    4 => "车厢前部",
                    5 => "车厢后部",
                    7 => "行李舱",
                    8 => "车辆左侧",
                    9 => "车辆右侧",
                    10 => "车辆正后方",
                    11 => "车厢中部",
                    12 => "车中门",
                    13 => "驾驶席车门",
                    33 => "驾驶员",
                    36 => "车厢前部",
                    37 => "车厢后部",
                    _ => "预留",
                };
            }
        }

        public JT808_0x9305 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            var jT808_0x9305 = new JT808_0x9305();
            jT808_0x9305.ChannelNo = reader.ReadByte();
            jT808_0x9305.StartOrStop = reader.ReadByte();
            return jT808_0x9305;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x9305 value, IJT808Config config)
        {
            writer.WriteByte(value.ChannelNo);
            writer.WriteByte(value.StartOrStop);
        }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
    }
}
