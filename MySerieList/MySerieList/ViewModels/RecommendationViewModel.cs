using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySerieList.ViewModels
{
    public class RecommendationViewModel
    {
        public int Serieid;
        public List<Recommendation> GetRecommendations { get; set; }

        public IEnumerable<Serie> GetSerieNames { get; set; }

        public Recommendation CreateRecommendation { get; set; }
    }
}
