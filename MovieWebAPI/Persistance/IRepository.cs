using System.Collections.Generic;

namespace MovieWebAPI.Persistance
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}