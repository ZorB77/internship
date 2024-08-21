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

        public async Task<IEnumerable<MovieStudioAssociation>> GetAllAsync()
        {
            return await _context.MovieStudioAssociations
                           .Include(e => e.Movie)
                           .Include(e => e.Studio)
                           .ToListAsync();
        }

        public async Task<MovieStudioAssociation> GetByIdAsync(int id)
        {
            return await _context.MovieStudioAssociations
                           .Include(e => e.Movie)
                           .Include(e => e.Studio)
                           .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
