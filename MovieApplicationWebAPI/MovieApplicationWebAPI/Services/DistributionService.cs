using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.DataAccess;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Utilities;

namespace MovieApplicationWebAPI.Services
{
    public class DistributionService
    {
        private readonly MyDBContext _dbContext;

        public DistributionService(MyDBContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Distribution>> GetAllDistributionsAsync()
        {
            return await _dbContext.distributions.Include(d => d.Movie).Include(d => d.Studio).ToListAsync();
        }

        public async Task<Distribution> GetDistributionAsync(int id)
        {
            return await _dbContext.distributions.Include(d => d.Movie).Include(d => d.Studio).FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task AddDistributionAsync(Distribution distribution)
        {
            _dbContext.distributions.Add(distribution);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDistributionAsync(int id, Distribution distribution)
        {
            if (id == distribution.ID)
            {
                _dbContext.Update(distribution);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteDistributionAsync(int id)
        {
            var distribution = _dbContext.distributions.FirstOrDefault(d => d.ID == id);
            if (distribution != null)
            {
                _dbContext.distributions.Remove(distribution);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

