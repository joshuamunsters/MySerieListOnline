using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySerieList.ViewModels
{
    public class SeriePageViewModel
    {
        public Serie SelectedSerie { get; set; }

        public Review SendReview { get; set; } 

        public WatchListViewModel WatchList { get; set; }

        public List<Episode> Episodes { get; set; }
    }
}
