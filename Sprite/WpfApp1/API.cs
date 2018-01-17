using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    class API
    {
        /// <summary>
        /// <see cref="System.Drawing.Bitmap"/> convert to <see cref="System.Windows.Media.Imaging.BitmapImage"/>    
        /// </summary>
        /// <param name="bitmap">System.Drawing.Bitmap</param>
        /// <returns></returns>
        public static BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bmpColor"></param>
        /// <param name="bmpGray"></param>
        /// <returns></returns>
        public static Bitmap GetGrayOverlay(Bitmap bmpColor, Bitmap bmpGray)
        {
            Size s1 = bmpColor.Size;
            Size s2 = bmpGray.Size;
            if (s1 != s2) return null;

            Bitmap bmpResult = new Bitmap(s1.Width, s1.Height);

            for (int y = 0; y < s1.Height; y++)
                for (int x = 0; x < s1.Width; x++)
                {
                    Color c1 = bmpColor.GetPixel(x, y);
                    Color c2 = bmpGray.GetPixel(x, y);
                    bmpResult.SetPixel(x, y, Color.FromArgb((int)(255 * c2.GetBrightness()), c1));
                }
            return bmpResult;
        }


        /// <summary>
        /// mix a bitmap(no alpha channel) and its alpha channel to a new bitmap(have alpha channel)
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="alphaChannel"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://stackoverflow.com/questions/24411114/c-sharp-copy-bitmaps-pixels-in-the-alpha-channel-on-another-bitmap/24411925#24411925
        /// </remarks>
        public static Bitmap mixBitmap(Bitmap bitmap, Bitmap alphaChannel)
        {
            Size s1 = bitmap.Size;
            Size s2 = alphaChannel.Size;
            if (s1 != s2) return null;

            PixelFormat fmt1 = bitmap.PixelFormat;
            PixelFormat fmt2 = alphaChannel.PixelFormat;

            PixelFormat fmt = new PixelFormat();
            fmt = PixelFormat.Format32bppArgb;
            Bitmap newBitmap = new Bitmap(s1.Width, s1.Height, fmt);

            Rectangle rect = new Rectangle(0, 0, s1.Width, s1.Height);

            BitmapData bmp1Data = bitmap.LockBits(rect, ImageLockMode.ReadOnly, fmt1);
            BitmapData bmp2Data = alphaChannel.LockBits(rect, ImageLockMode.ReadOnly, fmt2);
            BitmapData bmp3Data = newBitmap.LockBits(rect, ImageLockMode.ReadWrite, fmt);

            byte bpp1 = 4;
            byte bpp2 = 4;
            byte bpp3 = 4;

            if (fmt1 == PixelFormat.Format24bppRgb) bpp1 = 3;
            else if (fmt1 == PixelFormat.Format32bppArgb) bpp1 = 4; else return null;
            if (fmt2 == PixelFormat.Format24bppRgb) bpp2 = 3;
            else if (fmt2 == PixelFormat.Format32bppArgb) bpp2 = 4; else return null;

            int size1 = bmp1Data.Stride * bmp1Data.Height;
            int size2 = bmp2Data.Stride * bmp2Data.Height;
            int size3 = bmp3Data.Stride * bmp3Data.Height;
            byte[] data1 = new byte[size1];
            byte[] data2 = new byte[size2];
            byte[] data3 = new byte[size3];
            System.Runtime.InteropServices.Marshal.Copy(bmp1Data.Scan0, data1, 0, size1);
            System.Runtime.InteropServices.Marshal.Copy(bmp2Data.Scan0, data2, 0, size2);
            System.Runtime.InteropServices.Marshal.Copy(bmp3Data.Scan0, data3, 0, size3);

            for (int y = 0; y < s1.Height; y++)
            {
                for (int x = 0; x < s1.Width; x++)
                {
                    int index1 = y * bmp1Data.Stride + x * bpp1;
                    int index2 = y * bmp2Data.Stride + x * bpp2;
                    int index3 = y * bmp3Data.Stride + x * bpp3;
                    Color c1, c2;

                    if (bpp1 == 4)
                        c1 = Color.FromArgb(data1[index1 + 3], data1[index1 + 2], data1[index1 + 1], data1[index1 + 0]);
                    else c1 = Color.FromArgb(255, data1[index1 + 2], data1[index1 + 1], data1[index1 + 0]);
                    if (bpp2 == 4)
                        c2 = Color.FromArgb(data2[index2 + 3], data2[index2 + 2], data2[index2 + 1], data2[index2 + 0]);
                    else c2 = Color.FromArgb(255, data2[index2 + 2], data2[index2 + 1], data2[index2 + 0]);

                    byte A = (byte)(255 * c2.GetBrightness());
                    data3[index3 + 0] = c1.B;
                    data3[index3 + 1] = c1.G;
                    data3[index3 + 2] = c1.R;
                    data3[index3 + 3] = A;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(data3, 0, bmp3Data.Scan0, data3.Length);
            bitmap.UnlockBits(bmp1Data);
            alphaChannel.UnlockBits(bmp2Data);
            newBitmap.UnlockBits(bmp3Data);
            return newBitmap;
        }

    }
}
