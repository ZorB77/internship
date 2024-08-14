using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.Models;

namespace MovieApplicationWebAPI.Services
{
    public class ReviewService
    {
        private readonly MyDBContext _dbContext;

        public ReviewService(MyDBContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _dbContext.reviews.Include(r => r.Movie).ToListAsync();
        }

        public async Task<Review> GetReviewAsync(int id)
        {
            return await _dbContext.reviews.Include(r => r.Movie).FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task AddReviewAsync(Review review)
        {
            _dbContext.reviews.Add(review);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateReviewAsync(int id, Review review)
        {
            if (id == review.ID)
            {
                _dbContext.Update(review);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = _dbContext.reviews.FirstOrDefault(r => r.ID == id);
            if (review != null)
            {
                _dbContext.reviews.Remove(review);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
