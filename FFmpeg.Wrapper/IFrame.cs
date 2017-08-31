namespace FFmpeg.Wrapper
{
    public interface IFrame
    {
        int Width { get; }

        int Height { get; }

        ByteBufferArray Data { get; }

        AvPixelFormat Format { get; }

        int[] Strides { get; }

        AvBuffer Buffer { get; }
    }
}