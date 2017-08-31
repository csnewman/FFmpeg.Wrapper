using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class AvCodecContext
    {
        private AVCodecContext* _nativeObj;

        public AvCodecContext(AVCodecContext* nativeObj)
        {
            _nativeObj = nativeObj;
        }

        public AvCodecId Id => (AvCodecId)_nativeObj->codec_id;

        public AvMediaType Type => (AvMediaType)_nativeObj->codec_type;

        public int Width => _nativeObj->width;

        public int Height => _nativeObj->height;

        public AvPixelFormat PixelFormat => (AvPixelFormat)_nativeObj->pix_fmt;

        public CodecFlags Flags
        {
            get => (CodecFlags)_nativeObj->flags;
            set => _nativeObj->flags = (int)value;
        }

        public bool Open2(AvCodec codec)
        {
            return ffmpeg.avcodec_open2(_nativeObj, codec.NativeObj, null) == 0;
        }

        public int SendPacket(AvPacket packet)
        {
            return ffmpeg.avcodec_send_packet(_nativeObj, packet.NativeObj);
        }

        public int RecieveFrame(AvFrame frame)
        {
            return ffmpeg.avcodec_receive_frame(_nativeObj, frame.NativeObject);
        }
        
        public void Close()
        {
            ffmpeg.avcodec_close(_nativeObj);
        }
    }
}
