using System;
using System.Runtime.InteropServices;
using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class AvUtil
    {
        [DllImport("avutil-55", EntryPoint = "av_version_info", CallingConvention = CallingConvention.Cdecl)]
        private static extern char* av_version_info();

        public static uint Version => ffmpeg.avutil_version();

        public static string VersionInfo => Marshal.PtrToStringAnsi((IntPtr) av_version_info());
    }
}