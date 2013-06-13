using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Reminder
{

    public partial class MainForm
    {
	private const int MainFormWidth = 300;
	private const int MainFormHeight = 500;

	TitleBar titleBar;
	PictureBox adder;
	PictureBox sort;
	PictureBox finish;

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
	    sort.Image = Image.FromFile("sort.png");
	    sort.Location = new Point(50, 470);
	    sort.MouseClick += sort_MouseClick;

	    // finish 
	    finish = new AddButton(30, 30);
	    finish.Image = Image.FromFile("finish.png");
	    finish.Location = new Point(100, 470);
	    finish.MouseClick += finish_MouseClick;

	    sort.SizeMode = finish.SizeMode =  PictureBoxSizeMode.StretchImage;

	    // MainForm
	    this.FormBorderStyle = FormBorderStyle.None;
	    this.Name = "MainForm";
	    this.Size = new Size(300, 500);
	    this.BackColor = Color.FromArgb(45, 45, 48);
	    this.Controls.Add(titleBar);
	    this.Controls.Add(adder);
	    this.Controls.Add(sort);
	    this.Controls.Add(finish);

	    //Event
	    listPanel = new Panel();
	    listPanel.Size = new Size(300, 500);
	    try
	    {
		List<EventClass> ec = EventReader.DeserializeFromXML();
		int b = 0;
		int c = 0;
		for (int i = 0; i < ec.Count; i++)
		{
		    if(ec[i].IsFinished != true)
		    {
			Event list = new Event(ec, i);
			if(ec[i].IsMultiEvent == false)
			{
			    list.Size = new Size(300, 60);
			    list.Location = new Point(0, (b++) * 60 + c * 90 + 40);
			}
			else
			{
			    list.Size = new Size(300, 90);
			    list.Location = new Point(0, b * 60 + (c++) * 90 + 40 );
			}
			listPanel.Controls.Add(list);
		    }
		}
	    }
	    catch { }
	    listPanel.AutoScroll = true;
	    this.Controls.Add(listPanel);

	    this.ResumeLayout(false);
	}

	public void adder_MouseClick(object sender, MouseEventArgs e)
	{
	    CreateEventForm form = new CreateEventForm();
	    form.ShowDialog();
	    Sort();
	}

	public void sort_MouseClick(object sender, MouseEventArgs e)
	{
	    Sort();
	}

	public void finish_MouseClick(object sender, MouseEventArgs e)
	{
	    listPanel.Controls.Clear();
	    List<EventClass> ec2 = EventReader.DeserializeFromXML();
	    int b = 0;
	    int c = 0;
	    for (int i = 0; i < ec2.Count; i++)
	    {
		if(ec2[i].IsFinished == true)
		{
		    Event list = new Event(ec2, i);
		    if(ec2[i].IsMultiEvent == false)
		    {
			list.Size = new Size(300, 60);
			list.Location = new Point(0, (b++) * 60 + c * 90 + 40);
		    }
		    else
		    {
			list.Size = new Size(300, 90);
			list.Location = new Point(0, b * 60 + (c++) * 90 + 40 );
		    }
		    listPanel.Controls.Add(list);
		}
	    }
	}

	public void Sort()
	{
	    if (sortMethod == 1)
	    {
		sortMethod = 0;
		listPanel.Controls.Clear();
		List<EventClass> ec2 = EventReader.DeserializeFromXML();
		ec2.Sort((x, y) => { return x.Due.CompareTo(y.Due); });
		int b = 0;
		int c = 0;
		for (int i = 0; i < ec2.Count; i++)
		{
		    if(ec2[i].IsFinished != true)
		    {
			Event list = new Event(ec2, i);
			if(ec2[i].IsMultiEvent == false)
			{
			    list.Size = new Size(300, 60);
			    list.Location = new Point(0, (b++) * 60 + c * 90 + 40);
			}
			else
			{
			    list.Size = new Size(300, 90);
			    list.Location = new Point(0, b * 60 + (c++) * 90 + 40 );
			}
			listPanel.Controls.Add(list);
		    }
		}
	    }
	    else if (sortMethod == 0)
	    {
		sortMethod = 1;
		listPanel.Controls.Clear();
		List<EventClass> ec2 = EventReader.DeserializeFromXML();
		ec2.Sort((x, y) => { return -x.Importance.CompareTo(y.Importance); });
		int b = 0;
		int c = 0;
		for (int i = 0; i < ec2.Count; i++)
		{
		    if(ec2[i].IsFinished != true)
		    {
			Event list = new Event(ec2, i);
			if(ec2[i].IsMultiEvent == false)
			{
			    list.Size = new Size(300, 60);
			    list.Location = new Point(0, (b++) * 60 + c * 90 + 40);
			}
			else
			{
			    list.Size = new Size(300, 90);
			    list.Location = new Point(0, b * 60 + (c++) * 90 + 40 );
			}
			listPanel.Controls.Add(list);
		    }
		}
	    }
	}
    }
}
