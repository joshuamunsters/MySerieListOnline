using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class RecommendationRepository
    {

        IRecommendationContext recommendationContext = new RecommendationContext();

        public List<Recommendation> GetRecommendatinsBySerieId(int serieid)
        {
            return recommendationContext.GetRecommendatinsBySerieId(serieid);
        }

        public void CreateRecommendation(Recommendation recommendation)
        {
            recommendationContext.CreateRecommendation(recommendation);
        }

    }
}
