using System;
using System.Collections.Generic;

namespace Scanner.Protocol.Interfaces
{
    /// <summary>
    /// Scanner消息工厂接口
    /// </summary>
    public interface IScannerMsgIdFactory:IScannerExternalRegister
    {
        /// <summary>
        /// 
        /// </summary>
        IDictionary<byte, object> Map { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool TryGetValue(byte msgId, out object instance);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TScannerBodies"></typeparam>
        /// <returns></returns>
        IScannerMsgIdFactory SetMap<TScannerBodies>() where TScannerBodies : ScannerBodies;
    }
}
