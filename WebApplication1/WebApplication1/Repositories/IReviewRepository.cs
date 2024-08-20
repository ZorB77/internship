using WebApplication1.DTOs;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IReviewRepository
    {
        Task<PagedList<ReviewDTO>> GetAllRevies(Parameters parameters);
        Task<ReviewDTO> GetReviewById(int id);
        Task AddReview(ReviewDTO reviewDTO, string movieName);
        Task UpdateReview(int id, ReviewDTO reviewDTO, string movieName);
        Task DeleteReview(int id);
        Task<IEnumerable<ReviewDTO>> GetReviewByMovie(string movieName);
        Task<IEnumerable<ReviewDTO>> GetAllReviewsByRating(int rating);
        Task<IEnumerable<ReviewDTO>> GetAllReviewsByKeywords(string keywords);
        Task<double> AverageRating(string movieName);

    }
}
