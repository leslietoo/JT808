namespace JT808.Protocol.MessageBody
{
    /// <summary>
    /// 苏标的报警附件的数据报文并没有包装在指令内，没有消息ID，这里伪造一个
    /// </summary>
    public class JT808_0x12F0 : JT808Bodies
    {
        /// <summary>
        /// 跳过数据体序列化
        /// </summary>
        public override bool SkipSerialization { get; set; } = true;
        /// <summary>
        /// 0x12F0
        /// </summary>
        public override ushort MsgId { get; } = 0x12F0;
        /// <summary>
        /// 终端心跳
        /// </summary>
        public override string Description => "文件数据上传";
    }
}
