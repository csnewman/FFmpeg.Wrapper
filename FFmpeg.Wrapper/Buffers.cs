using FFmpeg.AutoGen;

namespace FFmpeg.Wrapper
{
    public unsafe class IntArray
    {
        public int_array8 nativeObj;
        public int this[int id] => nativeObj[(uint)id];

        public IntArray(int_array8 instance)
        {
            nativeObj = instance;
        }

        public int_array8 Native { get; }
    }

    public unsafe class ByteBufferArray
    {
        private readonly byte*[] buffer;

        public ByteBufferArray(byte*[] buffer)
        {
            this.buffer = buffer;
        }

        public byte* this[int i] => buffer[i];

        public byte*[] Native => buffer;
    }
}