using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Extensions.SuBiao.Metadata
{
    /// <summary>
    /// 报警标识号
    /// </summary>
    public class AlarmIdentificationProperty
    {
        /// <summary>
        /// 原始值，16个字节
        /// </summary>
        public byte[] RawHex { get; set; }

        /// <summary>
        /// 原始值，用16进制字符串表示的16个字节，形如F1BA83…
        /// </summary>
        public string RawString { get; set; }

        /// <summary>
        /// 终端ID
        /// </summary>
        public string TerminalID { get; set; }
        /// <summary>
        /// YY-MM-DD-hh-mm-ss
        /// BCD[6]
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public byte SN { get; set; }
        /// <summary>
        /// 附件数量
        /// </summary>
        public byte AttachCount { get; set; }
        /// <summary>
        /// 预留
        /// </summary>
        public byte Retain { get; set; }
    }
}
