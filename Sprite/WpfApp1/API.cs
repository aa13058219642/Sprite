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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }


        /// <summary>
        /// the <see cref="System.Drawing.Bitmap"/> will be convert to <see cref="System.Windows.Media.Imaging.BitmapImage"/>    
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
        /// <param name="bitmap"></param>
        /// <param name="opacity">[0,1]</param>
        /// <returns></returns>
        public static Bitmap SetBitmapOpacity(Bitmap bitmap, double opacity)
        {
            Bitmap bmp = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int h = 0; h < bitmap.Height; h++)
                for (int w = 0; w < bitmap.Width; w++)
                {
                    Color c = bitmap.GetPixel(w, h);
                    bmp.SetPixel(w, h, Color.FromArgb((int)(opacity*c.A), c.R, c.G, c.B));//色彩度最大为255，最小为0
                }
            return bmp;
        }


        /** mixBitmap old version
         *  
        /// <summary>
        /// mix a bitmap(no alpha channel) and its alpha channel to a new bitmap(have alpha channel)
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
        */

        /// <summary>
        /// mix a bitmap(no alpha channel) and its alpha channel to a new bitmap(have alpha channel)
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="alphaChannel"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://stackoverflow.com/questions/24411114/c-sharp-copy-bitmaps-pixels-in-the-alpha-channel-on-another-bitmap/24411925#24411925
        /// </remarks>
        public static Bitmap MixBitmap(Bitmap bitmap, Bitmap alphaChannel)
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


        /// <summary>
        /// make a new bitmap(width * height) form sprite9bitmap
        /// </summary>
        /// <param name="scale9bitmap"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap ConvertScale9bitmap(Bitmap scale9bitmap, int width, int height)
        {
            if (scale9bitmap == null)
                return null;

            int w = scale9bitmap.Width / 3;
            int h = scale9bitmap.Height / 3;
            int cw = width - 2 * w;
            int ch = height - 2 * h;

            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(scale9bitmap, new Rectangle(new Point(w + cw, h + ch), new Size(w, h)), new Rectangle(new Point(w << 1, h << 1), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(scale9bitmap, new Rectangle(new Point(w, h + ch), new Size(cw, h)), new Rectangle(new Point(w, h << 1), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(scale9bitmap, new Rectangle(new Point(0, h + ch), new Size(w, h)), new Rectangle(new Point(0, h << 1), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(scale9bitmap, new Rectangle(new Point(w + cw, h), new Size(w, ch)), new Rectangle(new Point(w << 1, h), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(scale9bitmap, new Rectangle(new Point(w, h), new Size(cw, ch)), new Rectangle(new Point(w, h), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(scale9bitmap, new Rectangle(new Point(0, h), new Size(w, ch)), new Rectangle(new Point(0, h), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(scale9bitmap, new Rectangle(new Point(w + cw, 0), new Size(w, h)), new Rectangle(new Point(w << 1, 0), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(scale9bitmap, new Rectangle(new Point(w, 0), new Size(cw, h)), new Rectangle(new Point(w, 0), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(scale9bitmap, new Rectangle(new Point(0, 0), new Size(w, h)), new Rectangle(new Point(0, 0), new Size(w, h)), GraphicsUnit.Pixel);
            g.Dispose();

            return bmp;
        }
    }
}
