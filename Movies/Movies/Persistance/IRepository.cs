using System.Collections.Generic;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Update(T entity);
    void Remove(T entity);
}
