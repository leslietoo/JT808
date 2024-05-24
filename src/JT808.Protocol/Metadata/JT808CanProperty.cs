using JT808.Protocol.Interfaces;

namespace JT808.Protocol.Metadata
{
    /// <summary>
    /// Can属性
    /// </summary>
    public struct JT808CanProperty: IJT808_2019_Version
    {
        /// <summary>
        /// CAN ID
        /// 4
        /// </summary>
        public uint CanId { get; set; }
        /// <summary>
        /// CAN 数据
        /// 8
        /// </summary>
        public byte[] CanData { get; set; }

        /// <summary>
        /// 消息Group
        /// 序列化时忽略此字段
        /// </summary>
        /// <remarks>Added By WuXuehui</remarks>
        public byte MsgGroup { get; set; }

        /// <summary>
        /// 消息ID
        /// 序列化时忽略此字段
        /// </summary>
        /// <remarks>Added By WuXuehui</remarks>
        public byte MsgId { get; set; }

        /// <summary>
        /// CAN数据的含义。解析失败时为空
        /// 序列化时忽略此字段
        /// </summary>
        /// <remarks>Added By WuXuehui</remarks>
        public string Text { get; set; }
    }
}
