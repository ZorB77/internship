using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.DataAccess;
using MovieApplicationWebAPI.Models;

namespace MovieApplicationWebAPI.Services
{
    public class RoleService
    {
        private readonly MyDBContext _dbContext;

        public RoleService(MyDBContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _dbContext.roles.Include(r => r.Movie).Include(r => r.Person).ToListAsync();
        }

        public async Task<Role> GetRoleAsync(int id)
        {
            return await _dbContext.roles.Include(r => r.Movie).Include(r => r.Person).FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task AddRoleAsync(RoleMapper roleMapper)
        {
            var movie = _dbContext.movies.FirstOrDefault(m => m.ID == roleMapper.MovieID);
            var person = _dbContext.persons.FirstOrDefault(p => p.ID == roleMapper.PersonID);
            var role = new Role { Movie = movie, Person = person, Name = roleMapper.Name, Description = roleMapper.Description, Salary = roleMapper.Salary };
            _dbContext.roles.Add(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(int id, RoleMapper roleMapper)
        {
            if (id == roleMapper.ID)
            {
                var movie = _dbContext.movies.FirstOrDefault(m => m.ID == roleMapper.MovieID);
                var person = _dbContext.persons.FirstOrDefault(p => p.ID == roleMapper.PersonID);
                var role = new Role { ID = roleMapper.ID, Movie = movie, Person = person, Name = roleMapper.Name, Description = roleMapper.Description, Salary = roleMapper.Salary };
                _dbContext.Update(role);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = _dbContext.roles.FirstOrDefault(r => r.ID == id);
            if (role != null)
            {
                _dbContext.roles.Remove(role);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
