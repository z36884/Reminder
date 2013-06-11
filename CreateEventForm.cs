using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Reminder
{
    public class CreateEventForm : Form
    {
        GroupBox title, due, type, series;
        TextBox nameTextBox;
        DateTimePicker picker;
        ComboBox typeComboBox;
        Button ok, cancel;
        private const int groupboxWidth = 250;
        bool drag;
        Point startPoint;
        Point formStartPoint;

        public CreateEventForm()
        {
            title = new GroupBox();
            due = new GroupBox();
            type = new GroupBox();

            // name textbox
            nameTextBox = new TextBox();
            nameTextBox.Location = new Point(5, 20);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.KeyDown += keyDown;

            // name group box
            title.Location = new Point(10, 10);
            title.BackColor = Color.Gray;
            title.Size = new Size(groupboxWidth, 70);
            title.Name = "title";
            title.Text = "Title";
            title.Font = new Font(title.Font.FontFamily, 20F);
            title.Controls.Add(nameTextBox);

            // due date time picker
            picker = new DateTimePicker();
            picker.Location = new Point(5, 20);
            picker.Name = "picker";
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = "yyyy.MMM.dd   H:mm";
            picker.KeyDown += keyDown;

            // due group box
            due.Location = new Point(10, 70);
            due.BackColor = Color.Gray;
            due.Size = new Size(groupboxWidth, 70);
            due.Name = "due";
            due.Text = "Due";
            due.Font = new Font(due.Font.FontFamily, 20F);
            due.Controls.Add(picker);

            // type combo box
            typeComboBox = new ComboBox();
            typeComboBox.Location = new Point(5, 20);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Items.Add("Single");
            typeComboBox.Items.Add("Multiple");
            typeComboBox.KeyDown += keyDown;

            // type group box
            type.Location = new Point(10, 130);
            type.BackColor = Color.Gray;
            type.Size = new Size(groupboxWidth, 70);
            type.Name = "type";
            type.Text = "Type";
            type.Font = new Font(type.Font.FontFamily, 20F);
            type.Controls.Add(typeComboBox);

            // buttons
            Button ok = new Button();
            ok.BackColor = Color.Gray;
            ok.Location = new Point(10, 200);
            ok.Name = "ok";
            ok.Text = "Add";

            // CreateEventForm
            this.FormBorderStyle = FormBorderStyle.None;
            this.MouseDown += formMouseDown;
            this.MouseUp += formMouseUp;
            this.MouseMove += formMouseMove;
            this.BackColor = Color.Lime;
            this.TransparencyKey = Color.Lime;
            this.Paint += form_Paint;
            this.Controls.Add(title);
            this.Controls.Add(due);
            this.Controls.Add(type);
            this.Controls.Add(ok);
        }

        public TextBox NameTextBox
        {
            get
            {
                return nameTextBox;
            }
        }
        public DateTimePicker Picker
        {
            get
            {
                return picker;
            }
        }
        public ComboBox TypeComboBox
        {
            get
            {
                return typeComboBox;
            }
        }

        public void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            //Upper-right arc:
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            //Lower-right arc:
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            //Lower-left arc:
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            //Upper-left arc:
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.FillPath(Brushes.Gray, gp);
            gp.Dispose();
        }

        public void keyDown(object senderm, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Dispose();
                    break;
                case Keys.Enter:
                    Console.WriteLine("enter");
                    break;
            }
        }

        void formMouseDown(object sender, MouseEventArgs e)
        {
            startPoint = this.PointToScreen(e.Location);
            formStartPoint = this.FindForm().Location;
            this.drag = true;
        }

        void formMouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        void formMouseMove(object sender, MouseEventArgs e)
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

        public void form_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundRect(e.Graphics, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width, e.ClipRectangle.Height, 5);
        }
    }
}