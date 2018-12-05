using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Serie
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string overallrating { get; set; }

        public string thumbnail { get; set; }

        public int categoryid { get; set; }

        public virtual Category Category { get; set; }


    }
}
