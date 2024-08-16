using Microsoft.EntityFrameworkCore;
using MovieWinForms;
using MovieWinForms.Models;

namespace MovieAppRESTAPI.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly MovieDbContext _dbContext;
        public RoleRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Role entity)
        {
            _dbContext.Roles.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Roles.Remove(GetById(id));
            _dbContext.SaveChanges();
        }

        public IEnumerable<Role> GetAll()
        {
            return _dbContext.Roles.Include(r => r.Movie).Include(r => r.Person).ToList();
        }

        public Role GetById(int id)
        {
            return _dbContext.Roles.Find(id);
        }

        public void Update(Role entity)
        {
            _dbContext.Roles.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
