using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class AvPicture
    {
        private AVPicture* _nativeObj;

        public AvPicture(AVPicture* nativeObj)
        {
            _nativeObj = nativeObj;
        }

        public int Fill(SByteBuffer buffer, AvPixelFormat format, int width, int height)
        {
            return ffmpeg.avpicture_fill(_nativeObj, buffer.NativeObj, (AVPixelFormat) format, width, height);
        }

        public static int GetSize(AvPixelFormat format, int width, int height)
        {
            return ffmpeg.avpicture_get_size((AVPixelFormat) format, width, height);
        }
    }
}