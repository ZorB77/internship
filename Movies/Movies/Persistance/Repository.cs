using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

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
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
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
