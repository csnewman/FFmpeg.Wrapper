using System;
using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class AvBuffer : IDisposable
    {
        private readonly void* pointer;
        private readonly long length;

        public AvBuffer(void* pointer, long length)
        {
            this.pointer = pointer;
            this.length = length;
        }

        public void* Pointer => pointer;

        public static AvBuffer Allocate(long size)
        {
            void* ptr = ffmpeg.av_malloc((ulong)size);

            return new AvBuffer(ptr, size);
        }

        public long Length => length;

        public Span<byte> AsSpan()
        {
            return new Span<byte>(pointer, (int)length);
        }


        public void Free()
        {
            ffmpeg.av_free(pointer);
        }

        public void Dispose()
        {
            // todo: prevent double free
            Free();
        }
    }
}