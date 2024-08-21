
using MovieWebAPI.Persistance;

namespace Movies.Persistance
{
    internal interface IReviewRepository : IRepository<Review>
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review> GetByIdAsync(int id);
    }
}