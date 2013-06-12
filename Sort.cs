using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    class Sort : SortInterface
    {
	private EventClass[] array;

	public Sort(EventClass[] array)
	{
	    this.array = array;
	}

	public EventClass[] sortByName()
	{
	    EventClass[] temp = array;
	    Array.Sort(temp, delegate(EventClass a, EventClass b)
	    {
		return a.Name.CompareTo(b.Name);
	    });
	    return temp;
	}

	public EventClass[] sortByIsFinished()
	{
	    EventClass[] temp = array;
	    Array.Sort(temp, delegate(EventClass a, EventClass b)
	    {
		return a.IsFinished.CompareTo(b.IsFinished);
	    });
	    return temp;
	}

	public EventClass[] sortByIsOverDated()
	{
	    EventClass[] temp = array;
	    Array.Sort(temp, delegate(EventClass a, EventClass b)
	    {
		return -a.IsOverDated.CompareTo(b.IsOverDated);
	    });
	    
	    return temp;
	}

	public EventClass[] sortByImportance()
	{
	    EventClass[] temp = array;
	    Array.Sort(temp, delegate(EventClass a, EventClass b)
	    {
		return -a.Importance.CompareTo(b.Importance);
	    });
	    return temp;
	}
	
	public EventClass[] sortByDueDate()
	{
	    EventClass[] temp = array;
	    Array.Sort(temp, delegate(EventClass a, EventClass b)
	    {
		return a.Due.CompareTo(b.Due);
	    });
	    return temp;
	}	
    }
}
