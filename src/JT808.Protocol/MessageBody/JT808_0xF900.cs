using JT808.Protocol.Exceptions;
using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;
using JT808.Protocol.Metadata;
using Scanner.Protocol;
using System.Collections.Generic;
using System.Text.Json;

namespace JT808.Protocol.MessageBody
{
    /// <summary>
    /// 读卡器指令上传
    /// 808规定0xF000~0xFFFF为厂商自定义下行消息
    /// 仅为了编程方便而设计，实际上设备并不会真的发送此类指令
    /// </summary>
    /// <remarks>Added by WuXuehui</remarks>
    public class JT808_0xF900 : JT808Bodies, IJT808MessagePackFormatter<JT808_0xF900>, IJT808Analyze, IJT808_2019_Version
    {
        /// <summary>
        /// 0xF900
        /// </summary>
        public override ushort MsgId { get; } = 0xF900;
        /// <summary>
        /// CAN总线数据上传
        /// </summary>
        public override string Description => "读卡器指令上传";

        /// <summary>
        /// 读卡器指令
        /// </summary>
        public ScannerPackage ScannerInstr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public JT808_0xF900 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref JT808MessagePackWriter writer, JT808_0xF900 value, IJT808Config config)
        {
            throw new System.NotImplementedException();
        }
    }
}
