using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    interface SortInterface
    {
	EventClass[] sortByName();

	EventClass[] sortByIsFinished();

	EventClass[] sortByIsOverDated();

	EventClass[] sortByImportance();
    }

}
