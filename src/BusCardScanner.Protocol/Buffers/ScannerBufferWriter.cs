﻿using System;

namespace Scanner.Protocol.Buffers
{
    /// <summary>
    /// 
    /// ref System.Buffers.Writer
    /// </summary>
    ref partial struct ScannerBufferWriter
    {
        private Span<byte> _buffer;
        public ScannerBufferWriter(Span<byte> buffer)
        {
            _buffer = buffer;
            WrittenCount = 0;
            BeforeCodingWrittenPosition = 0;
        }
        public Span<byte> Free => _buffer.Slice(WrittenCount);
        public Span<byte> Written => _buffer.Slice(0, WrittenCount);
        /// <summary>
        /// 编码之前的写入位置
        /// </summary>
        public int BeforeCodingWrittenPosition { get;internal set; }
        public int WrittenCount { get; private set; }
        public void Advance(int count)
        {
            WrittenCount += count;
        }
    }
}
