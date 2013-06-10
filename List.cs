using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Reminder
{
    class List : Panel
    {
	public List()
	{
	    Label name = new Label();
	    name.Text = "TestName";
	    name.Location = new Point(0, 0);
	    name.Size = new Size(300, 40);
	    name.Font = new Font("Segoe Script", 20F);

	    Label importance = new Label();
	    importance.Text = "3";
	    importance.Location = new Point(0, 30);
	    importance.Size = new Size(50, 40);
	    importance.Font = new Font("Segoe Script", 16F);

	    Label date = new Label();
	    date.Text = "2013/11/27";
	    date.Location = new Point(60, 30);
	    date.Size = new Size(250, 40);
	    date.Font = new Font("Segoe Script", 16F);

	    //list.MouseDown += listBarMouseDown;
	    //list.MouseUp += listBarMouseUp;
	    this.MouseEnter += new EventHandler(Action_MouseEnter);

	    this.Controls.Add(name);
	    this.Controls.Add(importance);
	    this.Controls.Add(date);
	}

	private void Action_MouseEnter(object sender, EventArgs e)
	{
	    System.Console.WriteLine("AAA");
	}
}
