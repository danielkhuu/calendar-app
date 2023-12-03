using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp
{
    public class Event
    {
        public Event(string name, string description, int calendarDayId)
        {
            this.name = name;
            this.description = description;
            this.calendarDayId = calendarDayId; 
        }
        public Event()
        {
            name = null;
            description = null;
            calendarDayId = 0;
        }
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int calendarDayId { get; set; }

    }
}
