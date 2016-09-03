using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class AvFrame
    {
        public AVFrame* NativeObj;
        public IntArray LineSize => new IntArray(NativeObj->linesize);
        public SByteBufferArray Data => new SByteBufferArray(&NativeObj->data0);
        public SByteBuffer Data0 => new SByteBuffer(NativeObj->data0);


        public AvFrame(AVFrame* nativeObj)
        {
            NativeObj = nativeObj;
        }

        public static AvFrame Allocate()
        {
            return new AvFrame(ffmpeg.av_frame_alloc());
        }

        public static implicit operator AvPicture(AvFrame frame)
        {
            return new AvPicture((AVPicture*) frame.NativeObj);
        }

        public void Free()
        {
            ffmpeg.av_free(NativeObj);
        }
    }
}