using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Reminder
{
    public class CloseButton : PictureBox
    {
        Bitmap map;
        Graphics g;

        public CloseButton(int width, int height)
        {
            map = new Bitmap(width, height);
            g = Graphics.FromImage(map);
            drawCross(width, height);

            this.Image = map;
            this.Size = new Size(width, height);
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.MouseEnter += CloseButton_MouseEnter;
            this.MouseLeave += CloseButton_MouseLeave;
            this.MouseClick += CloseButton_MouseClick;
        }

        void drawCross(int width, int height)
        {
            Pen p = new Pen(Color.White, width * 0.2F);
            p.Alignment = PenAlignment.Center;

            Point TopLeft = new Point((int)(width * 0.2F), (int)(height * 0.2F));
            Point TopRight = new Point((int)(width * 0.8F), (int)(height * 0.2F));
            Point BottomLeft = new Point((int)(width * 0.2F), (int)(height * 0.8F));
            Point BottomRight = new Point((int)(width * 0.8F), (int)(height * 0.8F));

            g.DrawLine(p, TopLeft, BottomRight);
            g.DrawLine(p, TopRight, BottomLeft);
        }

        void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Turquoise;
            Application.DoEvents();
        }

        void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(45, 45, 48);
            Application.DoEvents();
        }

        void CloseButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.FindForm().Close();
        }
    }
}