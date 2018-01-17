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

            /** Label example
            var lab = new System.Windows.Controls.TextBlock();
            lab.Margin = new System.Windows.Thickness(100, 100, 0, 0);
            
            lab.Foreground = System.Windows.Media.Brushes.Red;
            //lab.Background = System.Windows.Media.Brushes.Blue;
            lab.TextDecorations = System.Windows.TextDecorations.Strikethrough;
            lab.Text = "666666666";
            lab.MouseEnter+= new System.Windows.Input.MouseEventHandler(
                delegate (object sender, System.Windows.Input.MouseEventArgs e){
                    lab.TextDecorations = System.Windows.TextDecorations.Underline;
                });
            lab.MouseLeave+= new System.Windows.Input.MouseEventHandler(
                delegate (object sender, System.Windows.Input.MouseEventArgs e) {
                    lab.TextDecorations = null;
                });
            grid1.Children.Add(lab);

            System.Windows.Controls.TextBlock tb = new System.Windows.Controls.TextBlock();
            tb.TextWrapping = System.Windows.TextWrapping.Wrap;
            tb.Foreground = System.Windows.Media.Brushes.White;
            tb.Margin = new System.Windows.Thickness(10);
            tb.Inlines.Add("An example on ");
            tb.Inlines.Add(new System.Windows.Documents.Run("the TextBlock control ") { FontWeight = System.Windows.FontWeights.Bold });
            tb.Inlines.Add("using ");
            tb.Inlines.Add(new System.Windows.Documents.Run("inline ") { FontStyle = System.Windows.FontStyles.Italic });
            tb.Inlines.Add(new System.Windows.Documents.Run("text formatting ") { Foreground = System.Windows.Media.Brushes.Blue });
            tb.Inlines.Add("from ");
            tb.Inlines.Add(new System.Windows.Documents.Run("Code-Behind") { TextDecorations = new System.Windows.TextDecorationCollection{ System.Windows.TextDecorations.Underline, System.Windows.TextDecorations.Strikethrough } });
            tb.Inlines.Add(".");
            grid1.Children.Add( tb);
            */
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
