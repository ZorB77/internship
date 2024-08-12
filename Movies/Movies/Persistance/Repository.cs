using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public virtual IEnumerable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public virtual T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Update(T entity)
    {
        var entityType = typeof(T);
        var keyProperty = entityType.GetProperties()
            .FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Any() ||
                                 p.Name.Equals(entityType.Name + "Id", StringComparison.OrdinalIgnoreCase));
        
        var keyValue = keyProperty.GetValue(entity);

        var existingEntity = _context.Set<T>().Find(keyValue);

        if (existingEntity != null)
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);

            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Entity not found.");
        }

    }

    public void Remove(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _context.Set<T>().Attach(entity);
        }
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}
