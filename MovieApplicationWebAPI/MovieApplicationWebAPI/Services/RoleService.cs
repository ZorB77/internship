using Microsoft.EntityFrameworkCore;
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

        public async Task AddRoleAsync(Role role)
        {
            _dbContext.roles.Add(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(int id, Role role)
        {
            if (id == role.ID)
            {
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
