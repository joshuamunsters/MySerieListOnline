using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    class WatchList
    {
        public int Id { get; set; }

        public List<WatchListSerie> WatchListSeries { get; set; }

    }
}
