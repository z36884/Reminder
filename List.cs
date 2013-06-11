using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Reminder
{
    class List : Panel
    {
	private Panel Event;
	private Panel Controler;

	public List()
	{
	    Event = new Panel();
            Event.BackColor = Color.Blue;
	    Event.Visible = true;
	    Event.Size = new Size(300,60);

	    Label name = new Label();
	    name.Text = "TestName";
	    name.Location = new Point(0, 0);
	    name.Size = new Size(300, 40);
	    name.Font = new Font("Segoe Script", 20F);
	    name.Click += new EventHandler(Event_MouseClick);

	    Label importance = new Label();
	    importance.Text = "3";
	    importance.Location = new Point(0, 30);
	    importance.Size = new Size(50, 40);
	    importance.Font = new Font("Segoe Script", 16F);
	    importance.Click += new EventHandler(Event_MouseClick);

	    Label date = new Label();
	    date.Text = "2013/11/27";
	    date.Location = new Point(60, 30);
	    date.Size = new Size(300, 40);
	    date.Font = new Font("Segoe Script", 16F);
	    date.Click += new EventHandler(Event_MouseClick);

	    Event.Controls.Add(name);
	    Event.Controls.Add(importance);
	    Event.Controls.Add(date);
	    this.Controls.Add(Event);


	    Controler = new Panel();
	    Controler.BackColor = Color.Red;
	    Controler.Size = new Size(300,60);
	    Controler.Visible = false;
	    this.Controls.Add(Controler);

	    Event.Click += new EventHandler(Event_MouseClick);
	    Controler.Click += new EventHandler(Controler_MouseClick);
	}

	private void Event_MouseClick(object sender, EventArgs e)
	{
	    Event.Visible = false;
	    Controler.Visible = true;
	}

	private void Controler_MouseClick(object sender, EventArgs e)
	{
	    Event.Visible = true;
	    Controler.Visible = false;
	}
    }
}
