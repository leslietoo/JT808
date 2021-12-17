﻿using System.Text.Json;

using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;

namespace JT808.Protocol.MessageBody
{
    /// <summary>
    /// 当月最长通话时间，单位为秒（s），0 为不允许通话，0xFFFFFFFF 为不限制
    /// </summary>
    public class JT808_0x8103_0x0047 : JT808_0x8103_BodyBase, IJT808MessagePackFormatter<JT808_0x8103_0x0047>, IJT808Analyze
    {
        /// <summary>
        /// 0x0047
        /// </summary>
        public override uint ParamId { get; set; } = 0x0047;
        /// <summary>
        /// 数据长度
        /// 4 byte
        /// </summary>
        public override byte ParamLength { get; set; } = 4;
        /// <summary>
        /// 当月最长通话时间，单位为秒（s），0 为不允许通话，0xFFFFFFFF 为不限制
        /// </summary>
        public uint ParamValue { get; set; }
        /// <summary>
        /// 当月最长通话时间
        /// </summary>
        public override string Description => "当月最长通话时间";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8103_0x0047 jT808_0x8103_0x0047 = new JT808_0x8103_0x0047();
            jT808_0x8103_0x0047.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0047.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0047.ParamValue = reader.ReadUInt32();
            writer.WriteNumber($"[{ jT808_0x8103_0x0047.ParamId.ReadNumber()}]参数ID", jT808_0x8103_0x0047.ParamId);
            writer.WriteNumber($"[{jT808_0x8103_0x0047.ParamLength.ReadNumber()}]参数长度", jT808_0x8103_0x0047.ParamLength);
            writer.WriteNumber($"[{ jT808_0x8103_0x0047.ParamValue.ReadNumber()}]参数值[当月最长通话时间s]", jT808_0x8103_0x0047.ParamValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public JT808_0x8103_0x0047 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8103_0x0047 jT808_0x8103_0x0047 = new JT808_0x8103_0x0047();
            jT808_0x8103_0x0047.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0047.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0047.ParamValue = reader.ReadUInt32();
            return jT808_0x8103_0x0047;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x8103_0x0047 value, IJT808Config config)
        {
            writer.WriteUInt32(value.ParamId);
            writer.WriteByte(value.ParamLength);
            writer.WriteUInt32(value.ParamValue);
        }
    }
}
