using Scanner.Protocol.Interfaces;
using Scanner.Protocol.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scanner.Protocol
{
    /// <summary>
    /// DI扩展
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// 注册Scanner配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="scannerConfig"></param>
        /// <returns></returns>
        public static IScannerBuilder AddScannerConfigure(this IServiceCollection services, IScannerConfig scannerConfig)
        {
            services.AddSingleton(scannerConfig.GetType(), scannerConfig);
            return new DefaultBuilder(services, scannerConfig);
        }
        /// <summary>
        /// 注册Scanner配置
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="scannerConfig"></param>
        /// <returns></returns>
        public static IScannerBuilder AddScannerConfigure(this IScannerBuilder builder, IScannerConfig scannerConfig)
        {
            builder.Services.AddSingleton(scannerConfig.GetType(), scannerConfig);
            return builder;
        }
        /// <summary>
        /// 注册Scanner配置
        /// </summary>
        /// <typeparam name="TScannerConfig"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IScannerBuilder AddScannerConfigure<TScannerConfig>(this IServiceCollection services)where TScannerConfig : IScannerConfig,new()
        {
            var config = new TScannerConfig();
            services.AddSingleton(typeof(TScannerConfig), config);
            return new DefaultBuilder(services, config);
        }
        /// <summary>
        /// 注册Scanner配置
        /// </summary>
        /// <typeparam name="TScannerConfig"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IScannerBuilder AddScannerConfigure<TScannerConfig>(this IScannerBuilder builder) where TScannerConfig : IScannerConfig, new()
        {
            var config = new TScannerConfig();
            builder.Services.AddSingleton(typeof(TScannerConfig), config);
            return builder;
        }
        /// <summary>
        /// 注册Scanner配置
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IScannerBuilder AddScannerConfigure(this IServiceCollection services)
        {
            DefaultGlobalConfig config = new DefaultGlobalConfig();
            services.AddSingleton<IScannerConfig>(config);
            return new DefaultBuilder(services, config);
        }
    }
}
