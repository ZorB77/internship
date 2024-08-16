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

        public override IEnumerable<Role> GetAll()
        {
            return _context.Roles
                           .AsNoTracking()
                           .Include(e => e.Movie)
                           .Include(e => e.Person);
        }

        public override Role GetById(int id)
        {
            return _context.Roles
                           .AsNoTracking()
                           .Include(e => e.Movie)
                           .Include(e => e.Person)
                           .FirstOrDefault(r => r.RoleId == id);
        }

    }
}
