
using MovieWebAPI.Persistance;

namespace Movies.Persistance
{
    internal interface IRoleRepository : IRepository<Role>
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(int id);
    }
}