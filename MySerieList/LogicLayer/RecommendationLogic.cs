using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class RecommendationLogic
    {
        RecommendationRepository recommendationRepository = new RecommendationRepository();

        public List<Recommendation> GetRecommendatinsBySerieId(int serieid)
        {
            return recommendationRepository.GetRecommendatinsBySerieId(serieid);
        }

        public void CreateRecommendation(Recommendation recommendation)
        {
            recommendationRepository.CreateRecommendation(recommendation);
        }
    }
}
