using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class AvFormatContext
    {
        private AVFormatContext* _nativeObj;
        public uint StreamCount => _nativeObj->nb_streams;

        public IList<AvStream> Streams
        {
            get
            {
                IList<AvStream> streams = new List<AvStream>();

                for (int i = 0; i < _nativeObj->nb_streams; i++)
                {
                    streams.Add(new AvStream(_nativeObj->streams[i]));
                }

                return streams;
            }
        }

        public AvFormatContext(AVFormatContext* nativeObj)
        {
            _nativeObj = nativeObj;
        }

        public static AvFormatContext Allocate()
        {
            return new AvFormatContext(ffmpeg.avformat_alloc_context());
        }

        public bool OpenInput(string url)
        {
            fixed (AVFormatContext** pointer = &_nativeObj)
            {
                return ffmpeg.avformat_open_input(pointer, url, null, null) == 0;
            }
        }

        public bool FindStreamInfo()
        {
            return ffmpeg.avformat_find_stream_info(_nativeObj, null) == 0;
        }

        public AvStream GetStream(int i)
        {
            return new AvStream(_nativeObj->streams[i]);
        }

        public bool ReadFrame(AvPacket packet)
        {
            return ffmpeg.av_read_frame(_nativeObj, packet.NativeObj) == 0;
        }

        public void CloseInput()
        {
            fixed (AVFormatContext** pointer = &_nativeObj)
            {
                ffmpeg.avformat_close_input(pointer);
            }
        }
    }
}