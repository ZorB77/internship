﻿using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.DataAccess;
using MovieApplicationWebAPI.Models;

namespace MovieApplicationWebAPI.Services
{
    public class StudioService
    {
        private readonly MyDBContext _dbContext;

        public StudioService(MyDBContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Studio>> GetAllStudiosAsync()
        {
            return await _dbContext.studios.ToListAsync();
        }

        public async Task<Studio> GetStudioAsync(int id)
        {
            return await _dbContext.studios.FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task AddStudioAsync(Studio studio)
        {
            _dbContext.studios.Add(studio);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateStudioAsync(int id, Studio studio)
        {
            var existingStudio = await _dbContext.studios.FirstOrDefaultAsync(s => s.ID == id);
            if (existingStudio != null)
            {
                existingStudio.Name = studio.Name;
                existingStudio.Location = studio.Location;
                existingStudio.EstablishmentYear = studio.EstablishmentYear;    

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteStudioAsync(int id)
        {
            var studio = _dbContext.studios.FirstOrDefault(s => s.ID == id);
            if (studio != null)
            {
                _dbContext.studios.Remove(studio);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
