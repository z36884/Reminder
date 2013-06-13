using System;
using System.Windows.Forms;
using System.Drawing;

namespace Reminder
{
    public class TitleBar : Panel
    {
        bool drag = false;
        Point startPoint;
        Point formStartPoint;

        public TitleBar()
        {
            // title
            Label title = new Label();
            title.Text = "Reminder";
            title.Location = new Point(0, 0);
            title.Size = new Size(170, 40);
            title.Font = new Font("Segoe Script", 20F);
            title.MouseDown += titleBarMouseDown;
            title.MouseUp += titleBarMouseUp;
            title.MouseMove += titleBarMouseMove;

            // minimize
	    PictureBox mini = new PictureBox();
	    mini.BackColor = Color.Red;
	    mini.Location = new Point(180,5);
	    mini.Size = new Size(30,30);

            // close
            CloseButton close = new CloseButton(20, 20);
            close.Location = new Point(268, 10);

            // TitleBar
            this.MouseDown += titleBarMouseDown;
            this.MouseUp += titleBarMouseUp;
            this.MouseMove += titleBarMouseMove;
            this.Controls.Add(title);
            this.Controls.Add(mini);
            this.Controls.Add(close);
        }

        void titleBarMouseDown(object sender, MouseEventArgs e)
        {
            startPoint = this.PointToScreen(e.Location);
            formStartPoint = this.FindForm().Location;
            this.drag = true;
        }

        void titleBarMouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        void titleBarMouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                int XDelta, YDelta;
                Point endPoint = this.PointToScreen(e.Location);
                XDelta = endPoint.X - startPoint.X;
                YDelta = endPoint.Y - startPoint.Y;
                this.FindForm().Location = new Point(formStartPoint.X + XDelta, formStartPoint.Y + YDelta);
            }
        }
    }
}
