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

        public bool AddMovie(string title, DateTime year, string description, string genre)
        {
            try
            {
                var newMovie = new Movie
                {
                    Title = title,
                    Year = year,
                    Description = description,
                    Genre = genre,
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
            return _context.Movies.FirstOrDefault(m => m.MovieID == id);
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

        public bool UpdateMovie(int movieId, string title, DateTime year, string description, string genre)
        {
            Movie movie = _context.Movies.FirstOrDefault(m => m.MovieID == movieId);

            if (movie != null)
            {
                movie.Title = title;
                movie.Year = year;
                movie.Description = description;
                movie.Genre = genre;

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public string FilterMoviesByGenre(string genre)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{genre} movies: ");

            List<Movie> movies = _context.Movies.Where(m => m.Genre == genre).ToList();

            if (movies.Any())
            {
                foreach (Movie movie in movies)
                {
                    stringBuilder.AppendLine($"{movie.MovieID}. {movie.Title}");
                }
            }
            else
            {
                stringBuilder.AppendLine($"No movies found of genre {genre}.");
            }

            return stringBuilder.ToString();
        }

        public string FilterMoviesByYear(DateTime year)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Movies from {year}: ");

            List<Movie> movies = _context.Movies.Where(m => m.Year == year).ToList();

            if (movies.Any())
            {
                foreach (Movie movie in movies)
                {
                    stringBuilder.AppendLine($"{movie.MovieID}. {movie.Title}, {movie.Year.ToString("yyyy")}");
                }
            }
            else
            {
                stringBuilder.AppendLine($"No movies found for the year {year}");
            }

            return stringBuilder.ToString();
        }

        public string FilterMoviesByDateInterval(DateTime year1, DateTime year2)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Movies between: " + year1.ToString("yyyy") + " and " + year2.ToString("yyyy"));

            foreach (Movie movie in _context.Movies)
            {
                if (movie.Year >= year1 && movie.Year <= year2)
                {
                    stringBuilder.AppendLine(movie.Title + " - " + movie.Year.ToString("yyyy"));
                }
            }
            if (stringBuilder.Length == 0)
            {
                stringBuilder.AppendLine("No movies found for that interval.");
            }

            return stringBuilder.ToString();
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
