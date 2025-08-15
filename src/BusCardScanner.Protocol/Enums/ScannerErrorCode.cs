namespace Scanner.Protocol.Enums
{
    /// <summary>
    /// 异常错误码
    /// </summary>
    public enum ScannerErrorCode
    {
        /// <summary>
        /// 校验和不相等
        /// </summary>
        CheckCodeNotEqual = 1001,
        /// <summary>
        /// 消息头解析错误
        /// </summary>
        HeaderParseError = 1002,
        /// <summary>
        /// 消息体解析错误
        /// </summary>
        BodiesParseError = 1003,
        /// <summary>
        /// 长度过长
        /// </summary>
        ExcessiveLength = 1004,
        /// <summary>
        /// 没有实现对应的类型
        /// </summary>
        NotImplType = 1005,
        /// <summary>
        /// 长度不够
        /// </summary>
        NotEnoughLength = 1006,
        /// <summary>
        /// 没有全局注册格式化器
        /// IScannerMessagePackFormatter
        /// </summary>
        NotGlobalRegisterFormatterAssembly = 1007,
        /// <summary>
        /// 时区错误
        /// </summary>
        TimeZoneError = 1008,
        /// <summary>
        /// 时间错误
        /// </summary>
        TimeError = 1009,
    }
}
