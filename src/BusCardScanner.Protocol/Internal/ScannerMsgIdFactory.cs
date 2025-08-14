
using Scanner.Protocol.Enums;
using Scanner.Protocol.Extensions;
using Scanner.Protocol.Formatters;
using Scanner.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Scanner.Protocol.Internal
{
    internal class ScannerMsgIdFactory: IScannerMsgIdFactory
    {
        public IDictionary<byte, object> Map { get; }

        internal ScannerMsgIdFactory()
        {
            Map = new Dictionary<byte, object>();
            InitMap(Assembly.GetExecutingAssembly());
        }

        private void InitMap(Assembly assembly)
        {
            var types = assembly.GetTypes().Where(w => w.BaseType == typeof(ScannerBodies)).ToList();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                byte msgId = 0;
                try
                {
                    msgId = (byte)type.GetProperty(nameof(ScannerBodies.MsgId)).GetValue(instance);
                }
                catch (Exception)
                {
                    continue;
                }
                if (Map.ContainsKey(msgId))
                {
                    throw new ArgumentException($"{type.FullName} {msgId} An element with the same key already exists.");
                }
                else
                {
                    Map.Add(msgId, instance);
                }
            }
        }

        public bool TryGetValue(byte msgId, out object instance)
        {
            return Map.TryGetValue(msgId, out instance);
        }

        public IScannerMsgIdFactory SetMap<TScannerBodies>() where TScannerBodies : ScannerBodies
        {
            Type type = typeof(TScannerBodies);
            var instance = Activator.CreateInstance(type);
            var msgId = (byte)type.GetProperty(nameof(ScannerBodies.MsgId)).GetValue(instance);
            if (Map.ContainsKey(msgId))
            {
                throw new ArgumentException($"{type.FullName} {msgId} An element with the same key already exists.");
            }
            else
            {
                Map.Add(msgId, instance);
            }
            return this;
        }

        public void Register(Assembly externalAssembly)
        {
            InitMap(externalAssembly);
        }
    }
}
