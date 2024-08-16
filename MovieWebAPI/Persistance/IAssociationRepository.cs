
namespace Movies.Persistance
{
    internal interface IAssociationRepository : IRepository<MovieStudioAssociation>
    {
        IEnumerable<MovieStudioAssociation> GetAll();
        MovieStudioAssociation GetById(int id);
    }
}