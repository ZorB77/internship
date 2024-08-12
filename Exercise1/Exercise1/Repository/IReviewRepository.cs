using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Repository
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAllReviews();
        Review GetReviewById(int id);
        void AddReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int id);
        IEnumerable<Review> GetReviewByMovie(string movieName);
        IEnumerable<Review> GetAllReviewsByRating(int rating);
        IEnumerable<Review> GetAllReviewsByKeywords(string keywords);
        double AverageRating(string movieName);

    }
    
}
