using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class AvFrame : IFrame
    {
        private AVFrame* _nativeObj;

        public AvFrame(AVFrame* nativeObj)
        {
            _nativeObj = nativeObj;
        }

        public AVFrame* NativeObject => _nativeObj;

        public int Width => _nativeObj->width;

        public int Height => _nativeObj->height;

        public AvPixelFormat Format => (AvPixelFormat)_nativeObj->format;

        public ByteBufferArray Data => new ByteBufferArray(_nativeObj->data);

        public int[] Strides => new IntArray(_nativeObj->linesize).Native.ToArray();

        public static AvFrame Allocate()
        {
            var nativeFrame = ffmpeg.av_frame_alloc();

            return new AvFrame(nativeFrame);
        }

        public AvBuffer Buffer => new AvBuffer(_nativeObj[0].data[0], 1000000); // buffer.Length); //{ get; set; }

        public void Unref()
        {
            ffmpeg.av_frame_unref(_nativeObj);
        }
    }
}