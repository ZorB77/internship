using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MovieWinForms;
using MovieWinForms.Models;
namespace MovieWinForms.DataAccess
{
    public class MovieRepository
    {
        private static MovieDbContext _context = new MovieDbContext();
        public static void CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        public static List<Movie> GetMovies()
        {
            var movies = _context.Movies.ToList();
            return movies;
        }
        public static List<Movie> GetMoviesInRange(DateTime start, DateTime end)
        {
            var movies = _context.Movies.Where(m=>m.Year >= start && m.Year <= end).ToList();
            return movies;
        }
        public static List<Movie> GetTopTenMovies()
        {
            var movies = _context.Movies
                .Select(m => new
                {
                    Movie = m,
                    AverageRating = _context.Reviews.Where(r => r.Movie.Id == m.Id).DefaultIfEmpty().Average(r => r == null ? 0 : r.Rating)
                })
                .Where(m => m.AverageRating > 0)
                .OrderByDescending(m => m.AverageRating)
                .Take(10)
                .Select(m => m.Movie)
                .ToList();
            return movies;
        }
        public static List<string> GetGenres()
        {
            var genres = _context.Movies
                .Select(m => m.Genre)
                .Distinct()
                .ToList();
            return genres;
        }
        public static List<Movie> GetMoviesByGenre(string genre)
        {
            var movies = _context.Movies
                .Where(m => m.Genre == genre)
                .ToList();
            return movies;
        }
        public static List<Movie> GetSortedMoviesByName()
        {
            var movies = _context.Movies
                .OrderBy(m => m.Name)
                .ToList();
            return movies;
        }
        public static List<Movie> GetSortedMoviesByReleaseDate()
        {
            var movies = _context.Movies
                .OrderBy(m => m.Year)
                .ToList();
            return movies;
        }
        public static Movie GetMovieById(int id)
        {
            return _context.Movies.Where(m => m.Id == id).FirstOrDefault();
        }
        public static decimal GetAverageRating(int id)
        {
            try
            {
                var averageRating = _context.Reviews.Where(r => r.Movie.Id == id).Average(r  => r.Rating);
                return averageRating;
            } catch
            {
                return 0;
            }
        }
        public static void UpdateMovie(int id, Movie newMovie)
        {
            var movie = GetMovieById(id);
            movie.Name = newMovie.Name;
            movie.Description = newMovie.Description;
            movie.Year = newMovie.Year;
            movie.Description = newMovie.Description;
            movie.Genre = newMovie.Genre;
            _context.Update(movie);
            _context.SaveChanges();
        }
        public static void DeleteMovie(int id)
        {
            var movie = GetMovieById(id);
            _context.Remove(movie);
            _context.SaveChanges();
        }
    }
}
