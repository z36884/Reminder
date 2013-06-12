using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

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
        PictureBox sort;

	private Panel listPanel;
	private int sortMethod = 1;

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
            adder.Location = new Point(0, 470);
            adder.MouseClick += adder_MouseClick;

            // sort 
            sort = new AddButton(30, 30);
            sort.Location = new Point(50, 470);
            sort.MouseClick += sort_MouseClick;
          
            // MainForm
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "MainForm";
            this.Size = new Size(300, 500);
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.Controls.Add(titleBar);
            this.Controls.Add(adder);
            this.Controls.Add(sort);

	    //Event
	    listPanel = new Panel();
	    listPanel.Size = new Size(300,500);
	    List<EventClass> ec = EventReader.DeserializeFromXML();
	    for(int i=0;i<ec.Count;i++)
	    {
		Event list = new Event(ec, i);
		list.Size = new Size(300, 60);
		list.Location = new Point(0, i*60+40);
		listPanel.Controls.Add(list);
	    }
	    listPanel.AutoScroll = true;
            this.Controls.Add(listPanel);

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

        public void sort_MouseClick(object sender, MouseEventArgs e)
        {
	    if(sortMethod == 1)
	    {
		sortMethod = 0;
		listPanel.Controls.Clear();
		List<EventClass> ec2 = EventReader.DeserializeFromXML();
		ec2.Sort((x,y) => {return x.Due.CompareTo(y.Due);});
		for(int i=0;i<ec2.Count;i++)
		{
		    Event list = new Event(ec2, i);
		    list.Size = new Size(300, 60);
		    list.Location = new Point(0, i*60+40);
		    listPanel.Controls.Add(list);
		}
	    }
	    else if(sortMethod == 0)
	    {
		sortMethod = 1;
		listPanel.Controls.Clear();
		List<EventClass> ec2 = EventReader.DeserializeFromXML();
		ec2.Sort((x,y) => {return -x.Importance.CompareTo(y.Importance);});
		for(int i=0;i<ec2.Count;i++)
		{
		    Event list = new Event(ec2, i);
		    list.Size = new Size(300, 60);
		    list.Location = new Point(0, i*60+40);
		    listPanel.Controls.Add(list);
		}
	    }
        }
    }
}
