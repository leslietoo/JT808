using Scanner.Protocol.Formatters;
using Scanner.Protocol.MessagePack;

namespace Scanner.Protocol
{
    /// <summary>
    /// 头部
    /// </summary>
    public class ScannerHeader : IScannerMessagePackFormatter<ScannerHeader>
    {
        /// <summary>
        /// 消息ID 
        /// <see cref="Scanner.Protocol.Enums.ScannerMsgId"/>
        /// </summary>
        public byte MsgId { get; set; }

        /// <summary>
        /// 消息流水号
        /// 发送计数器
        /// 占用两个字节，为发送信息的序列号，用于接收方检测是否有信息的丢失。
        /// 程序开始运行时等于零，发送第一帧数据时开始计数，到最大数后自动归零
        /// </summary>
        public ushort MsgNum { get;  set; }

        /// <summary>
        /// 手动消息流水号（only test）
        /// 发送计数器
        /// 占用两个字节，为发送信息的序列号，用于接收方检测是否有信息的丢失。
        /// 程序开始运行时等于零，发送第一帧数据时开始计数，到最大数后自动归零
        /// </summary>
        public ushort? ManualMsgNum { get; set; }

        /// <summary>
        /// 协议版本号
        /// </summary>
        public byte ProtocolVersion { get; set; }

        /// <summary>
        /// 读卡器ID，有且仅有16个字节
        /// </summary>
        public string ScannerId { get; set; }

        /// <summary>
        /// 消息体长度
        /// </summary>
        public uint MsgBodyLen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public ScannerHeader Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            ScannerHeader scannerHeader = new ScannerHeader();
            scannerHeader.MsgId = reader.ReadByte();           // 消息ID
            scannerHeader.MsgNum = reader.ReadUInt16();        // 消息流水号
            scannerHeader.ProtocolVersion = reader.ReadByte(); // 协议版本号
            scannerHeader.ScannerId = reader.ReadString(16);   // 读卡器ID
            scannerHeader.MsgBodyLen = reader.ReadUInt32();    // 消息体长度

            return scannerHeader;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, ScannerHeader value, IScannerConfig config)
        {
            writer.WriteByte(value.MsgId);           // 消息ID                                            
            writer.WriteUInt16(value.MsgNum);        // 消息流水号
            writer.WriteByte(value.ProtocolVersion); // 协议版本号
            writer.WriteString(value.ScannerId);     // 读卡器ID
            writer.WriteUInt32(value.MsgBodyLen);    // 消息体长度
        }
    }
}
