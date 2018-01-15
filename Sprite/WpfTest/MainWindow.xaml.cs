using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Image img = null;
        private NotifyIcon notifyIcon = null;

        public MainWindow()
        {
            InitializeComponent();
        }





        public void SetBitmap(BitmapImage bitmap)
        {
            this.img.Source = bitmap;
            this.Width = img.Width = bitmap.PixelWidth;
            this.Height = img.Height = bitmap.Height;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //init image
            img = new Image();
            img.Margin = new Thickness(0, 0, 0, 0);
            grid1.Children.Add(img);


            //init notifyIcon
            this.notifyIcon = new NotifyIcon();
            this.notifyIcon.Icon = new System.Drawing.Icon(@"b.ico");

            //而是命名空间: component / Resources / 0.png
            //Image img = new Image();
            Uri uriSource = new Uri("C:\\surface.png", UriKind.Relative);
            BitmapImage bmp = new BitmapImage(uriSource);
            img.Source = bmp;

            img.Width = bmp.PixelWidth;
            img.Height = bmp.PixelHeight;
            img.Margin = new Thickness(0, 0, 0, 0);
            //this.SnapsToDevicePixels = true;
            this.Width = bmp.PixelWidth;
            this.Height = bmp.PixelHeight;

            //imgBackground.Source = new BitmapImage(uriSource);

            grid1.Children.Add(img);

            //MessageBox.Show("Event");
        }




    }
}
