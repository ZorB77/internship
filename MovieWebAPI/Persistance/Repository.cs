using Microsoft.EntityFrameworkCore;
using MovieWebAPI.Persistance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public class Repository<T>(MoviesDbContext context) : IRepository<T> where T : class
{
    protected readonly MoviesDbContext _context = context;
    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        var entityType = typeof(T);
        var keyProperty = entityType.GetProperties()
            .FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Any() ||
                                 p.Name.Equals(entityType.Name + "Id", StringComparison.OrdinalIgnoreCase));

        var keyValue = keyProperty.GetValue(entity);

        var existingEntity = await _context.Set<T>().FindAsync(keyValue);

        if (existingEntity != null)
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Entity not found.");
        }
    }

    public async Task RemoveAsync(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _context.Set<T>().Attach(entity);
        }
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
