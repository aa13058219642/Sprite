using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using WpfTest;

namespace WpfApp1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            System.Windows.Application app = new System.Windows.Application();
            
            // 方式1
            //MainWindow win = new MainWindow();
            //app.Run(win);

            // 方式2
            MainWindow win2 = new MainWindow();
            app.MainWindow = win2;
            win2.Show();

            Bitmap bmp1 = new Bitmap("C:\\surface0.png");
            Bitmap bmp2 = new Bitmap("C:\\surface0000.png");
            win2.SetBitmap(API.mixBitmap(bmp1, bmp2));


            ContextMenuStrip cs = new ContextMenuStrip();
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = "ExitXXXXXXXXXXXXXXX";
            item.Click += new EventHandler(delegate (object sender, EventArgs e) { System.Windows.Application.Current.Shutdown(); });
            cs.Items.Add(item);

            NotifyIcon notifyIcon = win2.getNotifyIcon();
            notifyIcon.ContextMenuStrip = cs;



            app.Run();

            /**
            // 方式3
            app.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
            app.Run();
            */
        }

        

    }
}
