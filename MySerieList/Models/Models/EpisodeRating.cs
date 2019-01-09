using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class EpisodeRating
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public Episode Episode { get; set; }

        public int Userid { get; set; }

    }
}
