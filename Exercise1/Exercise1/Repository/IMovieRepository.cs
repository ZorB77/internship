using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovie(string Name);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(string name);
        IEnumerable<Movie> GetMoviesByGenre(string genre);
        IEnumerable<Movie> GetMoviesByGenreAndYear(string genre, int year);
        IEnumerable<Movie> GetMoviesbyYear(int year);

        IEnumerable<Movie> GetTopTenMovies();
        IEnumerable<Movie> GetMoviesByYearRange(int startYear, int endYear);

    }
}
