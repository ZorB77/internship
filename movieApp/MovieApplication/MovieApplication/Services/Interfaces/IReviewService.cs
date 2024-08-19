using MovieApp.Models;

namespace MovieApplication.Services.Interfaces
{
    public interface IReviewService
    {
        public bool AddReview(int movieId, double rating, string comment, DateTime reviewDate, string reviewerName);
        public List<Review> GetAllReviews();
        public Review GetReviewById(int id);
        public bool DeleteReview(int id);
        public bool UpdateReview(int reviewId, double rating, string comment, DateTime reviewDate, string reviewerName);
        public List<Review> FilterReviewByRating(double rating);
        public int AverageRatingForGivenMovie(int movieId);
        public List<Movie> Top10Movies();
        public void ReviewOptions();
    }
}
