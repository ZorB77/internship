using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Persistance
{
    internal class RoleRepository : Repository<Role>
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Role> GetAll()
        {
            return _context.Set<Role>()
                           .Include(e => e.Movie)
                           .Include(e => e.Person)
                           .ToList();
        }

        public override Role GetById(int id)
        {
            return _context.Set<Role>()
                           .Include(e => e.Movie)
                           .Include(e => e.Person)
                           .FirstOrDefault(r => r.RoleId == id);
        }

    }
}
