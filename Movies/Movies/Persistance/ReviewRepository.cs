using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Persistance
{
    internal class ReviewRepository : Repository<Review>
    {
        public ReviewRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Review> GetAll()
        {
            return _context.Set<Review>()
                           .Include(e => e.Movie)
                           .ToList();
        }

        public override Review GetById(int id)
        {
            return _context.Set<Review>()
                           .Include(e => e.Movie)
                           .FirstOrDefault(r => r.ReviewId == id);
        }
    }
}
