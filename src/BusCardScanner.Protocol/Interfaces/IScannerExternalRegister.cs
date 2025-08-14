using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Scanner.Protocol.Interfaces
{
    /// <summary>
    /// 外部注册
    /// </summary>
    public interface IScannerExternalRegister
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="externalAssembly"></param>
        void Register(Assembly externalAssembly);
    }
}
