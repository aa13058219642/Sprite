﻿using System;
using System.Drawing;
using Helper;

namespace CCore
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

            Bitmap bmp1 = new Bitmap("C:\\surface0.png");
            Bitmap bmp2 = new Bitmap("C:\\surface0000.png");
            win2.SetBitmap(BitmapHelper.MixBitmap(bmp1, bmp2));
            win2.Show();
            win2.Hide();
            win2.Show();

            //ContextMenuStrip cs = new ContextMenuStrip();
            //ToolStripMenuItem item = new ToolStripMenuItem();
            //item.Text = "Exit";
            //item.Click += new EventHandler(delegate (object sender, EventArgs e) { System.Windows.Application.Current.Shutdown(); });
            //cs.Items.Add(item);

            //NotifyIcon notifyIcon = win2.getNotifyIcon();
            //notifyIcon.ContextMenuStrip = cs;

            var dlg = new Dialog();
            Bitmap dlgimg = new Bitmap("C:\\defaultDialog.png");
            dlg.SetScale9Bitmap(dlgimg);
            dlg.SetDialogSize(400, 300);
            dlg.SetLocaltion(0, 0);
            dlg.GetMainPanel().Children.Add(dlg.GetSampleLabel("Silple Text",10,10));
            dlg.Show();
            app.Run();

            /**
            // 方式3
            app.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
            app.Run();
            */
        }

        

    }
}
