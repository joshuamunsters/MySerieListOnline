using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySerieList.ViewModels
{
    public class WatchListViewModel
    {
        public List<WatchListSerie> Series { get; set; }

        public WatchListSerie Serie { get; set; }

        public List<Serie> MostPopularSeries { get; set; }
    }
}
