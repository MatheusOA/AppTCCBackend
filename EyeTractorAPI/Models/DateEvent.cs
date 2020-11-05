using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeTractorAPI.Models
{
    public class DateEvent
    {
        public string Date { get; set; }
        public int Fatigue { get; set; }
        public int Distraction { get; set; }

        public DateEvent(string _date)
        {
            Date = _date;
        }
    }
}
