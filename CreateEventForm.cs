using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace Reminder
{
    public class CreateEventForm : Form
    {
        private const int groupboxWidth = 250;

        GroupBox title, due, importance, type, series;
        TextBox nameTextBox;
        TextBox[] seriesTextBox;
        DateTimePicker picker;
        ComboBox typeComboBox, importanceComboBox;
        Button ok;
        bool drag;
        Point startPoint;
        Point formStartPoint;
        CloseButton closeButton;
        PictureBox prev, next;
        List<String> events;
        int curNum, totalNum;

        public CreateEventForm()
        {
            InitializeComponent();
        }

        public CreateEventForm(EventClass ec)
        {
            InitializeComponent();
            nameTextBox.Text = ec.Name;
            picker.Value = ec.Due;
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

        public void InitializeComponent()
        {
            title = new GroupBox();
            due = new GroupBox();
            importance = new GroupBox();
            type = new GroupBox();
            series = new GroupBox();

            // closeButton
            closeButton = new CloseButton(20, 20);
            closeButton.Location = new Point(260, 10);

            #region title
            // name textbox
            nameTextBox = new TextBox();
            nameTextBox.Location = new Point(25, 30);
            nameTextBox.Size = new Size(200, 10);
            nameTextBox.Font = new Font(nameTextBox.Font.FontFamily, 12F);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.KeyDown += keyDown;
            nameTextBox.MaxLength = 20;

            // name group box
            title.Location = new Point(10, 25);
            title.BackColor = Color.Gray;
            title.Size = new Size(groupboxWidth, 80);
            title.Name = "title";
            title.Text = "Title";
            title.Font = new Font(title.Font.FontFamily, 20F);
            title.Controls.Add(nameTextBox);
            #endregion

            #region due
            // due date time picker
            picker = new DateTimePicker();
            picker.Location = new Point(25, 30);
            picker.Font = new Font(picker.Font.FontFamily, 12F);
            picker.Name = "picker";
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = "yyyy.MMM.dd   H:mm";
            picker.KeyDown += keyDown;

            // due group box
            due.Location = new Point(10, 110);
            due.BackColor = Color.Gray;
            due.Size = new Size(groupboxWidth, 80);
            due.Name = "due";
            due.Text = "Due";
            due.Font = new Font(due.Font.FontFamily, 20F);
            due.Controls.Add(picker);
            #endregion

            #region importance
            // importance combo box
            importanceComboBox = new ComboBox();
            importanceComboBox.Location = new Point(25, 30);
            importanceComboBox.Font = new Font(importanceComboBox.Font.FontFamily, 12F);
            importanceComboBox.Name = "importanceComboBox";
            importanceComboBox.Items.Add("Whatever");
            importanceComboBox.Items.Add("Normal");
            importanceComboBox.Items.Add("Important");
            importanceComboBox.SelectedIndex = 1;
            importanceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            importanceComboBox.KeyDown += keyDown;

            // importance group box
            importance.Location = new Point(10, 195);
            importance.BackColor = Color.Gray;
            importance.Size = new Size(groupboxWidth, 80);
            importance.Name = "importance";
            importance.Text = "Importance";
            importance.Font = new Font(importance.Font.FontFamily, 20F);
            importance.Controls.Add(importanceComboBox);
            #endregion

            #region type
            // type combo box
            typeComboBox = new ComboBox();
            typeComboBox.Location = new Point(25, 30);
            typeComboBox.Font = new Font(typeComboBox.Font.FontFamily, 12F);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Items.Add("Single");
            typeComboBox.Items.Add("Multiple");
            typeComboBox.SelectedIndex = 0;
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeComboBox.KeyDown += keyDown;
            typeComboBox.SelectedIndexChanged += typeComboBox_SelectedIndexChanged;

            // type group box
            type.Location = new Point(10, 280);
            type.BackColor = Color.Gray;
            type.Size = new Size(groupboxWidth, 80);
            type.Name = "type";
            type.Text = "Type";
            type.Font = new Font(type.Font.FontFamily, 20F);
            type.Controls.Add(typeComboBox);
            #endregion

            #region button
            // button
            ok = new Button();
            ok.BackColor = Color.Red;
            ok.Location = new Point(10, 365);
            ok.Size = new Size(groupboxWidth, 80);
            ok.Name = "ok";
            ok.Text = "Add";
            ok.Click += ok_Click;
            #endregion

            #region series
            // series
            prev = new PictureBox();
            prev.Location = new Point(5, 30);
            prev.Size = new Size(20, 20);
            prev.BackColor = Color.Honeydew;
            prev.Visible = false;
            prev.Click += prev_Click;

            next = new PictureBox();
            next.Location = new Point(195, 30);
            next.Size = new Size(20, 20);
            next.BackColor = Color.Honeydew;
            next.Visible = false;
            next.Click += next_Click;

            curNum = totalNum = 1;

            seriesTextBox = new TextBox[101];
            seriesTextBox[1] = new TextBox();
            seriesTextBox[1].Location = new Point(25, 30);
            seriesTextBox[1].KeyUp += seriesTextBox_KeyUp;

            series.Text = "Events 1/1";
            series.Location = new Point(10, 365);
            series.Size = new Size(groupboxWidth, 80);
            series.Font = new Font(typeComboBox.Font.FontFamily, 20F);
            series.BackColor = Color.Gray;
            series.Controls.Add(prev);
            series.Controls.Add(next);
            series.Controls.Add(seriesTextBox[1]);
            series.Visible = false;
            #endregion

            // CreateEventForm
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(270, 470);
            this.MouseDown += formMouseDown;
            this.MouseUp += formMouseUp;
            this.MouseMove += formMouseMove;
            this.BackColor = Color.Gray;
            this.Controls.Add(closeButton);
            this.Controls.Add(title);
            this.Controls.Add(due);
            this.Controls.Add(importance);
            this.Controls.Add(type);
            this.Controls.Add(ok);
            this.Controls.Add(series);
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

        void ok_Click(object sender, EventArgs e)
        {
            EventClass newEvent;
            int importanceNum = 1;
            List<EventClass> elist = new List<EventClass>();
            try
            {
                elist = EventReader.DeserializeFromXML();
            }
            catch { }
            switch ((String)importanceComboBox.SelectedItem)
            {
                case "Whatever":
                    importanceNum = 0;
                    break;
                case "Normal":
                    importanceNum = 1;
                    break;
                case "Important":
                    importanceNum = 2;
                    break;
            }
            switch ((String)typeComboBox.SelectedItem)
            {
                case "Single":
                    newEvent = new EventClass(nameTextBox.Text, picker.Value, importanceNum, false, false, null);
                    elist.Add(newEvent);
                    break;
                case "Multiple":
                    events = new List<string>();
                    for (int i = 1; i <= totalNum; i++)
                        if (seriesTextBox[i].Text != "")
                            events.Add(seriesTextBox[i].Text);
                    newEvent = new EventClass(nameTextBox.Text, picker.Value, importanceNum, false, true, events);
                    elist.Add(newEvent);
                    break;
            }
            EventWriter.SerializeToXML(elist);
            this.Close();
        }

        void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((String)typeComboBox.SelectedItem)
            {
                case "Single":
                    series.Visible = false;
                    this.Size = new Size(270, 470);
                    ok.Location = new Point(10, 280);
                    Application.DoEvents();
                    break;
                case "Multiple":
                    series.Visible = true;
                    this.Size = new Size(270, 555);
                    ok.Location = new Point(10, 450);
                    Application.DoEvents();
                    break;
            }
        }

        void seriesTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "" || curNum == 100)
                next.Visible = false;
            else
                next.Visible = true;
        }

        void prev_Click(object sender, EventArgs e)
        {
            seriesTextBox[curNum--].Visible = false;
            seriesTextBox[curNum].Visible = true;
            seriesTextBox[curNum].Focus();
            next.Visible = true;
            if (curNum == 1)
                prev.Visible = false;
            series.Text = "Series " + curNum + "/" + totalNum;
        }

        void next_Click(object sender, EventArgs e)
        {
            seriesTextBox[curNum++].Visible = false;
            prev.Visible = true;
            if (curNum > totalNum)
            {
                totalNum++;
                seriesTextBox[totalNum] = new TextBox();
                seriesTextBox[totalNum].Location = new Point(25, 30);
                seriesTextBox[totalNum].KeyUp += seriesTextBox_KeyUp;
                series.Controls.Add(seriesTextBox[totalNum]);
                next.Visible = false;
            }
            else
                seriesTextBox[curNum].Visible = true;
            seriesTextBox[curNum].Focus();
            if (seriesTextBox[curNum].Text == "" || curNum == 100)
                next.Visible = false;
            else
                next.Visible = true;
            series.Text = "Series " + curNum + "/" + totalNum;
        }
    }
}