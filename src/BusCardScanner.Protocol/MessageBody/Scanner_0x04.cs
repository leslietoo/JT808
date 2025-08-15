using Scanner.Protocol.Enums;
using Scanner.Protocol.MessagePack;
using Scanner.Protocol.Formatters;
using Scanner.Protocol.Interfaces;
using System.Text.Json;
using Scanner.Protocol.Extensions;
using System;
using System.Globalization;

namespace Scanner.Protocol.MessageBody
{
    /// <summary>
    /// 读取读卡器密钥应答
    /// </summary>
    public class Scanner_0x04 : ScannerBodies,IScannerMessagePackFormatter<Scanner_0x04>, IScannerAnalyze, IScannerWithReplyMsgNum, IScannerSendTime
    {
        /// <summary>
        /// 0x04
        /// </summary>
        public override byte MsgId => 0x04;

        /// <summary>
        /// 读取读卡器密钥应答
        /// </summary>
        public override string Description => "读取读卡器密钥应答";

        /// <summary>
        /// 消息发送时间（读卡器本地时间）
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 消息发送时读卡器时区
        /// </summary>
        public byte SendTimeZoneId { get; set; }

        /// <summary>
        /// 应答流水号
        /// 对应的平台消息的流水号
        /// </summary>
        public ushort ReplyMsgNum { get; set; }

        /// <summary>
        /// AES-128密钥，16字节。读卡时用来认证，刷二维码时用来解密二维码。注意：该密钥值为事件发生时的密钥，重传时保持不变（即重传时不能改成当前密钥）
        /// </summary>
        public byte[] AES { get; set; }

        /// <summary>
        /// App ID，读卡时用到的参数
        /// </summary>
        public uint AppId { get; set; }

        /// <summary>
        /// 文件ID，读卡时用到的参数
        /// </summary>
        public uint FileId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public Scanner_0x04 Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            Scanner_0x04 scanner_0x04 = new Scanner_0x04();
            scanner_0x04.SendTime = reader.ReadDateTime_yyMMddHHmmss();
            scanner_0x04.SendTimeZoneId = reader.ReadByte();
            scanner_0x04.ReplyMsgNum = reader.ReadUInt16();
            scanner_0x04.AES = reader.ReadArray(16).ToArray();
            scanner_0x04.AppId = reader.ReadUInt32();
            scanner_0x04.FileId = reader.ReadUInt32();

            return scanner_0x04;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, Scanner_0x04 value, IScannerConfig config)
        {
            writer.WriteDateTime_yyMMddHHmmss(value.SendTime);
            writer.WriteByte(value.SendTimeZoneId);
            writer.WriteUInt16(value.ReplyMsgNum);
            writer.WriteArray(value.AES);
            writer.WriteUInt32(value.AppId);
            writer.WriteUInt32(value.FileId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref ScannerMessagePackReader reader, Utf8JsonWriter writer, IScannerConfig config)
        {
            throw new NotImplementedException("Analyzer is not available yet.");
        }
    }
}
