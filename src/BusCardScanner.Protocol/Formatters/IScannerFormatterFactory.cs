using Scanner.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Scanner.Protocol.Formatters
{
    /// <summary>
    /// 序列化工厂
    /// </summary>
    public interface IScannerFormatterFactory: IScannerExternalRegister
    {
        /// <summary>
        /// 
        /// </summary>
        IDictionary<Guid,object> FormatterDict { get;}
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TIScannerFormatter"></typeparam>
        /// <returns></returns>
        IScannerFormatterFactory SetMap<TIScannerFormatter>()
                    where TIScannerFormatter : IScannerFormatter;
    }
}
