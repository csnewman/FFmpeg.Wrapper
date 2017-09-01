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
