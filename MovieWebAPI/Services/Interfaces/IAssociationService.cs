namespace Movies.Services
{
    public interface IAssociationService
    {
        Task AddAssociationAsync(int id, int movieId, int studioId);
        Task<List<MovieStudioAssociation>> GetAllAssociationsAsync();
    }
}