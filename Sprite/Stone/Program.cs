using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoneLib
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Stone());







            //Image img1 = Image.FromFile("C:\\surface0.png");
            //Bitmap bmp1 = new Bitmap(img1);

            //Image img2 = Image.FromFile("C:\\surface0000.png");
            //Bitmap bmp2 = new Bitmap(img2);

            //Shell s = new Shell();
            //WinAPI.SelectBitmap(s, bmp1, bmp2);
            //s.Show();

            //Dialog d = new Dialog();
            ////d.SetBitmap(bmp1);
            //d.Size = new Size(500, 80);
            //d.Show();

            Dialog2 d = new Dialog2();
            //d.SetBitmap(bmp1);
            d.FormBorderStyle = FormBorderStyle.Sizable;
            d.Size = new Size(500, 80);

            Application.Run(d);

        }
    }
}
