using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoneLib.Properties;

namespace StoneLib
{
    public partial class Dialog2 : CoolImageDlg.ImageDlgBase
    {
        Bitmap sprite9bitmap = Resources.defaultDialog;

        public Dialog2()
        {
            base.DlgBgImg = sprite9bitmap;
            InitializeComponent();

            Panel p = new Panel();
            p.BackColor= Color.Transparent;
            p.Controls.Add(newLabel());


            this.Controls.Add(p);
        }

        public Label newLabel()
        {
            Label label = new Label();

            label.AutoSize = true;
            label.Location = new System.Drawing.Point(10, 10);
            label.Name = "label1";
            label.Size = new System.Drawing.Size(41, 12);
            label.TabIndex = 0;
            label.Text = "label1";
            //label.BackColor = Color.Transparent;
            label.ForeColor= Color.Red;
            //label.BackColor = Color.Black;
            label.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            label.MouseHover += new System.EventHandler(this.label1_MouseHover);

            return label;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Font = new Font(label.Font, label.Font.Style | FontStyle.Underline);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Font = new Font(label.Font, label.Font.Style & ~FontStyle.Underline);
        }




        public void SetSprite9GridImage(Bitmap bitmap, int opacity = 255)
        {
            sprite9bitmap = bitmap;

            int w = bitmap.Width / 3;
            int h = bitmap.Height / 3;
            int cw = this.Width - 2 * w;
            int ch = this.Height - 2 * h;

            //cw = cw < 0 ? 0 : cw;
            //ch = ch < 0 ? 0 : ch;

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(bitmap, new Rectangle(new Point(w + cw, h + ch), new Size(w, h)), new Rectangle(new Point(w << 1, h << 1), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(bitmap, new Rectangle(new Point(w, h + ch), new Size(cw, h)), new Rectangle(new Point(w, h << 1), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(bitmap, new Rectangle(new Point(0, h + ch), new Size(w, h)), new Rectangle(new Point(0, h << 1), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(bitmap, new Rectangle(new Point(w + cw, h), new Size(w, ch)), new Rectangle(new Point(w << 1, h), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(bitmap, new Rectangle(new Point(w, h), new Size(cw, ch)), new Rectangle(new Point(w, h), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(bitmap, new Rectangle(new Point(0, h), new Size(w, ch)), new Rectangle(new Point(0, h), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(bitmap, new Rectangle(new Point(w + cw, 0), new Size(w, h)), new Rectangle(new Point(w << 1, 0), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(bitmap, new Rectangle(new Point(w, 0), new Size(cw, h)), new Rectangle(new Point(w, 0), new Size(w, h)), GraphicsUnit.Pixel);
            g.DrawImage(bitmap, new Rectangle(new Point(0, 0), new Size(w, h)), new Rectangle(new Point(0, 0), new Size(w, h)), GraphicsUnit.Pixel);

            //WinAPI.SelectBitmap(this, bmp, opacity);
            base.DlgBgImg = bmp;
        }

        private void Dialog2_Resize(object sender, EventArgs e)
        {
            this.SetSprite9GridImage(this.sprite9bitmap);
        }
    }
}
