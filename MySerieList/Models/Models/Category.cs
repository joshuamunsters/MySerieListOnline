using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Category
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public List<Serie> Series { get; set; }


    }
}
