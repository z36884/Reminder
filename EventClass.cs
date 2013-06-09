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

	public EventClass(string name, int year, int month, int day, int hour, int minute, int importance, bool isFinished)
	{
	    this.Name = name;
	    this.Year = year;
	    this.Month = month;
	    this.Day = day;
	    this.Hour = hour;
	    this.Minute = minute;
	    this.Importance = importance;
	    this.IsFinished = isFinished;
	    this.IsOverDated = true;
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
	    get { return isOverDated; }
	    set 
	    {
		DateTime saveNow = DateTime.Now;
		long r1,r2;
		r1 = year*100000000+month*1000000+day*10000+hour*100+minute;
		r2 = saveNow.Year*100000000+saveNow.Month*1000000+saveNow.Day*10000+saveNow.Hour*100+saveNow.Minute;
		if(r1<r2)
		    isOverDated = true;
		else
		    isOverDated = false;
	    }
	}
    }
}
