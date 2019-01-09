using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class WatchListSerie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Status { get; set; }

        public string EpisodesSeen { get; set; }

        public int Rating { get; set; }

        public User User { get; set; }

        public int SerieId { get; set; }
       





    }
}
