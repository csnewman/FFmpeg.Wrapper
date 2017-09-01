using System;

namespace FFmpeg.Wrapper
{
    [Flags]
    public enum CodecCapabilities : uint
    {
        DrawHorizBand = (1 << 0),
        Dr1 = (1 << 1),
        Truncated = (1 << 3),
        Delay = (1 << 5),
        SmallLastFrame = (1 << 6),
        HwaccelVdpau = (1 << 7),
        Subframes = (1 << 8),
        Experimental = (1 << 9),
        ChannelConf = (1 << 10),
        FrameThreads = (1 << 12),
        SliceThreads = (1 << 13),
        ParamChange = (1 << 14),
        AutoThreads = (1 << 15),
        VariableFrameSize = (1 << 16),
        IntraOnly = 0x40000000,
        Lossless = 0x80000000
    }
}
