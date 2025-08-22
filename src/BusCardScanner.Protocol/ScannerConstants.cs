using System;
using System.Collections.Generic;
using System.Text;

namespace Scanner.Protocol
{
    /// <summary>
    /// Scanner常量
    /// </summary>
    public static class ScannerConstants
    {
        static ScannerConstants()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding = Encoding.GetEncoding("GBK");
        }
        /// <summary>
        /// 日期限制于2000年
        /// </summary>
        public const int DateLimitYear = 2000;
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime UTCBaseTime = new DateTime(1970, 1, 1);
        /// <summary>
        /// 
        /// </summary>
        public static Encoding Encoding { get; }

        /// <summary>
        /// 空的读卡器ID，平台下发消息时使用
        /// </summary>
        public static string EmptyScannerId { get; } = "                ";

        /// <summary>
        /// Scanner_0x0200_0x01
        /// </summary>

        public const byte Scanner_0x0200_0x01 = 0x01;
    }
}
