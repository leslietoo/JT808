﻿using System.Text.Json;

using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;
using Newtonsoft.Json;

namespace JT808.Protocol.MessageBody
{
    /// <summary>
    /// 缺省时间汇报间隔，单位为秒（s），>0
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class JT808_0x8103_0x0029 : JT808_0x8103_BodyBase, IJT808MessagePackFormatter<JT808_0x8103_0x0029>, IJT808Analyze
    {
        /// <summary>
        /// 0x0029
        /// </summary>
        public override uint ParamId { get; set; } = 0x0029;
        /// <summary>
        /// 数据长度
        /// 4 byte
        /// </summary>
        public override byte ParamLength { get; set; } = 4;
        /// <summary>
        /// 缺省时间汇报间隔，单位为秒（s），>0
        /// </summary>
        [JsonProperty("defaultGpsIntvl")]
        public uint ParamValue { get; set; }
        /// <summary>
        /// 缺省时间汇报间隔
        /// </summary>
        public override string Description => "缺省时间汇报间隔";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8103_0x0029 jT808_0x8103_0x0029 = new JT808_0x8103_0x0029();
            jT808_0x8103_0x0029.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0029.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0029.ParamValue = reader.ReadUInt32();
            writer.WriteNumber($"[{ jT808_0x8103_0x0029.ParamId.ReadNumber()}]参数ID", jT808_0x8103_0x0029.ParamId);
            writer.WriteNumber($"[{jT808_0x8103_0x0029.ParamLength.ReadNumber()}]参数长度", jT808_0x8103_0x0029.ParamLength);
            writer.WriteNumber($"[{ jT808_0x8103_0x0029.ParamValue.ReadNumber()}]参数值[缺省时间汇报间隔s]", jT808_0x8103_0x0029.ParamValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public JT808_0x8103_0x0029 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8103_0x0029 jT808_0x8103_0x0029 = new JT808_0x8103_0x0029();
            jT808_0x8103_0x0029.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0029.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0029.ParamValue = reader.ReadUInt32();
            return jT808_0x8103_0x0029;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x8103_0x0029 value, IJT808Config config)
        {
            writer.WriteUInt32(value.ParamId);
            writer.WriteByte(value.ParamLength);
            writer.WriteUInt32(value.ParamValue);
        }
    }
}
