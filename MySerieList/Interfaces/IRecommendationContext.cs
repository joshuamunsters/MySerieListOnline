using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface IRecommendationContext
    {
        List<Recommendation> GetRecommendatinsBySerieId(int serieid);

        void CreateRecommendation(Recommendation recommendation);
    }
}