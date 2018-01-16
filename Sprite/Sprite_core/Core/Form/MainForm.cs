using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpriteCore.Properties;


namespace SpriteSpace
{
    public partial class MainForm : Form
    {
        private SpriteForm s;


        public MainForm()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;

            CreateSprite();
        }

        public void CreateSprite()
        {
            s = new SpriteForm();
            s.SelectBitmap(Resources.surface);
            s.Tag = "1";
            s.Show();
            s.Owner = this;
            Core core = Core.GetInstance();
            //sprites.Add(s);
        }

        public void setBitmap(Bitmap bitmap)
        {
            //Bitmap bitmap = Core.BytesToBitmap(bitmapBytes);
            s.SelectBitmap(bitmap);
        }

        public SpriteForm getSprite()
        {
            return s;
        }


        private void Main_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bitmap map = new Bitmap();



            //setBitmap(Core.BitmapToBytes( Resources.surface2));
        }

        private void MainForm_Click(object sender, EventArgs e)
        {

        }
    }
}
