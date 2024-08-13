using Exercise1.ConfigDatabase;
using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Repository
{
    public class ReviewRepostitory : IReviewRepository
    {
        private readonly MovieContext _movieContext;

        public ReviewRepostitory(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public void AddReview(Review review)
        {
           _movieContext.Reviews.Add(review);
            _movieContext.SaveChanges();
        }

        public double AverageRating(string movieName)
        {
            return _movieContext.Reviews.Where(r => r.Movie.Name.Equals(movieName, StringComparison.OrdinalIgnoreCase)).Average(r => (double)r.Rating);
        }

        public void DeleteReview(int id)
        {
            var review = _movieContext.Reviews.Find(id);
            if (review != null)
            {
                _movieContext.Reviews.Remove(review);
                _movieContext.SaveChanges();
            }
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _movieContext.Reviews.Include(r => r.Movie).ToList();
        }

        public IEnumerable<Review> GetAllReviewsByKeywords(string keywords)
        {
            return _movieContext.Reviews.Where(r => r.Comment.Contains(keywords)).Include(r => r.Movie).ToList();
        }

        public IEnumerable<Review> GetAllReviewsByRating(int rating)
        {
            return _movieContext.Reviews.Where(r => r.Rating == rating).ToList();
        }

        public Review GetReviewById(int id)
        {
            return _movieContext.Reviews.Include(r => r.Movie).FirstOrDefault(r => r.ID == id);

        }

        public IEnumerable<Review> GetReviewByMovie(string movieName)
        {
            return _movieContext.Reviews.Include(r => r.Movie).Where(r => r.Movie.Name.ToLower() == movieName.ToLower()).ToList();
        }

        public void UpdateReview(Review review)
        {
         
            _movieContext.SaveChanges();

        }
    }
}
