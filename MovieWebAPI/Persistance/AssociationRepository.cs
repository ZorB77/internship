using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Persistance
{
    internal class AssociationRepository : Repository<MovieStudioAssociation>, IAssociationRepository
    {
        public AssociationRepository(MoviesDbContext context) : base(context)
        {
        }

        public override IEnumerable<MovieStudioAssociation> GetAll()
        {
            return _context.Set<MovieStudioAssociation>()
                           .Include(e => e.Movie)
                           .Include(e => e.Studio)
                           .ToList();
        }

        public override MovieStudioAssociation GetById(int id)
        {
            return _context.Set<MovieStudioAssociation>()
                           .Include(e => e.Movie)
                           .Include(e => e.Studio)
                           .FirstOrDefault(r => r.Id == id);
        }
    }
}
