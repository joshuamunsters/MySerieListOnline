using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class ReviewLogic
    {
        ReviewRepository reviewRepository = new ReviewRepository();

        public void SendReview(Review review)
        {
            reviewRepository.SendReview(review);
        }

        public List<Review> GetReviewBySerie(int serieid)
        {
            return reviewRepository.GetReviewBySerie(serieid);
        }

    }
}
