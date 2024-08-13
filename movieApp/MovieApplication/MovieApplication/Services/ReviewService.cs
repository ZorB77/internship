using MovieApp.Models;
using MovieApp;
using System.Text;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace MovieApplication.Services
{
    public class ReviewService
    {
        private readonly MovieContext _context;

        public ReviewService(MovieContext context)
        {
            _context = context;
        }

        public bool AddReview(int movieId, double rating, string comment, DateTime reviewDate, string reviewerName)
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }

        public Review GetReviewById(int id)
        {
            return _context.Reviews.FirstOrDefault(r => r.ID == id);
        }

        public bool DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);

            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateReview(int reviewId, double rating, string comment, DateTime reviewDate, string reviewerName)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.ID == reviewId);

            if (review != null)
            {
                review.Rating = rating;
                review.Comment = comment;
                review.ReviewDate = reviewDate;
                review.ReviewerName = reviewerName;

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public string FilterReviewByRating(double rating)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();

            List<Review> reviews = _context.Reviews.Include(r => r.Movies).Where(r => r.Rating == rating).ToList();

            if (reviews.Any())
            {
                foreach (Review review in reviews)
                {
                        stringBuilder.AppendLine($"{review.ID}. {review.Movies.Title}: {review.Comment}");
                }
            }
            else
            {
                stringBuilder.AppendLine($"No reviews for rating {rating}");
            }

            return stringBuilder.ToString();
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
                return 0;
            }
        }

        public List<Movie> Top10Movies()
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

