using MovieApp.Models;

namespace MovieApp.Services
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
    }
}
