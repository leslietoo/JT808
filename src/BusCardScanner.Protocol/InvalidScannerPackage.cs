using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;

namespace Scanner.Protocol
{
    /// <summary>
    /// 非法的读卡器指令类
    /// </summary>
    public class InvalidScannerPackage
    {
        /// <summary>
        /// 指令内容，0x开头的字符串
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 出错具体描述
        /// </summary>
        public string Error { get; set; }
    }
}
