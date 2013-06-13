using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Reminder
{
    class Event : Panel
    {
        private Panel eventPanel;
        private Panel controlPanel;
        private List<EventClass> ec;
        private int position;
        private Label name;
        private Label subtitle;
        private Label date;
        private Label importance;

        public Event(List<EventClass> ec, int position)
        {
            this.ec = ec;
            this.position = position;

            if (ec[position].IsMultiEvent == false)
                setSingleEvent();
            else
                setMultiEvent();

            setControlPanel();

            eventPanel.Click += new EventHandler(eventPanel_MouseClick);
            controlPanel.Click += new EventHandler(controlPanel_MouseClick);
        }

        private void eventPanel_MouseClick(object sender, EventArgs e)
        {
            eventPanel.Visible = false;
            controlPanel.Visible = true;
        }

        private void controlPanel_MouseClick(object sender, EventArgs e)
        {
            eventPanel.Visible = true;
            controlPanel.Visible = false;
        }

        public void check_MouseClick(object sender, EventArgs e)
        {
            ec[position].IsFinished = true;
            EventWriter.SerializeToXML(ec);
            Control control = this.Parent;
            control.Controls.Clear();
            List<EventClass> ec2 = EventReader.DeserializeFromXML();
            int b = 0;
            int c = 0;
            for (int i = 0; i < ec2.Count; i++)
            {
                if (ec2[i].IsFinished != true)
                {
                    Event list = new Event(ec2, i);
                    if (ec2[i].IsMultiEvent == false)
                    {
                        list.Size = new Size(300 - 2, 60);
                        list.Location = new Point(0, (b++) * 60 + c * 90 + b + c - 1);
                    }
                    else
                    {
                        list.Size = new Size(300 - 2, 90);
                        list.Location = new Point(0, b * 60 + (c++) * 90 + b + c - 1);
                    }
                    control.Controls.Add(list);
                }
            }
        }

        public void check_MouseClick_Multi(object sender, EventArgs e)
        {
            ec[position].Eventlist.RemoveAt(0);
            if (ec[position].Eventlist.Count == 0)
            {
                ec[position].IsFinished = true;
                ec[position].IsMultiEvent = false;
                EventWriter.SerializeToXML(ec);
                Control control = this.Parent;
                control.Controls.Clear();
                List<EventClass> ec2 = EventReader.DeserializeFromXML();
                int b = 0;
                int c = 0;
                for (int i = 0; i < ec.Count; i++)
                {
                    if (ec2[i].IsFinished != true)
                    {
                        Event list = new Event(ec2, i);
                        if (ec2[i].IsMultiEvent == false)
                        {
                            list.Size = new Size(300 - 2, 60);
                            list.Location = new Point(0, (b++) * 60 + c * 90 + b + c - 1);
                        }
                        else
                        {
                            list.Size = new Size(300 - 2, 90);
                            list.Location = new Point(0, b * 60 + (c++) * 90 + b + c - 1);
                        }
                        control.Controls.Add(list);
                    }
                }
            }
            else
            {
                subtitle.Text = ec[position].Eventlist[0];
                eventPanel.Visible = true;
                controlPanel.Visible = false;
            }
        }

        public void delete_MouseClick(object sender, EventArgs e)
        {
            ec.RemoveAt(position);
            EventWriter.SerializeToXML(ec);
            Control control = this.Parent;
            control.Controls.Clear();
            List<EventClass> ec2 = EventReader.DeserializeFromXML();
            int b = 0;
            int c = 0;
            for (int i = 0; i < ec2.Count; i++)
            {
                if (ec2[i].IsFinished != true)
                {
                    Event list = new Event(ec2, i);
                    if (ec2[i].IsMultiEvent == false)
                    {
                        list.Size = new Size(300 - 2, 60);
                        list.Location = new Point(0, (b++) * 60 + c * 90 + b + c - 1);
                    }
                    else
                    {
                        list.Size = new Size(300 - 2, 90);
                        list.Location = new Point(0, b * 60 + (c++) * 90 + b + c - 1);
                    }
                    control.Controls.Add(list);
                }
            }
        }

        public void edit_MouseClick(object sender, EventArgs e)
        {
            CreateEventForm form = new CreateEventForm(ec[position]);
            ec.RemoveAt(position);
            EventWriter.SerializeToXML(ec);
            form.ShowDialog();
            Control control = this.Parent;
            control.Controls.Clear();
            List<EventClass> ec2 = EventReader.DeserializeFromXML();
            int b = 0;
            int c = 0;
            for (int i = 0; i < ec2.Count; i++)
            {
                if (ec2[i].IsFinished != true)
                {
                    Event list = new Event(ec2, i);
                    if (ec2[i].IsMultiEvent == false)
                    {
                        list.Size = new Size(300 - 2, 60);
                        list.Location = new Point(0, (b++) * 60 + c * 90 + b + c - 1);
                    }
                    else
                    {
                        list.Size = new Size(300 - 2, 90);
                        list.Location = new Point(0, b * 60 + (c++) * 90 + b + c - 1);
                    }
                    control.Controls.Add(list);
                }
            }
            eventPanel.Visible = true;
            controlPanel.Visible = false;
        }

        public void setSingleEvent()
        {
            setText();
            eventPanel.Size = new Size(300 - 2, 60);
            importance.Location = new Point(0, 30);
            date.Location = new Point(130, 30);

            name = new Label();
            name.Text = ec[position].Name;
            name.Location = new Point(0, 0);
            name.Size = new Size(300 - 2, 40);
            name.Font = new Font("微軟正黑體", 14F);
            name.Click += new EventHandler(eventPanel_MouseClick);
            eventPanel.Controls.Add(name);
        }

        public void setMultiEvent()
        {
            setText();

            name = new Label();
            name.Text = ec[position].Name;
            name.Size = new Size(300 - 2, 40);
            name.Font = new Font("微軟正黑體", 14F);
            name.Click += new EventHandler(eventPanel_MouseClick);

            subtitle = new Label();
            subtitle.Text = ec[position].Eventlist[0];
            subtitle.Size = new Size(200, 40);
            subtitle.Font = new Font("微軟正黑體", 13F);
            subtitle.Click += new EventHandler(eventPanel_MouseClick);

            eventPanel.Size = new Size(300 - 2, 90);
            subtitle.Location = new Point(0, 0);
            name.Location = new Point(0, 30);
            importance.Location = new Point(0, 55);
            date.Location = new Point(130, 55);

            eventPanel.Controls.Add(name);
            eventPanel.Controls.Add(subtitle);
        }

        public void setText()
        {
            eventPanel = new Panel();
            if (ec[position].Due < DateTime.Now)
                eventPanel.BackColor = Color.DimGray;
            else
                eventPanel.BackColor = Color.Green;
            eventPanel.Visible = true;

            importance = new Label();
            importance.Text = Convert.ToString(ec[position].Importance);
            importance.Size = new Size(50, 40);
            importance.Font = new Font("微軟正黑體", 13F);
            importance.Click += new EventHandler(eventPanel_MouseClick);

            date = new Label();
            date.Text = ec[position].Due.ToString("yyyy/MMM/dd H:mm");
            date.Size = new Size(300 - 2, 40);
            date.Font = new Font("微軟正黑體", 13F);
            date.Click += new EventHandler(eventPanel_MouseClick);

            eventPanel.Controls.Add(importance);
            eventPanel.Controls.Add(date);
            this.Controls.Add(eventPanel);
        }

        public void setControlPanel()
        {
            controlPanel = new Panel();
            controlPanel.BackColor = Color.DimGray;
            if (ec[position].IsMultiEvent == false)
                controlPanel.Size = new Size(300 - 2, 60);
            else
                controlPanel.Size = new Size(300 - 2, 90);
            controlPanel.Visible = false;

            PictureBox check = new PictureBox();
            PictureBox delete = new PictureBox();
            PictureBox edit = new PictureBox();
            check.Size = delete.Size = edit.Size = new Size(50, 50);

            check.Image = Image.FromFile("check.png");
            if (ec[position].IsMultiEvent == false)
                check.Click += new EventHandler(check_MouseClick);
            else
                check.Click += new EventHandler(check_MouseClick_Multi);

            delete.Image = Image.FromFile("delete.png");
            delete.Click += new EventHandler(delete_MouseClick);

            edit.Image = Image.FromFile("edit.png");
            edit.Click += new EventHandler(edit_MouseClick);

            if (ec[position].IsFinished == false)
            {
                if (ec[position].IsMultiEvent == false)
                {
                    check.Location = new Point(25, 5);
                    delete.Location = new Point(115, 5);
                    edit.Location = new Point(205, 5);
                }
                else
                {
                    check.Location = new Point(25, 20);
                    delete.Location = new Point(115, 20);
                    edit.Location = new Point(205, 20);
                }
            }
            else
            {
                check.Visible = false;
                delete.Visible = false;
                edit.Visible = false;
            }

            check.SizeMode = delete.SizeMode = edit.SizeMode = PictureBoxSizeMode.StretchImage;
            controlPanel.Controls.Add(check);
            controlPanel.Controls.Add(delete);
            controlPanel.Controls.Add(edit);
            this.Controls.Add(controlPanel);
        }
    }
}
