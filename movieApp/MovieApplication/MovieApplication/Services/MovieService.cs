using MovieApp.Models;
using System.Text;

namespace MovieApp.Services
{
    public class MovieService
    {
        private readonly MovieContext _context;

        public MovieService(MovieContext context)
        {
            _context = context;
        }

        public bool AddMovie(string title, DateTime releaseDate, string description, string genre, decimal budget, int duration)
        {
            try
            {
                var newMovie = new Movie
                {
                    Title = title,
                    ReleaseDate = releaseDate,
                    Description = description,
                    Genre = genre,
                    Budget = budget,
                    Duration = duration
                };

                _context.Movies.Add(newMovie);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.ID == id);
        }

        public bool DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateMovie(int movieId, string title, DateTime releaseDate, string description, string genre, decimal budget, int duration)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.ID == movieId);

            if (movie != null)
            {
                movie.Title = title;
                movie.ReleaseDate = releaseDate;
                movie.Description = description;
                movie.Genre = genre;
                movie.Budget = budget;
                movie.Duration = duration;

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Movie> FilterMoviesByGenre(string genre)
        {
            List<Movie> movies = _context.Movies.Where(m => m.Genre == genre).ToList();

            return movies;
        }

        public List<Movie> FilterMoviesByYear(int year)
        {
            List<Movie> movies = _context.Movies.Where(m => m.ReleaseDate.Year == year).ToList();

            return movies;
        }

        public List<Movie> FilterMoviesByDateInterval(int year1, int year2)
        {
            List<Movie> movies = _context.Movies.Where(m => (m.ReleaseDate.Year >= year1) && (m.ReleaseDate.Year <= year2)).ToList();

            return movies;
        }

        public void MovieOptions()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Add a movie");
            Console.WriteLine("2 - Get movies list");
            Console.WriteLine("3 - Get movie by id");
            Console.WriteLine("4 - Delete a movie");
            Console.WriteLine("5 - Update a movie");
            Console.WriteLine("6 - Filter movies by genre");
            Console.WriteLine("7 - Filter movies by year");
            Console.WriteLine("8 - Filter movies by date interval");
            Console.WriteLine("9 - Back to base options");
        }
    }
}
