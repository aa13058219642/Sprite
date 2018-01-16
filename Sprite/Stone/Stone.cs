using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StoneLib
{
    public partial class Stone : Form
    {
        public Stone()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;




            Image img1 = Image.FromFile("C:\\surface0.png");
            Bitmap bmp1 = new Bitmap(img1);

            Image img2 = Image.FromFile("C:\\surface0000.png");
            Bitmap bmp2 = new Bitmap(img2);

            //Dialog d =  new Dialog();
            //d.SetBitmap(bmp1);
            //d.Size =new Size(500, 80);
            //d.Show();


            Shell s = new Shell();
            WinAPI.SelectBitmap(s, bmp1,bmp2);
            s.Show();
        }




    }
}
