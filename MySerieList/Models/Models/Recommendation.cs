using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Recommendation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Serieid1 { get; set; }

        public int Serieid2 { get; set; }

        public int Userid { get; set; }

    }
}
