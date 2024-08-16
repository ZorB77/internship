using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Persistance
{
    internal class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(MoviesDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Reviews
                           .Include(e => e.Movie)
                           .ToListAsync();
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _context.Reviews
                           .Include(e => e.Movie)
                           .FirstOrDefaultAsync(r => r.ReviewId == id);
        }
    }
}
