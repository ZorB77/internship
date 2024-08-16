using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Persistance
{
    internal class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(MoviesDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles
                           .AsNoTracking()
                           .Include(e => e.Movie)
                           .Include(e => e.Person).ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.Roles
                           .AsNoTracking()
                           .Include(e => e.Movie)
                           .Include(e => e.Person)
                           .FirstOrDefaultAsync(r => r.RoleId == id);
        }

    }
}
