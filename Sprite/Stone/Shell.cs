using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using StoneLib.Properties;


namespace StoneLib
{
    public partial class Shell : Form
    {
        public Shell()
        {
            InitializeComponent();

            this.BackgroundImageLayout = ImageLayout.None;
            this.SetBitmap(Resources.defaultShell);
            this.Icon = Resources.icon;
        }


        protected override CreateParams CreateParams
        {
            get
            {
                // Add the layered extended style (WS_EX_LAYERED) to this window.
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WinAPI.WS_EX_LAYERED;
                return createParams;
            }
        }



        public void SetBitmap(Bitmap bitmap, int opacity=255)
        {
            WinAPI.SelectBitmap(this, bitmap, opacity);
        }



    }
}
