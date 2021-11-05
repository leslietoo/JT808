﻿using JT808.Protocol.Extensions.SuBiao.Enums;
using JT808.Protocol.Extensions.SuBiao.MessageBody;
using JT808.Protocol.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JT808.Protocol.Extensions.SuBiao
{
    /// <summary>
    /// 添加苏标-主动安全
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// 添加苏标-主动安全
        /// </summary>
        /// <param name="jT808Builder"></param>
        /// <returns></returns>
        public static IJT808Builder AddSuBiaoConfigure(this IJT808Builder jT808Builder)
        {
            jT808Builder.Config.Register(Assembly.GetExecutingAssembly());
            return jT808Builder;
        }
    }
}
