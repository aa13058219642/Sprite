using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
//using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Drawing;


namespace WpfApp1
{
    public partial class Dialog : System.Windows.Window
    {
        private Bitmap scale9 = null;
        private System.Windows.Controls.Image img = null;

        public Dialog()
        {
            InitializeComponent();
            this.AllowsTransparency = true;
            this.WindowStyle = System.Windows.WindowStyle.None;
            this.ShowInTaskbar = false;
            this.Background = System.Windows.Media.Brushes.Transparent;

            //init image
            img = new System.Windows.Controls.Image();
            img.Margin = new System.Windows.Thickness(0, 0, 0, 0);
            img.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            img.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            grid1.Children.Add(img);

            scale9 = WpfApp1.Properties.Resources.defaultDialog;
            this.SetScale9Bitmap(scale9);

            //label
            var lab = new System.Windows.Controls.TextBlock();
            lab.Margin = new System.Windows.Thickness(100, 100, 0, 0);
            lab.Foreground = System.Windows.Media.Brushes.Red;
            lab.Text = "666666666";
            lab.MouseEnter+= new System.Windows.Input.MouseEventHandler(
                delegate (object sender, System.Windows.Input.MouseEventArgs e){

                    lab.FontStyle=System.Windows.FontStyle.
                });
            grid1.Children.Add(lab);
        }

        /// <summary>
        /// set image
        /// </summary>
        /// <param name="bitmap">System.Drawing.Bitmap</param>
        public void SetScale9Bitmap(Bitmap bitmap)
        {
            scale9 = bitmap;
            SetBitmap(API.ConvertScale9bitmap(scale9, (int)this.Width, (int)this.Width));
        }

        /// <summary>
        /// set image
        /// </summary>
        /// <param name="bitmap">System.Drawing.Bitmap</param>
        public void SetBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                return;

            BitmapImage bmp = WpfApp1.API.BitmapToBitmapImage(bitmap);
            this.img.Source = bmp;
            this.Width = img.Width = bmp.PixelWidth;
            this.Height = img.Height = bmp.Height;
        }

        public void SetDialogSize(int width,int height)
        {
            this.Width = width;
            this.Height = height;
        }

        private void Window_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            SetBitmap(API.ConvertScale9bitmap(scale9, (int)this.Width, (int)this.Height));
        }
    }
}
