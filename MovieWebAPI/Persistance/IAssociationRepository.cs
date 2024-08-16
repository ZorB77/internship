
using MovieWebAPI.Persistance;

namespace Movies.Persistance
{
    internal interface IAssociationRepository : IRepository<MovieStudioAssociation>
    {
        Task<IEnumerable<MovieStudioAssociation>> GetAllAsync();
        Task<MovieStudioAssociation> GetByIdAsync(int id);
    }
}