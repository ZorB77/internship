using MovieApp.Models;
using MovieApp;
using System.Text;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace MovieApplication.Services
{
    public class ReviewService
    {
        private readonly MovieContext _context;

        public ReviewService(MovieContext context)
        {
            _context = context;
        }

        public string AddReview(int movieId, double rating, string comment, DateTime reviewDate, string reviewerName)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.ID == movieId);

            try
            {
                if (movie != null)
                {
                    var newReview = new Review
                    {
                        Movies = movie,
                        Rating = rating,
                        Comment = comment,
                        ReviewDate = reviewDate,
                        ReviewerName = reviewerName
                    };
                    _context.Reviews.Add(newReview);
                    _context.SaveChanges();
                }
                return "Review added succesfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Review> GetAllReviews()
        {
            var reviews = _context.Reviews.ToList();

            if (reviews.Count == 0)
            {
                throw new Exception("There are no reviews!");
            }

            return reviews;
        }

        public Review GetReviewById(int id)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.ID == id);

            if (review != null)
            {
                return review;
            }
            else
            {
                throw new Exception($"Review with id {id} does not exits!");
            }
        }

        public string DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);

            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
                return "Review deleted succesfully!";
            }
            else
            {
                return $"Review with id {id} does not exists!";
            }
        }

        public string UpdateReview(int reviewId, double rating, string comment, DateTime reviewDate, string reviewerName)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.ID == reviewId);

            if (review != null)
            {
                review.Rating = rating;
                review.Comment = comment;
                review.ReviewDate = reviewDate;
                review.ReviewerName = reviewerName;

                _context.SaveChanges();
                return "Review updated succesfully!";
            }
            return "Review not found! Please try again!";
        }

        public List<Review> FilterReviewByRating(double rating)
        {
            List<Review> reviews = _context.Reviews
                .Where(r => r.Rating == rating)
                .Include(m => m.Movies)
                .AsNoTracking()
                .ToList();

            if (reviews.Count == 0)
            {
                throw new Exception($"Movies with rating {rating} does not exits!");
            }

            return reviews;
        }

        public int AverageRatingForGivenMovie(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.ID == movieId);
            var reviews = _context.Reviews.Where(r => r.Movies == movie);

            if (reviews.Any())
            {
                int avgRating = (int)reviews.Average(r => r.Rating);

                return avgRating;
            }
            else
            {
                throw new Exception("Couldn't calculate average rating!");
            }
        }

        public List<Movie> Top10Movies()
        {
            try
            {
                var topMovies = _context.Movies
                 .Select(m => new
                 {
                     Movie = m,
                     AverageRating = m.Reviews.Any() ? m.Reviews.Average(r => r.Rating) : 0
                 })
                 .OrderByDescending(m => m.AverageRating)
                 .Take(10)
                 .Select(m => m.Movie)
                 .ToList();

                return topMovies;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while fetching the top 10 movies!", ex);
            }

        }

        public void ReviewOptions()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Add a review");
            Console.WriteLine("2 - Get reviews list");
            Console.WriteLine("3 - Get review by id");
            Console.WriteLine("4 - Delete a review");
            Console.WriteLine("5 - Update a review");
            Console.WriteLine("6 - Average rating for given movie");
            Console.WriteLine("7 - Top 10 movies");
            Console.WriteLine("8 - Filter review by rating");
            Console.WriteLine("9 - Back to base options");
        }
    }
}

