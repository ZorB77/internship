using System.Collections.Generic;

namespace Movies.Services
{
    public interface IReviewService
    {
        Task AddReviewAsync(int reviewId, float rating, string comment, int movieId);
        Task DeleteReviewAsync(int reviewId);
        Task<List<Review>> GetAllAsync();
        Task<Review> GetByIdReviewAsync(int reviewId);
        Task<float> GetTheAverageRatingOfAMovieAsync(int movieId);
        Task<List<Movie>> Top10MoviesWithHigherRatingAsync();
        Task UpdateReviewAsync(int reviewId, float rating, string comment, int movieId);
    }
}