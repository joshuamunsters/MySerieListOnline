using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySerieList.ViewModels
{
    public class EpisodeRatingViewModel
    {
   
        public int SerieId { get; set; }
        public int EpisodeId { get; set; }
        public EpisodeRating CreateRating { get; set; }

        public EpisodeRating GetEpisodeRating { get; set; } 


        public List<EpisodeRating> RatingChart { get; set; }
    }
}
