﻿using System.Text.Json;

using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;

namespace JT808.Protocol.MessageBody
{
    /// <summary>
    /// 车牌颜色，按照 JT/T415-2006 的 5.4.12
    /// </summary>
    public class JT808_0x8103_0x0084 : JT808_0x8103_BodyBase, IJT808MessagePackFormatter<JT808_0x8103_0x0084>, IJT808_2019_Version, IJT808Analyze
    {
        /// <summary>
        /// 0x0084
        /// </summary>
        public override uint ParamId { get; set; } = 0x0084;
        /// <summary>
        /// 数据长度
        /// n byte
        /// </summary>
        public override byte ParamLength { get; set; } = 1;
        /// <summary>
        /// 车牌颜色，按照 JT/T415-2006 的 5.4.12
        /// </summary>
        public byte ParamValue { get; set; }
        /// <summary>
        /// 车牌颜色
        /// </summary>
        public override string Description => "车牌颜色";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8103_0x0084 jT808_0x8103_0x0084 = new JT808_0x8103_0x0084();
            jT808_0x8103_0x0084.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0084.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0084.ParamValue = reader.ReadByte();
            writer.WriteNumber($"[{ jT808_0x8103_0x0084.ParamId.ReadNumber()}]参数ID", jT808_0x8103_0x0084.ParamId);
            writer.WriteNumber($"[{jT808_0x8103_0x0084.ParamLength.ReadNumber()}]参数长度", jT808_0x8103_0x0084.ParamLength);
            writer.WriteNumber($"[{ jT808_0x8103_0x0084.ParamValue.ReadNumber()}]参数值[车牌颜色,按照 JT/T415-2006 的 5.4.12]", jT808_0x8103_0x0084.ParamValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public JT808_0x8103_0x0084 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8103_0x0084 jT808_0x8103_0x0084 = new JT808_0x8103_0x0084();
            jT808_0x8103_0x0084.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0084.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0084.ParamValue = reader.ReadByte();
            return jT808_0x8103_0x0084;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x8103_0x0084 value, IJT808Config config)
        {
            writer.WriteUInt32(value.ParamId);
            writer.WriteByte(value.ParamLength);
            writer.WriteByte(value.ParamValue);
        }
    }
}
