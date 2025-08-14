﻿using System.IO;
using System.IO.Compression;
using Scanner.Protocol.Interfaces;

namespace Scanner.Protocol.Internal
{
    internal class ScannerGZipCompressImpl : IScannerCompress
    {
        public byte[] Compress(byte[] data)
        {
            using (var outStream = new MemoryStream())
            {
                using (var gZipStream = new GZipStream(outStream, CompressionMode.Compress))
                using (var mStream = new MemoryStream(data))
                    mStream.CopyTo(gZipStream);
                return outStream.ToArray();
            }
        }

        public byte[] Decompress(byte[] compressData)
        {
            using (var inStream = new MemoryStream(compressData))
            using (var gZipStream = new GZipStream(inStream, CompressionMode.Decompress))
            using (var outStream = new MemoryStream())
            {
                gZipStream.CopyTo(outStream);
                return outStream.ToArray();
            }
        }
    }
}
