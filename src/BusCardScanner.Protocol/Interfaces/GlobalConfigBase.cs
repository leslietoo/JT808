using Scanner.Protocol.Enums;
using Scanner.Protocol.Formatters;
using Scanner.Protocol.Internal;
using Scanner.Protocol.MessageBody;
using System;
using System.Reflection;
using System.Text;

namespace Scanner.Protocol.Interfaces
{
    /// <summary>
    /// 全局配置基类
    /// </summary>
    public abstract class GlobalConfigBase : IScannerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        protected GlobalConfigBase()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            MsgSNDistributed = new DefaultMsgSNDistributedImpl();
            Compress = new ScannerGZipCompressImpl();
            SkipCRCCode = false;
            MsgIdFactory = new ScannerMsgIdFactory();
            Encoding = Encoding.GetEncoding("GBK");
            FormatterFactory = new ScannerFormatterFactory();
        }
        /// <summary>
        /// 配置Id
        /// </summary>
        public abstract string ConfigId { get; protected set; }
        /// <summary>
        /// 分布式消息自增流水号
        /// </summary>
        public virtual IScannerMsgSNDistributed MsgSNDistributed { get; set; }
        /// <summary>
        /// 压缩
        /// </summary>
        public virtual IScannerCompress Compress { get; set; }

        /// <summary>
        /// Scanner消息Id工厂
        /// </summary>
        public virtual IScannerMsgIdFactory MsgIdFactory { get; set; }
        /// <summary>
        /// GBK编码
        /// </summary>
        public virtual Encoding Encoding { get; set; }
        /// <summary>
        /// 跳过校验码验证
        /// 默认false
        /// </summary>
        public virtual bool SkipCRCCode { get; set; }
        /// <summary>
        /// 序列化器工厂
        /// </summary>
        public virtual IScannerFormatterFactory FormatterFactory { get; set; }

        /// <summary>
        /// 外部扩展程序集注册
        /// </summary>
        /// <param name="externalAssemblies"></param>
        /// <returns></returns>
        public virtual IScannerConfig Register(params Assembly[] externalAssemblies)
        {
            if (externalAssemblies != null)
            {
                foreach (var easb in externalAssemblies)
                {
                    MsgIdFactory.Register(easb);
                    FormatterFactory.Register(easb);
                }
            }
            return this;
        }
        /// <summary>
        /// 替换原有消息
        /// </summary>
        /// <typeparam name="TSourceScannerBodies"></typeparam>
        /// <typeparam name="TTargetScannerBodies"></typeparam>
        public void ReplaceMsgId<TSourceScannerBodies, TTargetScannerBodies>()
            where TSourceScannerBodies : ScannerBodies
            where TTargetScannerBodies : ScannerBodies, new()
        {
            TTargetScannerBodies bodies = new TTargetScannerBodies();
            MsgIdFactory.Map[bodies.MsgId] = bodies;
            FormatterFactory.FormatterDict.Remove(typeof(TSourceScannerBodies).GUID);
            FormatterFactory.FormatterDict.Add(typeof(TTargetScannerBodies).GUID, bodies);
        }
    }
}
