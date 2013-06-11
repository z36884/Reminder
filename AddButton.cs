using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Reminder
{
    public class AddButton : PictureBox
    {
        Bitmap map;
        Graphics g;

        public AddButton(int width, int height)
        {
            map = new Bitmap(width, height);
            g = Graphics.FromImage(map);
            drawCross(width, height);

            this.Image = map;
            this.Size = new Size(width, height);
            this.BackColor = Color.Violet;
            this.MouseEnter += AddButton_MouseEnter;
            this.MouseLeave += AddButton_MouseLeave;
        }

        void drawCross(int width, int height)
        {
            Pen p = new Pen(Color.White, width * 0.2F);
            p.Alignment = PenAlignment.Center;

            Point midTop = new Point(width / 2, (int)(height * 0.2F));
            Point midBottom = new Point(width / 2, (int)(height * 0.8F));
            Point midLeft = new Point((int)(width * 0.2F), height / 2);
            Point midRight = new Point((int)(width * 0.8F), height / 2);

            g.DrawLine(p, midLeft, midRight);
            g.DrawLine(p, midTop, midBottom);
        }

        void AddButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Turquoise;
            Application.DoEvents();
        }

        void AddButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Violet;
            Application.DoEvents();
        }
    }
}