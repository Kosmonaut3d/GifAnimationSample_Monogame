namespace GifAnimation.Pipeline
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    internal static class Quantizer
    {
        public static unsafe byte[] Quantize(Image source)
        {
            int height = source.Height;
            int width = source.Width;
            Rectangle rect = new Rectangle(0, 0, width, height);
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.PageUnit = GraphicsUnit.Pixel;
                graphics.DrawImageUnscaled(source, rect);
            }
            BitmapData bitmapdata = image.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            int index = 0;
            byte[] buffer = new byte[(source.Width * source.Height) * 4];
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    buffer[index] = numPtr[index];
                    index++;
                    buffer[index] = numPtr[index];
                    index++;
                    buffer[index] = numPtr[index];
                    index++;
                    buffer[index] = numPtr[index];
                    index++;
                }
            }
            image.UnlockBits(bitmapdata);
            return buffer;
        }
    }
}

