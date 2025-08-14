using Scanner.Protocol.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scanner.Protocol.Internal
{
    /// <summary>
    /// 默认Scanner构造器
    /// </summary>
    class DefaultBuilder : IScannerBuilder
    {
        /// <summary>
        /// DI服务
        /// </summary>
        public IServiceCollection Services { get; }
        /// <summary>
        /// Scanner配置
        /// </summary>
        public IScannerConfig Config { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public DefaultBuilder(IServiceCollection services, IScannerConfig config)
        {
            Services = services;
            Config = config;
        }
    }
}
