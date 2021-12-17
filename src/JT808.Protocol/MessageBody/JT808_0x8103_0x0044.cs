﻿using System.Text.Json;

using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;

namespace JT808.Protocol.MessageBody
{
    /// <summary>
    /// 接收终端 SMS 文本报警号码
    /// </summary>
    public class JT808_0x8103_0x0044 : JT808_0x8103_BodyBase, IJT808MessagePackFormatter<JT808_0x8103_0x0044>, IJT808Analyze
    {
        /// <summary>
        /// 0x0044
        /// </summary>
        public override uint ParamId { get; set; } = 0x0044;
        /// <summary>
        /// 数据长度
        /// n byte
        /// </summary>
        public override byte ParamLength { get; set; }
        /// <summary>
        /// 接收终端 SMS 文本报警号码
        /// </summary>
        public string ParamValue { get; set; }
        /// <summary>
        /// 接收终端SMS文本报警号码
        /// </summary>
        public override string Description => "接收终端SMS文本报警号码";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8103_0x0044 jT808_0x8103_0x0044 = new JT808_0x8103_0x0044();
            jT808_0x8103_0x0044.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0044.ParamLength = reader.ReadByte();
            var paramValue = reader.ReadVirtualArray(jT808_0x8103_0x0044.ParamLength);
            jT808_0x8103_0x0044.ParamValue = reader.ReadString(jT808_0x8103_0x0044.ParamLength);
            writer.WriteNumber($"[{ jT808_0x8103_0x0044.ParamId.ReadNumber()}]参数ID", jT808_0x8103_0x0044.ParamId);
            writer.WriteNumber($"[{jT808_0x8103_0x0044.ParamLength.ReadNumber()}]参数长度", jT808_0x8103_0x0044.ParamLength);
            writer.WriteString($"[{paramValue.ToArray().ToHexString()}]参数值[接收终端SMS文本报警号码]", jT808_0x8103_0x0044.ParamValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public JT808_0x8103_0x0044 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8103_0x0044 jT808_0x8103_0x0044 = new JT808_0x8103_0x0044();
            jT808_0x8103_0x0044.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0044.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0044.ParamValue = reader.ReadString(jT808_0x8103_0x0044.ParamLength);
            return jT808_0x8103_0x0044;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x8103_0x0044 value, IJT808Config config)
        {
            writer.WriteUInt32(value.ParamId);
            writer.Skip(1, out int skipPosition);
            writer.WriteString(value.ParamValue);
            int length = writer.GetCurrentPosition() - skipPosition - 1;
            writer.WriteByteReturn((byte)length, skipPosition);
        }
    }
}
