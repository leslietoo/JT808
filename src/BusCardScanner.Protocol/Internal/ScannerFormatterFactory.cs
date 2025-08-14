
using Scanner.Protocol.Enums;
using Scanner.Protocol.Exceptions;
using Scanner.Protocol.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Scanner.Protocol.Internal
{
   internal class ScannerFormatterFactory : IScannerFormatterFactory
    {
        public IDictionary<Guid, object> FormatterDict { get; }

        public ScannerFormatterFactory()
        {
            FormatterDict = new Dictionary<Guid, object>();
            Init(Assembly.GetExecutingAssembly());
        }

        private void Init(Assembly assembly)
        {
           foreach(var type in assembly.GetTypes().Where(w=>w.GetInterfaces().Contains(typeof(IScannerFormatter))))
           {
                var implTypes = type.GetInterfaces();
                if(implTypes!=null && implTypes .Length>1)
                {
                    var firstType = implTypes.FirstOrDefault(f=>f.Name== typeof(IScannerMessagePackFormatter<>).Name);
                    var genericImplType = firstType.GetGenericArguments().FirstOrDefault();
                    if (genericImplType != null)
                    {
                        if (!FormatterDict.ContainsKey(genericImplType.GUID))
                        {
                            FormatterDict.Add(genericImplType.GUID, Activator.CreateInstance(genericImplType));
                        }
                    }
                }
            }
        }

        public void Register(Assembly externalAssembly)
        {
            Init(externalAssembly);
        }

        public IScannerFormatterFactory SetMap<TIScannerFormatter>() where TIScannerFormatter : IScannerFormatter
        {
            Type type = typeof(TIScannerFormatter);
            if (!FormatterDict.ContainsKey(type.GUID))
            {
                FormatterDict.Add(type.GUID, Activator.CreateInstance(type));
            }
            return this;
        }
    }
}
