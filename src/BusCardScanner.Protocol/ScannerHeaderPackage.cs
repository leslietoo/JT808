using Scanner.Protocol.Enums;
using Scanner.Protocol.Exceptions;
using Scanner.Protocol.MessagePack;

namespace Scanner.Protocol
{
    /// <summary>
    /// Scanner头部数据包
    /// </summary>
    public record  ScannerHeaderPackage
    {
        /// <summary>
        /// 起始符
        /// </summary>
        public byte Begin { get; set; }
        /// <summary>
        /// 头数据
        /// </summary>
        public ScannerHeader Header { get;  set; }
        /// <summary>
        /// 数据体
        /// </summary>
        public byte[] Bodies { get; set; }
        /// <summary>
        /// 校验码
        /// 从消息头开始，同后一字节异或，直到校验码前一个字节，占用一个字节。
        /// </summary>
        public byte CheckCode { get; set; }
        /// <summary>
        /// 终止符
        /// </summary>
        public byte End { get; set; }
        /// <summary>
        /// 原数据
        /// </summary>
        public byte[] OriginalData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        public  ScannerHeaderPackage(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            // 1. 验证校验和
            if (!config.SkipCRCCode)
            {
                if (!reader.CheckXorCodeVali)
                {
                    throw new ScannerException(ScannerErrorCode.CheckCodeNotEqual, $"{reader.RealCheckXorCode}!={reader.CalculateCheckXorCode}");
                }
            }
            // ---------------开始解包--------------
            // 2.读取起始位置        
            this.Begin = reader.ReadStart();
            // 3.读取头部信息
            this.Header = new ScannerHeader();
            //  3.1.读取消息Id
            this.Header.MsgId = reader.ReadByte();
            //  3.2.读取消息流水号
            this.Header.MsgNum = reader.ReadUInt16();
            //  3.3.读取协议版本号
            this.Header.ProtocolVersion = reader.ReadByte();
            //  3.4.读取读卡器ID
            this.Header.ScannerId = reader.ReadString(16);
            //  3.5.读取消息体长度
            this.Header.MsgBodyLen = reader.ReadUInt16();
            // 4.处理数据体
            //  4.1.判断有无数据体
            if (this.Header.MsgBodyLen > 0)
            {
                this.Bodies = reader.ReadContent().ToArray();
            }
            else
            {
                this.Bodies = default;
            }
            // 5.读取校验码
            this.CheckCode = reader.ReadByte();
            // 6.读取终止位置
            this.End = reader.ReadEnd();
            // ---------------解包完成--------------
            this.OriginalData = reader.SrcBuffer.ToArray();
        }
    }
}
