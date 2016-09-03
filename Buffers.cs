using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{

    public unsafe class VoidBuffer
    {
        public void* NativeObj;

        public VoidBuffer(void* buffer)
        {
            NativeObj = buffer;
        }

        public static implicit operator SByteBuffer(VoidBuffer source)
        {
            return new SByteBuffer((sbyte*) source.NativeObj);
        }
    }

    public unsafe class IntArray
    {
        public int* NativeObj;
        public int this[int id] => NativeObj[id];

        public IntArray(int* buffer)
        {
            NativeObj = buffer;
        }

    }

    public unsafe class SByteBuffer
    {
        public sbyte* NativeObj;

        public SByteBuffer(sbyte* buffer)
        {
            NativeObj = buffer;
        }

        public static implicit operator IntPtr(SByteBuffer frame)
        {
            return new IntPtr(frame.NativeObj);
        }

        public void Free()
        {
            ffmpeg.av_free(NativeObj);
        }
    }

    public unsafe class SByteBufferArray
    {
        public sbyte** NativeObj;

        public SByteBufferArray(sbyte** buffer)
        {
            NativeObj = buffer;
        }
    }
}