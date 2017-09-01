using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class AvFormat
    {
        public static void RegisterAll()
        {
            ffmpeg.av_register_all();
        }

        public static void NetworkInit()
        {
            ffmpeg.avformat_network_init();
        }
    }
}
