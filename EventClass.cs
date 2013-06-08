using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    class EventClass : EventClassInterface
    {
	private string name;
	private int year;
	private int month;
	private int day;
	private int hour;
	private int minute;
	private int importance;
	private bool isFinished;
	private bool isOverDated;

	public EventClass(string name, int year, int month, int day, int hour, int minute, int importance, bool isFinished, bool isOverDated)
	{
	    this.name = name;
	    this.year = year;
	    this.month = month;
	    this.day = day;
	    this.hour = hour;
	    this.minute = minute;
	    this.importance = importance;
	    this.isFinished = isFinished;
	    this.isOverDated = isOverDated;
	}

	public string Name 
	{
	    get { return name; }
	    set { name = value; }
	}

	public int Year
	{
	    get { return year; }
	    set { year = value; }
	}

	public int Month
	{
	    get { return month; }
	    set { month = value; }
	}

	public int Day
	{
	    get { return day; }
	    set { day = value; }
	}

	public int Hour
	{
	    get { return hour; }
	    set { hour = value; }
	}

	public int Minute
	{
	    get { return minute; }
	    set { minute = value; }
	}

	public int Importance
	{
	    get { return importance; }
	    set { importance = value; }
	}

	public bool IsFinished
	{
	    get { return isFinished; }
	    set { isFinished = value; }
	}

	public bool IsOverDated
	{
	    get 
	    {
		DateTime saveNow = DateTime.Now;
		
		if((saveNow.Year>=year)&&(saveNow.Month>=month)&&(saveNow.Day>=day)&&(saveNow.Hour>=hour)&&(saveNow.Minute>=minute))
		    isOverDated = false;
		else
		    isOverDated = true;
		return isOverDated;
	    }
	    set { }
	}
    }
}
