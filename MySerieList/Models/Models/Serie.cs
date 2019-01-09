using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Serie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Overallrating { get; set; }

        public string Thumbnail { get; set; }

        public Category Category { get; set; }


    }
}
