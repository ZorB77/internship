using System.Collections.Generic;

namespace Movies.Services
{
    public interface IReviewService
    {
        void AddReview(int reviewId, float rating, string comment, int movieId);
        void DeleteReview(int reviewId);
        List<Review> GetAll();
        Review GetByIdReview(int reviewId);
        float GetTheAverageRatingOfAMovie(int movieId);
        List<Movie> Top10MoviesWithHigherRating();
        void UpdateReview(int reviewId, float rating, string comment, int movieId);
    }
}