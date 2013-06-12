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

	public Event(List<EventClass> ec, int position)
	{
	    this.ec = ec;
	    this.position = position;

	    eventPanel = new Panel();
	    if(ec[position].IsOverDated == true)
		eventPanel.BackColor = Color.Green;
	    else
		eventPanel.BackColor = Color.Blue;
	    eventPanel.Visible = true;
	    eventPanel.Size = new Size(300,60);

	    Label name = new Label();
	    name.Text = ec[position].Name;
	    name.Location = new Point(0, 0);
	    name.Size = new Size(300, 40);
	    name.Font = new Font("Segoe Script", 20F);
	    name.Click += new EventHandler(eventPanel_MouseClick);

	    Label importance = new Label();
	    importance.Text = Convert.ToString(ec[position].Importance); 
	    importance.Location = new Point(0, 30);
	    importance.Size = new Size(50, 40);
	    importance.Font = new Font("Segoe Script", 16F);
	    importance.Click += new EventHandler(eventPanel_MouseClick);

	    Label date = new Label();
	    date.Text = Convert.ToString(ec[position].Due);
	    date.Location = new Point(60, 30);
	    date.Size = new Size(300, 40);
	    date.Font = new Font("Segoe Script", 16F);
	    date.Click += new EventHandler(eventPanel_MouseClick);

	    eventPanel.Controls.Add(name);
	    eventPanel.Controls.Add(importance);
	    eventPanel.Controls.Add(date);
	    this.Controls.Add(eventPanel);


	    controlPanel = new Panel();
	    controlPanel.BackColor = Color.Red;
	    controlPanel.Size = new Size(300,60);
	    controlPanel.Visible = false;

	    PictureBox check = new PictureBox();
	    check.Image = Image.FromFile("check.png");
            check.Location = new Point(10, 5);
            check.Size = new Size(50, 50);
	    check.SizeMode = PictureBoxSizeMode.StretchImage;
	    check.Click += new EventHandler(check_MouseClick);

	    PictureBox delete = new PictureBox();
	    delete.Image = Image.FromFile("delete.png");
            delete.Location = new Point(70, 5);
            delete.Size = new Size(50, 50);
	    delete.SizeMode = PictureBoxSizeMode.StretchImage;
	    delete.Click += new EventHandler(delete_MouseClick);

	    PictureBox edit = new PictureBox();
	    edit.Image = Image.FromFile("edit.png");
            edit.Location = new Point(130, 5);
            edit.Size = new Size(50, 50);
	    edit.SizeMode = PictureBoxSizeMode.StretchImage;
	    edit.Click += new EventHandler(edit_MouseClick);

	    controlPanel.Controls.Add(check);
	    controlPanel.Controls.Add(delete);
	    controlPanel.Controls.Add(edit);
	    this.Controls.Add(controlPanel);

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
	    for(int i=0;i<ec.Count;i++)
	    {
		if(ec[i].IsFinished != true)
		{
		    Event list = new Event(ec2, i);
		    list.Size = new Size(300, 60);
		    list.Location = new Point(0, (b++)*60+40);
		    control.Controls.Add(list);
		}
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
	    for(int i=0;i<ec.Count;i++)
	    {
		if(ec[i].IsFinished != true)
		{
		    Event list = new Event(ec2, i);
		    list.Size = new Size(300, 60);
		    list.Location = new Point(0, (b++)*60+40);
		    control.Controls.Add(list);
		}
	    }
	}

	public void edit_MouseClick(object sender, EventArgs e)
	{
	    System.Console.WriteLine("ccc");	
	    eventPanel.Visible = true;
	    controlPanel.Visible = false;
	}

    }
}
