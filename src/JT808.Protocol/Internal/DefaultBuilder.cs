﻿using JT808.Protocol.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Internal
{
    /// <summary>
    /// 默认JT808构造器
    /// </summary>
    class DefaultBuilder : IJT808Builder
    {
        /// <summary>
        /// DI服务
        /// </summary>
        public IServiceCollection Services { get; }
        /// <summary>
        /// JT808配置
        /// </summary>
        public IJT808Config Config { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public DefaultBuilder(IServiceCollection services, IJT808Config config)
        {
            Services = services;
            Config = config;
        }
    }
}
