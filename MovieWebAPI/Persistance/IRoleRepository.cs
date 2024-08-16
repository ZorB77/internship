
namespace Movies.Persistance
{
    internal interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<Role> GetAll();
        Role GetById(int id);
    }
}