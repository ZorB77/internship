using Exercise1.ConfigDatabase;
using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Repository
{
    public class MovieRepository : IMovieRepository

    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        //get all movies

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        //get movie by name
        public Movie GetMovie(string name)
        {
            return _context.Movies.FirstOrDefault(m => m.Name.ToLower() == name.ToLower());
        }

        //add movie method
        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        //update method
        public void UpdateMovie(Movie movie)
        {
            _context.Movies.Attach(movie);
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }
        // delete method

        public void DeleteMovie(string name)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Name.ToLower() == name.ToLower());
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            Console.WriteLine("movie deleted!");
        }
        //filter the movies by genre
        public IEnumerable<Movie> GetMoviesByGenre(string genre)
        {
            return _context.Movies.Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        //filter the movies by genre and year
        public IEnumerable<Movie> GetMoviesByGenreAndYear(string genre, int year)
        {
            return _context.Movies.Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase) && m.Year == year).ToList();
        }
        //get top ten movies
        public IEnumerable<Movie> GetTopTenMovies()
        {
            return _context.Movies.OrderByDescending(m => m.Reviews.Max(r => r.Rating)).Take(10).ToList();
         
        }
        //filter the mvoies by year
        public IEnumerable<Movie> GetMoviesbyYear(int year)
        {
            return _context.Movies.Where(m => m.Year == year).ToList();
        }

        public IEnumerable<Movie> GetMoviesByYearRange(int startYear, int endYear)
        {
           return _context.Movies.Where( m => m.Year >= startYear && m.Year<= endYear).ToList();
        }
    }
}
