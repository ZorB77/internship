using MovieWinForms;
using MovieWinForms.Models;

namespace MovieAppRESTAPI.Repositories
{
    public class StudioRepository : IRepository<Studio>
    {
        private readonly MovieDbContext _dbContext;
        public StudioRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public void Add(Studio entity)
        {
            _dbContext.Studios.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Studios.Remove(GetById(id));
            _dbContext.SaveChanges();
        }

        public IEnumerable<Studio> GetAll()
        {
            return _dbContext.Studios.ToList();
        }

        public Studio GetById(int id)
        {
            return _dbContext.Studios.Find(id);
        }

        public void Update(Studio entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
