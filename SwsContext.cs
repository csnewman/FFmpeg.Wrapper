using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class SwsContext
    {
        private AutoGen.SwsContext* _nativeObj;

        public SwsContext(AutoGen.SwsContext* nativeObj)
        {
            _nativeObj = nativeObj;
        }

        public static SwsContext Get(int srcW, int srcH, AvPixelFormat srcFormat, int dstW, int dstH,
            AvPixelFormat dstFormat, SwsFlags flags)
        {
            AutoGen.SwsContext* natObj = ffmpeg.sws_getContext(srcW, srcH, (AVPixelFormat) srcFormat, dstW, dstH,
                (AVPixelFormat) dstFormat,
                (int) flags, null, null, null);
            return natObj == null ? null : new SwsContext(natObj);
        }

        public int Scale(SByteBufferArray src, IntArray srcStride, int srcSliceY, int srcSliceH,
            SByteBufferArray dst, IntArray dstStride)
        {
            return ffmpeg.sws_scale(_nativeObj, src.NativeObj, srcStride.NativeObj, srcSliceY, srcSliceH, dst.NativeObj,
                dstStride.NativeObj);
        }

        public void Free()
        {
            ffmpeg.av_free(_nativeObj);
        }
    }
}