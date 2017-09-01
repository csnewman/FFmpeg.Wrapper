using System;

using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class SwsContext : IDisposable
    {
        private readonly AutoGen.SwsContext* _nativeObj;

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


        public int Scale(AvFrame source, int srcSliceY, int srcSliceH, IFrame destination)
        {
            return ffmpeg.sws_scale(
                c         : _nativeObj, 
                srcSlice  : source.NativeObject->data,
                srcStride : source.NativeObject->linesize,
                srcSliceY : srcSliceY, 
                srcSliceH : srcSliceH, 
                dst       : destination.Data.Native,
                dstStride : destination.Strides
            );
        }

        public void Free()
        {
            ffmpeg.av_free(_nativeObj);
        }

        public void Dispose()
        {
            Free();
        }
    }
}