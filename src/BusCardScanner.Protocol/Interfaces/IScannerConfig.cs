using Scanner.Protocol.Enums;
using Scanner.Protocol.Formatters;
using Scanner.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Scanner.Protocol
{
    /// <summary>
    /// Scanner接口配置
    /// </summary>
    public interface IScannerConfig
    {
        /// <summary>
        /// 配置ID
        /// </summary>
        string ConfigId { get; }

        /// <summary>
        /// 消息流水号
        /// </summary>
        IScannerMsgSNDistributed MsgSNDistributed { get; set; }

        /// <summary>
        /// 消息工厂
        /// </summary>
        IScannerMsgIdFactory MsgIdFactory { get; set; }

        /// <summary>
        /// 压缩接口
        /// </summary>
        IScannerCompress Compress { get; set; }

        /// <summary>
        /// 序列化器工厂
        /// </summary>
        IScannerFormatterFactory FormatterFactory { get; set; }

        /// <summary>
        /// 统一编码
        /// </summary>
        Encoding Encoding { get; set; }

        /// <summary>
        /// 跳过校验码
        /// 测试的时候需要手动修改值，避免验证
        /// 默认：false
        /// </summary>
        bool SkipCRCCode { get; set; }

        /// <summary>
        /// 全局注册外部程序集
        /// </summary>
        /// <param name="externalAssemblies"></param>
        /// <returns></returns>
        IScannerConfig Register(params Assembly[] externalAssemblies);

        /// <summary>
        /// 替换原有消息
        /// </summary>
        void ReplaceMsgId<TSourceScannerBodies, TTargetScannerBodies>()
            where TSourceScannerBodies : ScannerBodies
            where TTargetScannerBodies : ScannerBodies,new();

    }
}
