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
    /// 设置读卡器密钥
    /// </summary>
    public class Scanner_0x83 : ScannerBodies,IScannerMessagePackFormatter<Scanner_0x83>, IScannerAnalyze
    {
        /// <summary>
        /// 0x83
        /// </summary>
        public override byte MsgId => 0x83;

        /// <summary>
        /// 设置读卡器密钥
        /// </summary>
        public override string Description => "设置读卡器密钥";

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
        public Scanner_0x83 Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            Scanner_0x83 scanner_0x83 = new Scanner_0x83();
            scanner_0x83.AES = reader.ReadArray(16).ToArray();
            scanner_0x83.AppId = reader.ReadUInt32();
            scanner_0x83.FileId = reader.ReadUInt32();

            return scanner_0x83;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, Scanner_0x83 value, IScannerConfig config)
        {
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
