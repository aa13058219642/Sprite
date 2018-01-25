using System;
using System.Windows;
using Controls = System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Drawing;
using Helper;

namespace CCore
{
    public partial class CDialog : Window
    {
        private Bitmap scale9 = null;
        private Controls.Image backgroundImage = null;
        private Controls.Canvas mainpanel = null;

        public CDialog()
        {
            InitializeComponent();
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;
            this.ShowInTaskbar = false;
            this.Background = System.Windows.Media.Brushes.Transparent;
            this.Topmost = true;
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.MouseLeftButtonDown += new MouseButtonEventHandler(
                delegate (object sender, MouseButtonEventArgs e)
                {
                    this.DragMove();
                });

            //init image
            backgroundImage = new Controls.Image();
            backgroundImage.Margin = new Thickness(0, 0, 0, 0);
            backgroundImage.VerticalAlignment = VerticalAlignment.Top;
            backgroundImage.HorizontalAlignment = HorizontalAlignment.Left;
            root.Children.Add(backgroundImage);

            scale9 = Properties.Resources.defaultDialog;
            this.SetScale9Bitmap(scale9);

            //panel
            mainpanel = new Controls.Canvas();
            mainpanel.Margin = new Thickness(0, 0, 0, 0);
            root.Children.Add(mainpanel);

            /** Label example
            Controls.TextBlock tb = new Controls.TextBlock();
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Foreground = Media.Brushes.White;
            tb.Margin = new Thickness(10);
            tb.Inlines.Add("An example on ");
            tb.Inlines.Add(new Documents.Run("the TextBlock control ") { FontWeight = FontWeights.Bold });
            tb.Inlines.Add("using ");
            tb.Inlines.Add(new Documents.Run("inline ") { FontStyle = FontStyles.Italic });
            tb.Inlines.Add(new Documents.Run("text formatting ") { Foreground = Media.Brushes.Blue });
            tb.Inlines.Add("from ");
            tb.Inlines.Add(new Documents.Run("Code-Behind") { TextDecorations = new TextDecorationCollection{ TextDecorations.Underline, TextDecorations.Strikethrough } });
            tb.Inlines.Add(".");
            panel.Children.Add( tb);
            */
        }

        /// <summary>
        /// set base scale9 bitmap
        /// <para>the scale9 bitmap will auto scale size same the window when the window's size changed</para>
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
        public void SetScale9Bitmap(Bitmap bitmap)
        {
            scale9 = bitmap;
            SetBitmap(BitmapHelper.ConvertScale9bitmap(scale9, (int)this.Width, (int)this.Width));
        }

        /// <summary>
        /// set a bitmap as window's background
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
        public void SetBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                return;

            BitmapImage bmp = BitmapHelper.BitmapToBitmapImage(bitmap);
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
        public Controls.Canvas GetMainPanel()
        {
            return mainpanel;
        }

        /// <summary>
        /// create a 
        /// </summary>
        /// <returns></returns>
        public Controls.TextBlock GetSampleLabel(string labeltext = "Label", double x = 0, double y = 0)
        {
            var lab = new Controls.TextBlock();
            lab.Margin = new Thickness(x, y, 0, 0);
            lab.Foreground = System.Windows.Media.Brushes.Black;
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


        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetBitmap(BitmapHelper.ConvertScale9bitmap(scale9, (int)this.Width, (int)this.Height));
        }


        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            Console.Write(1);
        }
    }
}
