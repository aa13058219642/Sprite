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
        private Bitmap dragBitmap = null;
        private System.Windows.Controls.Image img = null;
        private NotifyIcon notifyIcon = null;


        public MainWindow()
        {
            InitializeComponent();
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;
            this.ShowInTaskbar = false;
            this.Background = System.Windows.Media.Brushes.Transparent;
            this.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(
                delegate (object sender, System.Windows.Input.MouseButtonEventArgs e) {
                    setBackgound(dragBitmap);
                    this.DragMove();
                });
            this.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(
                delegate (object sender, System.Windows.Input.MouseButtonEventArgs e) {
                    repairLocation();
                    setBackgound(srcBitmap);
                });

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
            dragBitmap = API.SetBitmapOpacity(bitmap, 0.7);
            setBackgound(bitmap);
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

        private void setBackgound(Bitmap bitmap)
        {
            BitmapImage bmp = API.BitmapToBitmapImage(bitmap);
            this.img.Source = bmp;
            this.Width = img.Width = bmp.PixelWidth;
            this.Height = img.Height = bmp.Height;
        }

        private void repairLocation()
        {
            double wx = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double wy = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            double sx = SystemParameters.PrimaryScreenWidth;//得到屏幕整体宽度
            double sy = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度

            this.Left = API.Clamp(this.Left, 0,sx - this.Width);
            this.Top = API.Clamp(this.Top, 0,sy-this.Height);
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            notifyIcon.Dispose();
        }
    }
}
