using Microsoft.EntityFrameworkCore;
using MovieWinForms;
using MovieWinForms.Models;

namespace MovieAppRESTAPI.Repositories
{
    public class ReviewRepository : IRepository<Review>
    {
        private readonly MovieDbContext _dbContext;
        public ReviewRepository(MovieDbContext context)
        {
            _dbContext = context; 
        }
        public void Add(Review entity)
        {
            _dbContext.Reviews.Add(entity); 
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Reviews.Remove(GetById(id));
            _dbContext.SaveChanges();
        }

        public IEnumerable<Review> GetAll()
        {
            return _dbContext.Reviews.Include(r => r.Movie).ToList();
        }

        public Review GetById(int id)
        {
            return _dbContext.Reviews.Include(r => r.Movie).FirstOrDefault(r => r.Id == id);
        }

        public void Update(Review entity)
        {
            _dbContext.Reviews.Update(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Review> GetByMovieId(int movieId)
        {
            return _dbContext.Reviews.Where(r => r.Movie.Id == movieId).ToList();
        }
        public decimal GetAverageRating(int movieId)
        {
            return _dbContext.Reviews.Where(r => r.Movie.Id == movieId).Average(r => r.Rating);
        }
    }
}
