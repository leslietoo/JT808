using Scanner.Protocol.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scanner.Protocol
{
    /// <summary>
    /// Scanner构造器
    /// </summary>
    public interface IScannerBuilder
    {
        /// <summary>
        /// Scanner配置
        /// </summary>
        IScannerConfig Config { get; }
        /// <summary>
        /// 服务注册
        /// </summary>
        IServiceCollection Services { get; }
    }
}
