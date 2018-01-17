using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace WpfTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Controls.Image img = null;
        private NotifyIcon notifyIcon = null;


        public MainWindow()
        {
            InitializeComponent();

            //init image
            img = new System.Windows.Controls.Image();
            img.Margin = new Thickness(0, 0, 0, 0);
            grid1.Children.Add(img);

            //init NotifyIcon
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = WpfApp1.Properties.Resources.ico;
            ContextMenuStrip cs = new ContextMenuStrip();
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new EventHandler(delegate (object sender, EventArgs e) { System.Windows.Application.Current.Shutdown(); });
            cs.Items.Add(item);
            notifyIcon.ContextMenuStrip = cs;
            notifyIcon.Visible = true;
        }

        /// <summary>
        /// 设置窗体图片
        /// </summary>
        /// <param name="bitmap">System.Drawing.Bitmap</param>
        public void SetBitmap(Bitmap bitmap)
        {
            BitmapImage bmp = WpfApp1.API.BitmapToBitmapImage(bitmap);
            this.img.Source = bmp;
            this.Width = img.Width = bmp.PixelWidth;
            this.Height = img.Height = bmp.Height;
        }

        public void setNotifyIcon(Icon icon)
        {
            this.notifyIcon.Icon = icon;
        }

        public void setNotifyMenu(ContextMenuStrip menu)
        {
            notifyIcon.ContextMenuStrip = menu;
        }

        public NotifyIcon getNotifyIcon()
        {
            return this.notifyIcon;
        }


        private void Window_Closing(object sender, CancelEventArgs e)
        {
            notifyIcon.Dispose();
        }
    }
}
