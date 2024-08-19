using WebApplication1.DTOs;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IMovieRepository
    {
        Task <PagedList<MovieDTO>> GetAllMovies(Parameters parameters);
        Task<MovieDTO> GetMovieByName(string name);
        Task AddMovie(MovieDTO movieDTO);
        Task UpdateMovie(MovieDTO movieDTO, string name);
        Task DeleteMovie(string name);
        Task<IEnumerable<MovieDTO>> GetMoviesByGenre(string genre);
        Task<IEnumerable<MovieDTO>> GetMoviesByGenreAndYear(string genre, int year);
        Task<IEnumerable<MovieDTO>> GetMoviesByYear(int year);


        Task<IEnumerable<MovieDTO>> GetTopTenMovies();
        Task<IEnumerable<MovieDTO>> GetMoviesByYearRange(int startYear, int endYear);
    }
}
