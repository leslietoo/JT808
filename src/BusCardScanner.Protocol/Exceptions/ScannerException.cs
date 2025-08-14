using Scanner.Protocol.Enums;
using System;

namespace Scanner.Protocol.Exceptions
{
    /// <summary>
    /// Scanner异常处理类
    /// </summary>
    [Serializable]
    public class ScannerException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        public ScannerException(ScannerErrorCode errorCode) : base(errorCode.ToString())
        {
            ErrorCode = errorCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        public ScannerException(ScannerErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="ex"></param>
        public ScannerException(ScannerErrorCode errorCode, Exception ex) : base(ex.Message, ex)
        {
            ErrorCode = errorCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public ScannerException(ScannerErrorCode errorCode, string message, Exception ex) : base(message, ex)
        {
            ErrorCode = errorCode;
        }
        /// <summary>
        /// Scanner统一错误码
        /// </summary>
        public ScannerErrorCode ErrorCode { get; }
    }
}
