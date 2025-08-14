using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Scanner.Protocol.Interfaces;

namespace Scanner.Protocol.Internal
{
    internal class DefaultMsgSNDistributedImpl : IScannerMsgSNDistributed
    {
        ConcurrentDictionary<string, int> counterDict;
        public DefaultMsgSNDistributedImpl()
        {
            counterDict = new ConcurrentDictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        }
        public ushort Increment(string scannerId)
        {
            return (ushort)counterDict.AddOrUpdate(scannerId, 1, (id, count) => count + 1);
        }
    }
}
