using Scanner.Protocol.Enums;
using Scanner.Protocol.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Scanner.Protocol.Extensions
{
    /// <summary>
    /// 验证长度扩展方法
    /// </summary>
    public static partial class ScannerValidationExtensions
    {
        /// <summary>
        /// 验证字符串长度
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <param name="fixedLength"></param>
        public static string ValiString(this string value,in string fieldName, in int fixedLength)
        {
            vali(value.Length, fieldName, fixedLength);
            return value;
        }

        /// <summary>
        /// 验证字符串最大长度
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <param name="maxLength"></param>
        public static string ValiMaxString(this string value, in string fieldName, in int maxLength)
        {
            if (value.Length > maxLength)
            {
                throw new ScannerException(ScannerErrorCode.ExcessiveLength, $"{fieldName}:{value.Length}>max length[{maxLength}]");
            }
            return value;
        }

        /// <summary>
        /// 验证数组长度
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <param name="fixedLength"></param>
        public static byte[] ValiBytes(this byte[] value,in string fieldName, in int fixedLength)
        {
            vali(value.Length, fieldName, fixedLength);
            return value;
        }


        /// <summary>
        /// 验证集合长度
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <param name="fixedLength"></param>
        public static IEnumerable<T> ValiList<T>(this IEnumerable<T> value, in string fieldName, in int fixedLength)
        {
            vali(value.Count(), fieldName, fixedLength);
            return value;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="length"></param>
        /// <param name="fieldName"></param>
        /// <param name="fixedLength"></param>
        private static void vali(in int length,in string fieldName, in int fixedLength)
        {
            if (length > fixedLength)
            {
                throw new ScannerException(ScannerErrorCode.ExcessiveLength, $"{fieldName}:{length}>fixed[{fixedLength}]");
            }
            else if (length < fixedLength)
            {
                throw new ScannerException(ScannerErrorCode.NotEnoughLength, $"{fieldName}:{length}<fixed[{fixedLength}]");
            }
        }
    }
}
