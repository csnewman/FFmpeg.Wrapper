using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class AvCodec
    {
        public AVCodec* NativeObj;

        public CodecCapabilities Capabilities
        {
            get { return (CodecCapabilities)NativeObj->capabilities; }
        }

        public AvCodec(AVCodec* nativeObj)
        {
            NativeObj = nativeObj;
        }

        public static AvCodec FindDecoder(AvCodecId id)
        {
            AVCodec* codec = ffmpeg.avcodec_find_decoder((AVCodecID) id);
            return codec == null ? null : new AvCodec(codec);
        }

        public bool HasCapability(CodecCapabilities capability)
        {
            return (Capabilities & capability) == capability;
        }

        public static void RegisterAll()
        {
            ffmpeg.avcodec_register_all();
        }
    }
}