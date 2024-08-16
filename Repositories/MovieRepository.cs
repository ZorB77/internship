using Microsoft.EntityFrameworkCore;
using MovieWinForms;
using MovieWinForms.Models;

namespace MovieAppRESTAPI.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly MovieDbContext _dbContext;
        public MovieRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Movie entity)
        {
            _dbContext.Movies.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Movies.Remove(GetById(id));
            _dbContext.SaveChanges();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _dbContext.Movies.Include(m => m.Studios).ToList();
        }

        public Movie GetById(int id)
        {
            return _dbContext.Movies.Include(m => m.Studios).Where(m => m.Id == id).FirstOrDefault();
        }

        public void Update(Movie entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
