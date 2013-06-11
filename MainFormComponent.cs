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
            adder = new AddButton(30, 30);
            adder.Location = new Point(0, 50);
            adder.MouseClick += adder_MouseClick;
          
            // MainForm
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "MainForm";
            this.Size = new Size(300, 500);
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.Controls.Add(titleBar);
            this.Controls.Add(adder);

            Test t = new Test();
            t.Location = new Point(0, 200);
            this.Controls.Add(t);

            Test s = new Test();
            s.Location = new Point(0, 300);
            this.Controls.Add(s);

            this.ResumeLayout(false);
        }

        // Enable dragging from anywhere
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        public void adder_MouseClick(object sender, MouseEventArgs e)
        {
            CreateEventForm form = new CreateEventForm();
            form.ShowDialog();
        }
    }
}