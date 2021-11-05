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
    /// 采集指定的外部供电记录
    /// 返回：符合条件的供电记录
    /// </summary>
    public class JT808_CarDVR_Down_0x13 : JT808CarDVRDownBodies, IJT808MessagePackFormatter<JT808_CarDVR_Down_0x13>, IJT808Analyze
    {
        /// <summary>
        /// 0x13
        /// </summary>
        public override byte CommandId => JT808CarDVRCommandID.采集指定的外部供电记录.ToByteValue();
        /// <summary>
        /// 符合条件的供电记录
        /// </summary>
        public override string Description => "符合条件的供电记录";
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 最大单位数据块个数
        /// </summary>
        public ushort Count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref JT808MessagePackWriter writer, JT808_CarDVR_Down_0x13 value, IJT808Config config)
        {
            writer.WriteDateTime_yyMMddHHmmss(value.StartTime);
            writer.WriteDateTime_yyMMddHHmmss(value.EndTime);
            writer.WriteUInt16(value.Count);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public JT808_CarDVR_Down_0x13 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_CarDVR_Down_0x13 value = new JT808_CarDVR_Down_0x13();
            value.StartTime = reader.ReadDateTime_yyMMddHHmmss();
            value.EndTime = reader.ReadDateTime_yyMMddHHmmss();
            value.Count = reader.ReadUInt16();
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_CarDVR_Down_0x13 value = new JT808_CarDVR_Down_0x13();
            value.StartTime = reader.ReadDateTime_yyMMddHHmmss();
            writer.WriteString($"[{value.StartTime:yyMMddHHmmss}]开始时间", value.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            value.EndTime = reader.ReadDateTime_yyMMddHHmmss();
            writer.WriteString($"[{value.EndTime:yyMMddHHmmss}]结束时间", value.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            value.Count = reader.ReadUInt16();
            writer.WriteNumber($"[{value.Count.ReadNumber()}]最大单位数据块个数", value.Count);
        }
    }
}
