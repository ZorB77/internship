using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IMovieStudioRepository
    {
        Task AddMovieStudio(string movieName, string studioName);
        Task DeleteMovieStudio(string movieName, string studioName);
        Task<IEnumerable<MovieStudio>> GetAll();
        Task<IEnumerable<MovieStudio>> GetStudiosByMovieName(string movieName);
        Task<IEnumerable<MovieStudio>> GetMoviesByStudioName(string studioName);

    }
}
