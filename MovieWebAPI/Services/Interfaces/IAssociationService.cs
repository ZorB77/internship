using System.Collections.Generic;

namespace Movies.Services
{
    public interface IAssociationService
    {
        void AddAssociation(int id, int movieId, int studioId);
        List<MovieStudioAssociation> GetAllAssociations();
    }
}