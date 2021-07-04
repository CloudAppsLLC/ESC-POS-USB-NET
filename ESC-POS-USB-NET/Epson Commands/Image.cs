using System.Collections;
using System;
using System.IO;
using ESC_POS_USB_NET.Interfaces.Command;
using System.Drawing;

namespace ESC_POS_USB_NET.EpsonCommands
{
    public class Image : IImage
    {
        private static BitmapData GetBitmapData(Bitmap bmp)
        {

            var threshold = 127;
            var index = 0;
            double multiplier = 576; // this depends on your printer model.
            double scale = (double)(multiplier / (double)bmp.Width);
            int xheight = (int)(bmp.Height * scale);
            int xwidth = (int)(bmp.Width * scale);
            var dimensions = xwidth * xheight;
            var dots = new BitArray(dimensions);

            for (var y = 0; y < xheight; y++)
            {
                for (var x = 0; x < xwidth; x++)
                {
                    var _x = (int)(x / scale);
                    var _y = (int)(y / scale);
                    var color = bmp.GetPixel(_x, _y);
                    var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    dots[index] = (luminance < threshold);
                    index++;
                }
            }

            return new BitmapData()
            {
                Dots = dots,
                Height = (int)(bmp.Height * scale),
                Width = (int)(bmp.Width * scale)
            };

        }

        private byte[] GetImageHeader(int commandLength)
        {
            byte[] lengths = new byte[4];
            int i = 0;
            while (commandLength > 0)
            {
                lengths[i] = (byte)(commandLength & 0xFF);
                commandLength >>= 8;
                i++;
            }

            if (i >= 3)
            {
                return new byte[] { Cmd.GS, Images.ImageCmd8, Images.ImageCmdL, lengths[0], lengths[1], lengths[2], lengths[3] };
            }
            else
            {
                return new byte[] { Cmd.GS, Images.ImageCmdParen, Images.ImageCmdL, lengths[0], lengths[1] };
            }
        }

        byte[] IImage.Print(byte[] image, int maxWidth = -1, bool isLegacy = false, int color = 1)
        {
            ByteArrayBuilder imageCommand = new ByteArrayBuilder();

            byte colorByte;
            switch (color)
            {
                case 2:
                    colorByte = 0x32;
                    break;
                case 3:
                    colorByte = 0x33;
                    break;
                default:
                    colorByte = 0x31;
                    break;
            }

            int width;
            int height;
            byte[] imageData;
            using (var img = SixLabors.ImageSharp.Image.Load(image))
            {
                imageData = img.ToSingleBitPixelByteArray(maxWidth: maxWidth == -1 ? (int?)null : maxWidth);
                height = img.Height;
                width = img.Width;
            }

            byte heightL = (byte)height;
            byte heightH = (byte)(height >> 8);

            if (isLegacy)
            {
                var byteWidth = (width + 7 & -8) / 8;
                byte widthL = (byte)byteWidth;
                byte widthH = (byte)(byteWidth >> 8);
                imageCommand.Append(new byte[] { Cmd.GS, Images.ImageCmdLegacy, 0x30, 0x00, widthL, widthH, heightL, heightH });
            }
            else
            {
                byte widthL = (byte)width;
                byte widthH = (byte)(width >> 8);
                imageCommand.Append(new byte[] { 0x30, 0x70, 0x30, 0x01, 0x01, colorByte, widthL, widthH, heightL, heightH });
            }

            imageCommand.Append(imageData);

            // Load image to print buffer
            ByteArrayBuilder response = new ByteArrayBuilder();
            byte[] imageCommandBytes = imageCommand.ToArray();
            if (!isLegacy)
            {
                response.Append(GetImageHeader(imageCommandBytes.Length));
            }

            response.Append(imageCommandBytes);
            return response.ToArray();
        }

        public class BitmapData
        {
            public BitArray Dots { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
        }

        public static class Cmd
        {
            public static readonly byte ESC = 0x1B;
            public static readonly byte GS = 0x1D;
        }

        public static class Images
        {
            public static readonly byte ImageCmdParen = 0x28;
            public static readonly byte ImageCmdLegacy = 0x76;
            public static readonly byte ImageCmd8 = 0x38;
            public static readonly byte ImageCmdL = 0x4C;
        }
    }
}

