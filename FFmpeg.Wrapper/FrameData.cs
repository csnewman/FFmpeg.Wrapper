using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class FrameData : IFrame
    {
        private readonly AvBuffer buffer;
        private readonly byte_ptrArray4 dstData;
        private readonly int_array4 dstLinesize;

        public FrameData(AvPixelFormat format, int width, int height)
        {
            Width = width;
            Height = height;
            Format = format;

            var bufferSize = GetSize(format, width, height, 1);

            buffer = AvBuffer.Allocate(bufferSize);

            dstData = new byte_ptrArray4();
            dstLinesize = new int_array4();

            unsafe
            {
                ffmpeg.av_image_fill_arrays(ref dstData, ref dstLinesize, (byte*)buffer.Pointer, (AVPixelFormat)format, width, height, 1);
            }
        }

        public int Width { get; }

        public int Height { get; }

        public AvPixelFormat Format { get; }

        public int[] Strides => dstLinesize;

        public AvBuffer Buffer => buffer;

        public ByteBufferArray Data => new ByteBufferArray(dstData.ToArray());

        public static int GetSize(AvPixelFormat pixelFormat, int width, int height, int align = 1)
        {
            return ffmpeg.av_image_get_buffer_size((AVPixelFormat)pixelFormat, width, height, align);
        }

        public void Dipose()
        {
            buffer.Dispose();
        }
    }
}
