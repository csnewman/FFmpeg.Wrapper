using System.Runtime.InteropServices;
using FFmpeg.AutoGen;
using System;

namespace FFmpeg.Wrapper
{
    public unsafe class AvPacket : IDisposable
    {
        public AVPacket* NativeObj;
        private GCHandle? _handle;

        public int StreamIndex => NativeObj->stream_index;

        public AvPacket(AVPacket* nativeObj)
        {
            NativeObj = nativeObj;
        }

        ~AvPacket()
        {
            _handle?.Free();
        }

        public static AvPacket Create()
        {
            AVPacket native = new AVPacket();
            GCHandle handle = GCHandle.Alloc(native, GCHandleType.Pinned);
            return new AvPacket((AVPacket*)handle.AddrOfPinnedObject().ToPointer()) { _handle = handle };
        }

        public void Init()
        {
            ffmpeg.av_init_packet(NativeObj);
        }


        public void Unref()
        {
            ffmpeg.av_packet_unref(NativeObj);
        }

        public void Dispose()
        {
            _handle?.Free();

            _handle = null;
        }
    }
}