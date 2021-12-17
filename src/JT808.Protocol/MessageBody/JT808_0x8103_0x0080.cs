﻿using System.Text.Json;

using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;
using Newtonsoft.Json;

namespace JT808.Protocol.MessageBody
{
    /// <summary>
    /// 车辆里程表读数，1/10km
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class JT808_0x8103_0x0080 : JT808_0x8103_BodyBase, IJT808MessagePackFormatter<JT808_0x8103_0x0080>, IJT808Analyze
    {
        /// <summary>
        /// 0x0080
        /// </summary>
        public override uint ParamId { get; set; } = 0x0080;
        /// <summary>
        /// 数据长度
        /// 4 byte
        /// </summary>
        public override byte ParamLength { get; set; } = 4;
        /// <summary>
        /// 车辆里程表读数，1/10km
        /// </summary>
        [JsonProperty("milometer")]
        public uint ParamValue { get; set; }
        /// <summary>
        /// 车辆里程表读数
        /// </summary>
        public override string Description => "车辆里程表读数";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8103_0x0080 jT808_0x8103_0x0080 = new JT808_0x8103_0x0080();
            jT808_0x8103_0x0080.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0080.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0080.ParamValue = reader.ReadUInt32();
            writer.WriteNumber($"[{ jT808_0x8103_0x0080.ParamId.ReadNumber()}]参数ID", jT808_0x8103_0x0080.ParamId);
            writer.WriteNumber($"[{jT808_0x8103_0x0080.ParamLength.ReadNumber()}]参数长度", jT808_0x8103_0x0080.ParamLength);
            writer.WriteNumber($"[{ jT808_0x8103_0x0080.ParamValue.ReadNumber()}]参数值[车辆里程表读数1/10km]", jT808_0x8103_0x0080.ParamValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public JT808_0x8103_0x0080 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8103_0x0080 jT808_0x8103_0x0080 = new JT808_0x8103_0x0080();
            jT808_0x8103_0x0080.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0080.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0080.ParamValue = reader.ReadUInt32();
            return jT808_0x8103_0x0080;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x8103_0x0080 value, IJT808Config config)
        {
            writer.WriteUInt32(value.ParamId);
            writer.WriteByte(value.ParamLength);
            writer.WriteUInt32(value.ParamValue);
        }
    }
}
