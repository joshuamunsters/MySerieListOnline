using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySerieList.ViewModels
{
    public class EpisodeRatingViewModel
    {
        public int Serieid { get; set; }
        public EpisodeRating CreateRating { get; set; }

        public EpisodeRating GetEpisodeRating { get; set; } 
    }
}
