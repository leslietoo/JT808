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
    /// 固件升级
    /// </summary>
    public class Scanner_0x86 : ScannerBodies,IScannerMessagePackFormatter<Scanner_0x86>, IScannerAnalyze
    {
        /// <summary>
        /// 0x86
        /// </summary>
        public override byte MsgId => 0x86;

        /// <summary>
        /// 固件升级
        /// </summary>
        public override string Description => "固件升级";

        /// <summary>
        /// 升级目标部件, 0：读卡器
        /// </summary>
        public ScannerUpgradeType UpgradeType { get; set; }

        /// <summary>
        /// 升级数据包
        /// </summary>
        public byte[] Firmware { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public Scanner_0x86 Deserialize(ref ScannerMessagePackReader reader, IScannerConfig config)
        {
            Scanner_0x86 scanner_0x86 = new Scanner_0x86();
            scanner_0x86.UpgradeType = (ScannerUpgradeType)reader.ReadByte();

            var firmwareLen = reader.ReadInt32();
            if (firmwareLen > 0)
                scanner_0x86.Firmware = reader.ReadArray(firmwareLen).ToArray();

            return scanner_0x86;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref ScannerMessagePackWriter writer, Scanner_0x86 value, IScannerConfig config)
        {
            writer.WriteByte((byte)value.UpgradeType);

            if (value.Firmware == null || value.Firmware.Length == 0)
            {
                writer.WriteInt32(0);
            }
            else
            {
                writer.WriteInt32(value.Firmware.Length);
                writer.WriteArray(value.Firmware);
            }
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
