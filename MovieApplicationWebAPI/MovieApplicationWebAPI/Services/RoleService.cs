using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.DataAccess;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Custom_Exceptions;

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
            var existingRole = await _dbContext.roles.FirstOrDefaultAsync(r => r.ID == id);
            if (existingRole != null)
            {
                var existingPerson = await _dbContext.persons.FirstOrDefaultAsync(p => p.ID == roleMapper.PersonID);
                var existingMovie = await _dbContext.movies.FirstOrDefaultAsync(m => m.ID == roleMapper.MovieID);

                existingRole.Name = roleMapper.Name;
                existingRole.Description = roleMapper.Description;
                existingRole.Salary = roleMapper.Salary;
                existingRole.Person = existingPerson;
                existingRole.Movie = existingMovie;

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
