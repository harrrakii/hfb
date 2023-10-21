using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace days
{
    internal class everyDay
    {
        public string date;
        public List<note> dayNotes = new List<note>();

        public everyDay(string date, List<note> dayNotes)
        {
            this.date = date;
            this.dayNotes = dayNotes;
        }
    }
}
