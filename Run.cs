using System;
using System.Windows.Forms;

namespace Reminder
{
    public class Run
    {
        static void Main()
        {
	    EventClass[] test = new EventClass[5];
	    EventClass temp = new EventClass("Eimmy",2020,11,29,5,10,2,false);
	    test[0] = temp;
	    temp = new EventClass("Jimmy",2012,7,29,5,10,2,false);
	    test[1] = temp;
	    temp = new EventClass("Stanlet",2013,7,2,8,40,1,false);
	    test[2] = temp;
	    temp = new EventClass("Apple",2011,12,2,5,10,3,false);
	    test[3] = temp;
	    temp = new EventClass("Banaa",2012,11,30,5,10,1,false);
	    test[4] = temp;

	    Sort sorttemplate = new Sort(test);
	    EventClass[] result = new EventClass[5];
	    result = sorttemplate.sortByIsOverDated();
	    foreach(EventClass en in result)
	    {
		System.Console.WriteLine(en.Name+en.IsOverDated);
	    }

            MainForm form = new MainForm();
            Application.Run(form);

	
        }
    }
}
