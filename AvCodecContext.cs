using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class AvCodecContext
    {
        private AVCodecContext* _nativeObj;
        public AvCodecId Id => (AvCodecId)_nativeObj->codec_id;
        public AvMediaType Type => (AvMediaType) _nativeObj->codec_type;
        public int Width => _nativeObj->width;
        public int Height => _nativeObj->height;
        public AvPixelFormat PixelFormat => (AvPixelFormat)_nativeObj->pix_fmt;
        public CodecFlags Flags
        {
            get { return (CodecFlags) _nativeObj->flags; }
            set { _nativeObj->flags = (int)value; }
        }

        public AvCodecContext(AVCodecContext* nativeObj)
        {
            _nativeObj = nativeObj;
        }

        public bool Open2(AvCodec codec)
        {
            return ffmpeg.avcodec_open2(_nativeObj, codec.NativeObj, null) == 0;
        }

        public int DecodeVideo2(AvFrame frame, out int picture, AvPacket packet)
        {
            int pictureVal = 0;
            int size = ffmpeg.avcodec_decode_video2(_nativeObj, frame.NativeObj, &pictureVal, packet.NativeObj);
            picture = pictureVal;
            return size;
        }

        public void Close()
        {
            ffmpeg.avcodec_close(_nativeObj);
        }
    }
}
