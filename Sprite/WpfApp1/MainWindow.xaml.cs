using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Bitmap srcBitmap = null;
        private System.Windows.Controls.Image img = null;
        private NotifyIcon notifyIcon = null;


        public MainWindow()
        {
            InitializeComponent();
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;
            this.ShowInTaskbar = false;
            this.Background = System.Windows.Media.Brushes.Transparent;

            //init image
            srcBitmap = WpfApp1.Properties.Resources.defaultShell;
            img = new System.Windows.Controls.Image();
            img.Margin = new Thickness(0, 0, 0, 0);
            img.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            img.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.SetBitmap(srcBitmap);
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
        /// set image
        /// </summary>
        /// <param name="bitmap">System.Drawing.Bitmap</param>
        public void SetBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                return;

            srcBitmap = bitmap;
            BitmapImage bmp = API.BitmapToBitmapImage(bitmap);
            this.img.Source = bmp;
            this.Width = img.Width = bmp.PixelWidth;
            this.Height = img.Height = bmp.Height;
        }

        /// <summary>
        /// set NotifyIcon's icon
        /// </summary>
        /// <param name="icon">System.Drawing.Icon</param>
        public void setNotifyIcon(Icon icon)
        {
            this.notifyIcon.Icon = icon;
        }

        /// <summary>
        /// Set notify menu
        /// </summary>
        /// <param name="menu">System.Windows.Forms.ContextMenuStrip</param>
        public void setNotifyMenu(ContextMenuStrip menu)
        {
            notifyIcon.ContextMenuStrip = menu;
        }

        /// <summary>
        /// get Ref NotifyIcon object
        /// <para>if you want add event(like DoubleClick event) to the NotifyIcon</para>
        /// </summary>
        /// <returns></returns>
        public NotifyIcon getNotifyIcon()
        {
            return this.notifyIcon;
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            notifyIcon.Dispose();
        }
    }
}
