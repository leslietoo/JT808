using JT808.Protocol.Extensions.JT1078.Enums;
using JT808.Protocol.Extensions.JT1078.MessageBody;
using JT808.Protocol.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JT808.Protocol.Extensions.JT1078
{
    /// <summary>
    /// 1078扩展808
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// 注册1078扩展808
        /// </summary>
        /// <param name="jT808Builder"></param>
        /// <returns></returns>
        public static IJT808Builder AddJT1078Configure(this IJT808Builder jT808Builder)
        {
            jT808Builder.Config.Register(Assembly.GetExecutingAssembly());
            return jT808Builder;
        }
    }
}
