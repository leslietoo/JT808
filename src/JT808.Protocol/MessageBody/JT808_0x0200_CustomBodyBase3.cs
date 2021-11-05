﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.MessageBody
{
    /// <summary>
    /// 自定义位置附加信息
    /// </summary>
    public abstract class JT808_0x0200_CustomBodyBase3
    {
        /// <summary>
        /// 自定义附加信息Id扩展
        /// 两个字节
        /// </summary>
        public abstract ushort AttachInfoId { get; set; }
        /// <summary>
        /// 自定义附加信息长度
        /// 两个字节
        /// </summary>
        public abstract ushort AttachInfoLength { get; set; }
    }
}
