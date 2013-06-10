using System;
using System.Windows.Forms;
using System.Drawing;

namespace Reminder
{
    public partial class MainForm
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int MainFormWidth = 300;
        private const int MainFormHeight = 500;

        TitleBar titleBar;
        PictureBox adder;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // titleBar
            titleBar = new TitleBar();
            titleBar.Size = new Size(300 - 2, 40);
            titleBar.Location = new Point(0 + 1, 1);
            titleBar.BackColor = Color.DimGray;

            // adder
            adder = new PictureBox();
            adder.Size = new Size(50, 50);
            adder.Location = new Point(0, 50);
            adder.BackColor = Color.Aqua;
            adder.MouseClick += adder_MouseClick;
            adder.Paint += adder_Paint;
          
            // MainForm
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "MainForm";
            this.Size = new Size(300, 500);
            this.BackColor = Color.DimGray;
            this.Controls.Add(titleBar);
            this.Controls.Add(adder);
            this.Paint += form_Paint;

            this.ResumeLayout(false);
        }

        // Enable dragging from anywhere
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        public void form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point topLeft = new Point(e.ClipRectangle.Left, e.ClipRectangle.Top);
            Point topRight = new Point(e.ClipRectangle.Right - 1, e.ClipRectangle.Top);
            Point bottomLeft = new Point(e.ClipRectangle.Left, e.ClipRectangle.Bottom - 1);
            Point bottomRight = new Point(e.ClipRectangle.Right - 1, e.ClipRectangle.Bottom - 1);
            Pen pen = new Pen(Color.Blue);
            g.DrawLine(pen, topLeft, topRight);
            g.DrawLine(pen, topLeft, bottomLeft);
            g.DrawLine(pen, topRight, bottomRight);
            g.DrawLine(pen, bottomLeft, bottomRight);
        }

        public void adder_MouseClick(object sender, MouseEventArgs e)
        {
            CreateEventForm form = new CreateEventForm();
            form.ShowDialog();
        }

        public void adder_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Red);
            g.DrawString("Add", new Font("Segoe Script", 10F), Brushes.Black, new PointF(5, 5));
        }
    }
}