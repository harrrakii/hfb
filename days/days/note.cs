using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace days
{
    internal class note
    {
        public string name;
        public string desc;
        public string date;

        public note(string name, string desc, string date)
        {
            this.name = name;
            this.desc = desc;
            this.date = date;
        }
    }
}
