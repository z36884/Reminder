using System;
using System.Windows.Forms;
using System.Drawing;

namespace Reminder
{
    public class CreateEventForm : Form
    {
        GroupBox title, due, type, series;
        TextBox nameTextBox;
        DateTimePicker picker;
        ComboBox typeComboBox;
        Button ok;
        private const int groupboxWidth = 250;

        public CreateEventForm()
        {
            title = new GroupBox();
            due = new GroupBox();
            type = new GroupBox();

            // name textbox
            nameTextBox = new TextBox();
            nameTextBox.Location = new Point(5, 20);
            nameTextBox.Name = "nameTextBox";

            // name group box
            title.Location = new Point(10, 10);
            title.Size = new Size(groupboxWidth, 50);
            title.Name = "title";
            title.Text = "Title";
            title.Controls.Add(nameTextBox);

            // due date time picker
            picker = new DateTimePicker();
            picker.Location = new Point(5, 20);
            picker.Name = "picker";
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = "yyyy.MMM.dd   hh:mm:ss";

            // due group box
            due.Location = new Point(10, 70);
            due.Size = new Size(groupboxWidth, 50);
            due.Name = "due";
            due.Text = "Due";
            due.Controls.Add(picker);

            // type combo box
            typeComboBox = new ComboBox();
            typeComboBox.Location = new Point(5, 20);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Items.Add("Single");
            typeComboBox.Items.Add("Multiple");

            // type group box
            type.Location = new Point(10, 130);
            type.Size = new Size(groupboxWidth, 50);
            type.Name = "type";
            type.Text = "Type";
            type.Controls.Add(typeComboBox);

            // buttons group box
            Button ok = new Button();
            ok.Location = new Point(10, 200);
            ok.Name = "ok";
            ok.Text = "Add";

            // CreateEventForm
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
    }
}