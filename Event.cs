using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Reminder
{
    class Event : Panel
    {
	private Panel eventPanel;
	private Panel Controler;
	private EventClass ec;

	public Event(EventClass ec)
	{
	    this.ec = ec;

	    eventPanel = new Panel();
            eventPanel.BackColor = Color.Blue;
	    eventPanel.Visible = true;
	    eventPanel.Size = new Size(300,60);

	    Label name = new Label();
	    name.Text = ec.Name;
	    name.Location = new Point(0, 0);
	    name.Size = new Size(300, 40);
	    name.Font = new Font("Segoe Script", 20F);
	    name.Click += new EventHandler(Event_MouseClick);

	    Label importance = new Label();
	    importance.Text = Convert.ToString(ec.Importance); 
	    importance.Location = new Point(0, 30);
	    importance.Size = new Size(50, 40);
	    importance.Font = new Font("Segoe Script", 16F);
	    importance.Click += new EventHandler(Event_MouseClick);

	    Label date = new Label();
	    date.Text = Convert.ToString(ec.Due);
	    date.Location = new Point(60, 30);
	    date.Size = new Size(300, 40);
	    date.Font = new Font("Segoe Script", 16F);
	    date.Click += new EventHandler(Event_MouseClick);

	    eventPanel.Controls.Add(name);
	    eventPanel.Controls.Add(importance);
	    eventPanel.Controls.Add(date);
	    this.Controls.Add(eventPanel);


	    Controler = new Panel();
	    Controler.BackColor = Color.Red;
	    Controler.Size = new Size(300,60);
	    Controler.Visible = false;
	    this.Controls.Add(Controler);

	    PictureBox check = new PictureBox();
	    check.Image = Image.FromFile("check.png");
            check.Location = new Point(10, 5);
            check.Size = new Size(50, 50);
	    check.SizeMode = PictureBoxSizeMode.StretchImage;
	    Controler.Controls.Add(check);

	    PictureBox delete = new PictureBox();
	    delete.Image = Image.FromFile("delete.png");
            delete.Location = new Point(70, 5);
            delete.Size = new Size(50, 50);
	    delete.SizeMode = PictureBoxSizeMode.StretchImage;
	    Controler.Controls.Add(delete);

	    PictureBox edit = new PictureBox();
	    edit.Image = Image.FromFile("edit.png");
            edit.Location = new Point(130, 5);
            edit.Size = new Size(50, 50);
	    edit.SizeMode = PictureBoxSizeMode.StretchImage;
	    Controler.Controls.Add(edit);

	    eventPanel.Click += new EventHandler(Event_MouseClick);
	    Controler.Click += new EventHandler(Controler_MouseClick);
	}

	private void Event_MouseClick(object sender, EventArgs e)
	{
	    eventPanel.Visible = false;
	    Controler.Visible = true;
	}

	private void Controler_MouseClick(object sender, EventArgs e)
	{       
	    eventPanel.Visible = true;
	    Controler.Visible = false;
	}
    }
}
