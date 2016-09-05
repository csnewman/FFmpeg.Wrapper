using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpeg.Wrapper.Examples
{
    class FrameExtractor
    {
        public static void Main(string[] args)
        {
            WrapperUtils.RegisterLibrariesPathSimple("ffmpeg-x64", "ffmpeg-x86");
            AvFormat.RegisterAll();
            AvCodec.RegisterAll();
            AvFormat.NetworkInit();

            AvFormatContext format = AvFormatContext.Allocate();
            if (!format.OpenInput(@"http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4"))
            {
                throw new Exception("Failed to open file :(");
            }
            if (!format.FindStreamInfo())
            {
                throw new Exception("Failed to find stream info :(");
            }

            AvStream pStream = null;
            foreach (AvStream avStream in format.Streams)
            {
                if (avStream.Codec.Type == AvMediaType.Video)
                {
                    pStream = avStream;
                    break;
                }
            }

            if (pStream == null)
            {
                throw new Exception("Could not find video stream :(");
            }

            AvCodecContext codecContext = pStream.Codec;

            int width = codecContext.Width;
            int height = codecContext.Height;
            AvPixelFormat sourceFormat = codecContext.PixelFormat;
            AvPixelFormat targetFormat = AvPixelFormat.Bgr24;

            SwsContext convertContext = SwsContext.Get(width, height, sourceFormat, width, height, targetFormat,
                SwsFlags.FastBilinear);
            if (convertContext == null)
            {
                throw new Exception("Could not initialize the conversion context");
            }

            AvFrame convertedFrame = AvFrame.Allocate();
            int convertedFrameBufferSize = AvPicture.GetSize(targetFormat, width, height);
            SByteBuffer convertedFrameBuffer = AvUtil.Malloc((ulong) convertedFrameBufferSize);
            ((AvPicture) convertedFrame).Fill(convertedFrameBuffer, targetFormat, width, height);

            AvCodec codec = AvCodec.FindDecoder(codecContext.Id);
            if (codec == null)
            {
                throw new Exception("Unsupported codec");
            }

            if (codec.HasCapability(CodecCapabilities.Truncated))
            {
                codecContext.Flags |= CodecFlags.Truncated;
            }

            if (!codecContext.Open2(codec))
            {
                throw new Exception("Could not open codec");
            }

            AvFrame frame = AvFrame.Allocate();

            AvPacket packet = AvPacket.Create();
            packet.Init();

            int frameNumber = 0;
            while (frameNumber < 500)
            {
                if (!format.ReadFrame(packet))
                {
                    throw new Exception("Could not read frame!");
                }

                if (packet.StreamIndex != pStream.Index)
                {
                    continue;
                }

                int gotPicture;
                int size = codecContext.DecodeVideo2(frame, out gotPicture, packet);
                if (size < 0)
                {
                    throw new Exception("Error while decoding frame " + frameNumber);
                }

                if (gotPicture == 1)
                {
                    Console.WriteLine($"Frame: {frameNumber}");

                    SByteBufferArray src = frame.Data;
                    SByteBufferArray dst = convertedFrame.Data;
                    IntArray srcStride = frame.LineSize;
                    IntArray dstStride = convertedFrame.LineSize;
                    convertContext.Scale(src, srcStride, 0, height, dst, dstStride);

                    int linesize = dstStride[0];
                    using (
                        Bitmap bitmap = new Bitmap(width, height, linesize,
                            PixelFormat.Format24bppRgb, convertedFrame.Data0))
                    {
                        bitmap.Save(@"frame.buffer." + frameNumber + ".jpg", ImageFormat.Jpeg);
                    }
                    frameNumber++;
                }
            }

            convertedFrame.Free();
            convertedFrameBuffer.Free();
            convertContext.Free();
            frame.Free();
            codecContext.Close();
            format.CloseInput();
        }
    }
}