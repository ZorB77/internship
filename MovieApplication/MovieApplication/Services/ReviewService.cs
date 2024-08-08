using Microsoft.EntityFrameworkCore;
using System.Text;

namespace MovieApplication
{
    public class ReviewService
    {
        private MyDBContext db;

        public ReviewService(MyDBContext db)
        {
            this.db = db;
        }

        public int addReview(int movieID, int rating, string comment)
        {
            var movie = db.movies.SingleOrDefault(m => m.movieID == movieID);
            if (movie != null)
            {
                db.Add(new Review { movie = movie, rating = rating, comment = comment });
                db.SaveChanges();
                return 0;
            }
            return 1;
        }

        public int deleteReview(int reviewID)
        {
            var review = db.reviews.SingleOrDefault(r => r.reviewID == reviewID);
            if (review != null)
            {
                db.Remove(review);
                db.SaveChanges();
                return 0;
            }
            return 1; 
        }

        public int updateReview(int reviewID, int rating, string comment)
        {
            var review = db.reviews.SingleOrDefault(r => r.reviewID == reviewID);
            if (review != null)
            {
                review.rating = rating;
                review.comment = comment;

                db.SaveChanges();
                return 0;
            }
            return 1;
        }

        public string printReviews()
        {
            var s = new StringBuilder();
            s.AppendLine();
            s.AppendLine("The list of reviews is:");

            foreach (Review review in db.reviews.Include(r => r.movie))
            {
                s.AppendLine($"{review.reviewID}. {review.movie.name}. Rating: {review.rating}. Comment: {review.comment}");
            }
            return s.ToString();
        }

        public string getReviewInformation(int reviewID)
        {
            var s = new StringBuilder();
            s.AppendLine();

            var review = db.reviews.Include(r => r.movie).SingleOrDefault(r => r.reviewID == reviewID);
            if (review != null)
            {
                s.AppendLine($"Movie: {review.movie.name}");
                s.AppendLine($"Rating: {review.rating}");
                s.AppendLine($"Comment: {review.comment}");
            }
            else
            {
                s.AppendLine("There is no review with such id.");
            }
            return s.ToString();
        }

        public string filterReviewByMovie(int movieID)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine();
            s.AppendLine($"The list of reviews for the movie with the id {movieID} is:");

            List<Review> reviews = db.reviews.Where(r => r.movie.movieID == movieID).ToList();

            if (reviews.Any())
            {
                foreach (Review review in reviews)
                {
                    s.AppendLine($"{review.reviewID}. {review.movie.name}: {review.comment}");
                }
            }
            else
            {
                s.AppendLine("No reviews found for the given movie.");
            }

            return s.ToString();
        }

        public string filterReviewByRating(int rating)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine();
            s.AppendLine($"The list of reviews for the movie with the rating {rating} is:");

            List<Review> reviews = db.reviews.Where(r => r.rating == rating).ToList();

            if (reviews.Any())
            {
                foreach (Review review in reviews)
                {
                    s.AppendLine($"{review.reviewID}. {review.movie.name}: {review.comment}");
                }
            }
            else
            {
                s.AppendLine("No reviews found for the given rating.");
            }

            return s.ToString();
        }

        public int averageRatingForMovie(int movieID)
        {
            Movie movie = db.movies.SingleOrDefault(m => m.movieID == movieID);
            var reviews = db.reviews.Where(r => r.movie == movie);
            if (reviews.Any())
            {
                int averageRating = (int)reviews.Average(r => r.rating);
                return averageRating;

            }
            else
            {
                return -1;
            }
        }

        public string bestRatedMovies()
        {
            var allMovies = db.movies.ToList();

            var moviesWithRatings = allMovies
                .Select(movie => new
                {
                    MovieName = movie.name,
                    MovieID = movie.movieID,
                    AverageRating = averageRatingForMovie(movie.movieID)
                })
                .Where(m => m.AverageRating != -1) 
                .OrderByDescending(m => m.AverageRating)
                .Take(10)
                .ToList();

            if (moviesWithRatings.Any())
            {
                var result = new StringBuilder();
                result.AppendLine("Best rated movies are:");
                foreach (var movie in moviesWithRatings)
                {
                    result.AppendLine($"{movie.MovieID}. {movie.MovieName}: {movie.AverageRating:F1}");
                }
                return result.ToString();
            }
            else
            {
                return "There are no reviewed movies in the database.";
            }
        }





        public void printMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add a review.");
            Console.WriteLine("2. Delete a review.");
            Console.WriteLine("3. Update a review.");
            Console.WriteLine("4. See all reviews.");
            Console.WriteLine("5. See information about a given review.");
            Console.WriteLine("6. Filter reviews by movie.");
            Console.WriteLine("7. Filter reviews by rating.");
            Console.WriteLine("8. The average rating for a given movie.");
            Console.WriteLine("0. Back to the main menu.");
        }
    }
}
