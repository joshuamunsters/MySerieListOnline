using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IReviewContext
    {
        void SendReview(Review review);

        List<Review> GetReviewBySerie(int serieid);
    }
}