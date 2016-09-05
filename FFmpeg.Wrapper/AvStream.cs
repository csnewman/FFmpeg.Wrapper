using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class AvStream
    {
        private AVStream* _nativeObj;
        public int Index => _nativeObj->index;
        public AvCodecContext Codec => new AvCodecContext(_nativeObj->codec);
        
        public AvStream(AVStream* nativeObj)
        {
            _nativeObj = nativeObj;
        }

    }
}
