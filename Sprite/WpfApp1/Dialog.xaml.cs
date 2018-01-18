using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
//using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
//using System.Drawing;

namespace WpfApp1
{
    public partial class Dialog : System.Windows.Window
    {
        private System.Drawing.Bitmap scale9 = null;
        private Image backgroundImage = null;
        private Canvas mainpanel = null;

        public Dialog()
        {
            InitializeComponent();
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;
            this.ShowInTaskbar = false;
            this.Background = Brushes.Transparent;
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.MouseLeftButtonDown += new MouseButtonEventHandler(
                delegate (object sender, MouseButtonEventArgs e)
                {
                    this.DragMove();
                });

            //init image
            backgroundImage = new Image();
            backgroundImage.Margin = new Thickness(0, 0, 0, 0);
            backgroundImage.VerticalAlignment = VerticalAlignment.Top;
            backgroundImage.HorizontalAlignment = HorizontalAlignment.Left;
            root.Children.Add(backgroundImage);

            scale9 = WpfApp1.Properties.Resources.defaultDialog;
            this.SetScale9Bitmap(scale9);

            //panel
            mainpanel = new Canvas();
            mainpanel.Margin = new Thickness(0, 0, 0, 0);
            root.Children.Add(mainpanel);

            /** Label example
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
            panel.Children.Add( tb);
            */
        }

        /// <summary>
        /// set base scale9 bitmap
        /// <para>the scale9 bitmap will auto scale size same the window when the window's size changed</para>
        /// </summary>
        /// <param name="bitmap">System.Drawing.Bitmap</param>
        public void SetScale9Bitmap(System.Drawing.Bitmap bitmap)
        {
            scale9 = bitmap;
            SetBitmap(API.ConvertScale9bitmap(scale9, (int)this.Width, (int)this.Width));
        }

        /// <summary>
        /// set a bitmap as window's background
        /// </summary>
        /// <param name="bitmap">System.Drawing.Bitmap</param>
        public void SetBitmap(System.Drawing.Bitmap bitmap)
        {
            if (bitmap == null)
                return;

            BitmapImage bmp = WpfApp1.API.BitmapToBitmapImage(bitmap);
            this.backgroundImage.Source = bmp;
            this.Width = backgroundImage.Width = bmp.PixelWidth;
            this.Height = backgroundImage.Height = bmp.Height;
        }

        /// <summary>
        /// set windows size
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetDialogSize(int width,int height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// set window loaction
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetLocaltion(int x,int y)
        {
            this.Left = x;
            this.Top = y;
        }

        /// <summary>
        /// return the windows main panel
        /// </summary>
        /// <returns></returns>
        public Canvas GetMainPanel()
        {
            return mainpanel;
        }

        /// <summary>
        /// create a 
        /// </summary>
        /// <returns></returns>
        public TextBlock GetSampleLabel(string labeltext = "Label", double x = 0, double y = 0)
        {
            var lab = new TextBlock();
            lab.Margin = new Thickness(x, y, 0, 0);
            lab.Foreground = Brushes.Black;
            lab.TextDecorations = null;
            lab.Text = "Sample Label";
            lab.MouseEnter += new MouseEventHandler(
                delegate (object sender, MouseEventArgs e) {
                    lab.TextDecorations = TextDecorations.Underline;
                });
            lab.MouseLeave += new MouseEventHandler(
                delegate (object sender, MouseEventArgs e) {
                    lab.TextDecorations = null;
                });
            return lab;
        }


        private void Window_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            SetBitmap(API.ConvertScale9bitmap(scale9, (int)this.Width, (int)this.Height));
        }


        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            Console.Write(1);
        }
    }
}
