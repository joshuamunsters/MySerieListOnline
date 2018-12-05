using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class ReviewRepository
    {
        IReviewContext _reviewContext = new ReviewContext();

        public void SendReview(Review review)
        {
            _reviewContext.SendReview(review);
        }

    }
}
