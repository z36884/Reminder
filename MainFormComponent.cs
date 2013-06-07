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

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // TitleBar
            TitleBar titleBar = new TitleBar();
            titleBar.Size = new Size(300, 40);
            titleBar.Location = new Point(0, 0);
            titleBar.BackColor = Color.DimGray;

          
            // MainForm
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "MainForm";
            this.Size = new Size(300, 500);
            this.Controls.Add(titleBar);

            this.ResumeLayout(false);
        }

        //
        // Enable dragging from anywhere
        //
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }
    }
}