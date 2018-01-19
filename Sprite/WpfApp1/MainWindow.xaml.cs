using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using Controls = System.Windows.Controls;
using Forms = System.Windows.Forms;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Bitmap srcBitmap = null;
        private Bitmap dragBitmap = null;
        private Controls.Image img = null;
        private Forms.NotifyIcon notifyIcon = null;
        
        private bool FixedInScreen = false;


        public MainWindow()
        {
            InitializeComponent();
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;
            this.ShowInTaskbar = false;
            this.Background = System.Windows.Media.Brushes.Transparent;
            this.Topmost = true;
            
            this.MouseLeftButtonDown += new MouseButtonEventHandler(
                delegate (object sender, MouseButtonEventArgs e) 
                {
                    setBackgound(dragBitmap);
                    this.DragMove();
                });
            this.MouseLeftButtonUp += new MouseButtonEventHandler(
                delegate (object sender, MouseButtonEventArgs e) 
                {
                    if(FixedInScreen)
                        repairLocation();
                    setBackgound(srcBitmap);
                });

            //init image
            srcBitmap = WpfApp1.Properties.Resources.defaultShell;
            img = new Controls.Image();
            img.Margin = new Thickness(0, 0, 0, 0);
            img.VerticalAlignment = VerticalAlignment.Top;
            img.HorizontalAlignment = HorizontalAlignment.Left;
            this.SetBitmap(srcBitmap);
            grid1.Children.Add(img);

            //init NotifyIcon
            notifyIcon = new Forms.NotifyIcon();
            notifyIcon.Icon = WpfApp1.Properties.Resources.ico;
            Forms.ContextMenuStrip cs = new Forms.ContextMenuStrip();
            Forms.ToolStripMenuItem item = new Forms.ToolStripMenuItem();
            item.Text = "Exit";
            item.MouseUp += new Forms.MouseEventHandler(
                delegate (object sender, Forms.MouseEventArgs e) 
                { 
                    if (e.Button == Forms.MouseButtons.Left)
                    {
                        Application.Current.Shutdown();
                    }
                });
            cs.Items.Add(item);
            notifyIcon.ContextMenuStrip = cs;
            notifyIcon.Visible = true;


            //init ContextMenu
            Controls.ContextMenu menu = new Controls.ContextMenu();
            Controls.MenuItem exit = new Controls.MenuItem();
            exit.Header = "Exit";
            exit.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(
                delegate (object sender, MouseButtonEventArgs e) 
                {
                    Application.Current.Shutdown();
                    e.Handled = true;
                });
            menu.Items.Add(exit);
            this.SetContextMenu(menu);
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
        /// <param name="menu">Forms.ContextMenuStrip</param>
        public void setNotifyMenu(Forms.ContextMenuStrip menu)
        {
            notifyIcon.ContextMenuStrip = menu;
        }

        /// <summary>
        /// get Ref NotifyIcon object
        /// <para>if you want add event(like DoubleClick event) to the NotifyIcon</para>
        /// </summary>
        /// <returns></returns>
        public Forms.NotifyIcon getNotifyIcon()
        {
            return this.notifyIcon;
        }

        /// <summary>
        /// this window can't be drag out of the screen when set is true
        /// </summary>
        /// <param name="boolean"></param>
        public void IsFixedInScreen(bool boolean)
        {
            this.FixedInScreen = boolean;
        }


        public void SetContextMenu(Controls.ContextMenu menu)
        {
            this.ContextMenu = menu;
        }


        //##############################################################################

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
