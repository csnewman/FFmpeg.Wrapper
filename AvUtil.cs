using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class AvUtil
    {

        public static VoidBuffer Malloc(ulong size)
        {
            return new VoidBuffer(ffmpeg.av_malloc(size));
        }

    }
}
