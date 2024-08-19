using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.DataAccess;
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

        /*public async Task AddReviewAsync(Review review)
        {
            _dbContext.reviews.Add(review);
            await _dbContext.SaveChangesAsync();
        }*/

        public async Task AddReviewAsync(ReviewMapper reviewMapper)
        {
            var movie = _dbContext.movies.FirstOrDefault(m => m.ID == reviewMapper.MovieID);
            var review = new Review { Movie = movie, Comment = reviewMapper.Comment, Rating = reviewMapper.Rating };
            _dbContext.reviews.Add(review);
            await _dbContext.SaveChangesAsync();
        }

        /*public async Task UpdateReviewAsync(int id, Review review)
        {
            if (id == review.ID)
            {
                _dbContext.Update(review);
                await _dbContext.SaveChangesAsync();
            }
        }*/

        public async Task UpdateReviewAsync(int id, ReviewMapper reviewMapper)
        {
            if (id == reviewMapper.Id)
            {
                var movie = _dbContext.movies.FirstOrDefault(m => m.ID == reviewMapper.MovieID);
                var review = new Review { ID = reviewMapper.Id, Movie = movie, Comment = reviewMapper.Comment, Rating = reviewMapper.Rating };
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
