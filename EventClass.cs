using System;
using System.Collections;
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
	private long dateNumber;
	private int importance;
	private bool isFinished;
	private bool isOverDated;
	private bool isEvent;
	private ArrayList arraylist = new ArrayList();
	private int arraylistNumber;

	public EventClass(string name, int year, int month, int day, int hour, int minute, int importance, bool isFinished, bool isEvent)
	{
	    this.Name = name;
	    this.Year = year;
	    this.Month = month;
	    this.Day = day;
	    this.Hour = hour;
	    this.Minute = minute;
	    this.DateNumber = 0;
	    this.Importance = importance;
	    this.IsFinished = isFinished;
	    this.IsOverDated = true;
	    this.IsEvent = isEvent;
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

	public long DateNumber 
	{
	    get { return dateNumber; }
	    set { dateNumber = year*100000000+month*1000000+day*10000+hour*100+minute; }
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
		long r2 = saveNow.Year*100000000+saveNow.Month*1000000+saveNow.Day*10000+saveNow.Hour*100+saveNow.Minute;
		if(dateNumber<r2)
		    isOverDated = true;
		else
		    isOverDated = false;
	    }
	}

	public bool IsEvent
	{
	    get { return isEvent; }
	    set { isEvent = value; }
	}

	public ArrayList Arraylist 
	{
	    get { return arraylist; }
	    set { arraylist.Add(value); }
	}

	public int ArraylistNumber
	{
	    get { return arraylist.Count; }
	    set { }
	}
    }
}
