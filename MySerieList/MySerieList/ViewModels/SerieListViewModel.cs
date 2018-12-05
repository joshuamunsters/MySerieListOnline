using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySerieList.ViewModels
{
    public class SerieListViewModel
    {
        public IEnumerable<Serie> Series { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public string CurrentCategory { get; set; }

        public Serie SearchedSerie { get; set; }
    }
}
