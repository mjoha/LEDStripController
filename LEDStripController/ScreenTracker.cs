using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDStripController
{
    class ScreenTracker
    {
        public struct Screen
        {

        }

        public const int test = 0;

        /*
          
                 public Color getDominantColor()
        {
            using (Bitmap bmp = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics screenGraph = Graphics.FromImage(bmp))
                {
                    screenGraph.CopyFromScreen(SystemInformation.VirtualScreen.X, SystemInformation.VirtualScreen.Y, 0, 0, SystemInformation.VirtualScreen.Size, CopyPixelOperation.SourceCopy);

                    if (bmp == null)
                    {
                        throw new ArgumentNullException("bmp");
                    }

                    BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
                    int bytesPerPixel = Image.GetPixelFormatSize(srcData.PixelFormat) / 8;

                    int stride = srcData.Stride;

                    IntPtr scan0 = srcData.Scan0;

                    long[] totals = new long[] { 0, 0, 0 };

                    int width = bmp.Width * bytesPerPixel;
                    int height = bmp.Height;

                    unsafe
                    {
                        byte* p = (byte*)(void*)scan0;

                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x += bytesPerPixel)
                            {
                                totals[0] += p[x + 0];
                                totals[1] += p[x + 1];
                                totals[2] += p[x + 2];
                            }

                            p += stride;
                        }
                    }

                    long pixelCount = bmp.Width * height;

                    int avgB = Convert.ToInt32(totals[0] / pixelCount);
                    int avgG = Convert.ToInt32(totals[1] / pixelCount);
                    int avgR = Convert.ToInt32(totals[2] / pixelCount);

                    bmp.UnlockBits(srcData);
                    srcData = null;
                    return Color.FromArgb(avgR, avgG, avgB);
                }
            }
        }
         */
    }
}
