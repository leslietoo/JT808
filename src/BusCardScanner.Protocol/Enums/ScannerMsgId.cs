using Scanner.Protocol.MessageBody;

namespace Scanner.Protocol.Enums
{
    /// <summary>
    /// Scanner消息
    /// </summary>
    public enum ScannerMsgId : byte
    {
        /// <summary>
        /// 读卡器通用应答
        /// 0x01
        /// </summary>
        读卡器通用应答 = 0x01,
        /// <summary>
        /// 平台通用应答
        /// 0x81
        /// </summary>
        平台通用应答 = 0x81,
        /// <summary>
        /// 读卡器启动通知
        /// 0x02
        /// </summary>
        读卡器启动通知 = 0x02,
        /// <summary>
        /// 刷卡事件通知
        /// 0x03
        /// </summary>
        刷卡事件通知 = 0x03,
        /// <summary>
        /// 设置读卡器时间
        /// 0x82
        /// </summary>
        设置读卡器时间 = 0x82,
        /// <summary>
        /// 设置读卡器密钥
        /// 0x83
        /// </summary>
        设置读卡器密钥 = 0x83,
        /// <summary>
        /// 读取读卡器密钥
        /// 0x84
        /// </summary>
        读取读卡器密钥 = 0x84,
        /// <summary>
        /// 读取读卡器密钥应答
        /// 0x04
        /// </summary>
        读取读卡器密钥应答 = 0x04,
        /// <summary>
        /// 读取读卡器工作状态
        /// 0x85
        /// </summary>
        读取读卡器工作状态 = 0x85,
        /// <summary>
        /// 读取读卡器工作状态应答
        /// 0x05
        /// </summary>
        读取读卡器工作状态应答 = 0x05,
        /// <summary>
        /// 固件升级
        /// 0x86
        /// </summary>
        固件升级 = 0x86,
        /// <summary>
        /// 升级结果通知
        /// 0x06
        /// </summary>
        升级结果通知 = 0x06,
        /// <summary>
        /// 设置刷卡最小时间间隔
        /// 0x87
        /// </summary>
        设置刷卡最小时间间隔 = 0x87,
        /// <summary>
        /// 读取刷卡最小时间间隔
        /// 0x88
        /// </summary>
        读取刷卡最小时间间隔 = 0x88,
        /// <summary>
        /// 读取刷卡最小时间间隔应答
        /// 0x08
        /// </summary>
        读取刷卡最小时间间隔应答 = 0x08,
    }
}
