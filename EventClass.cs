using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    public class EventClass : EventClassInterface
    {
        private string name;
        private DateTime due;
        private String dueString;
        private int importance;
        private bool isFinished;
        private bool isOverDated;
        private bool isMultiEvent;
        private List<String> eventlist;

        public EventClass()
        {
        }

        public EventClass(string name, DateTime due, int importance, bool isFinished, bool isMultiEvent, List<String> eventlist)
        {
            this.name = name;
            this.due = due;
            this.dueString = due.ToString("yyyy/MMM/dd   H:mm");
            this.importance = importance;
            this.isFinished = isFinished;
            if (due <= DateTime.Now)
                this.isOverDated = true;
            else
                this.isOverDated = false;
            this.isMultiEvent = isMultiEvent;
            this.eventlist = eventlist;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime Due
        {
            get { return due; }
            set { due = value; }
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
                return DateTime.Now >= due;
            }
        }

        public bool IsMultiEvent
        {
            get { return isMultiEvent; }
            set { isMultiEvent = value; }
        }

        public List<String> Eventlist
        {
            get { return eventlist; }
        }

        public int ArraylistNumber
        {
            get { return Eventlist.Count; }
        }
    }
}
