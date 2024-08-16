using MovieApp.Models;

namespace MovieApp.Services
{
    public class MovieService
    {
        private readonly MovieContext _context;

        public MovieService(MovieContext context)
        {
            _context = context;
        }

        public string AddMovie(string title, DateTime releaseDate, string description, string genre, decimal budget, int duration)
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
                return "Movie added succesfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Movie> GetAllMovies()
        {
            var movies = _context.Movies.ToList();

            if (movies.Count == 0)
            {
                throw new Exception("There are no movies!");
            }
            return movies;
        }

        public Movie GetMovieById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.ID == id);

            if (movie != null)
            {
                return movie;
            }
            else
            {
                throw new Exception($"Movie with id {id} does not exits!");
            }
        }

        public string DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                return "Movie deleted succesfully!";
            }
            else
            {
                return $"Movie with id {id} does not exits!";
            }
        }

        public string UpdateMovie(int movieId, string title, DateTime releaseDate, string description, string genre, decimal budget, int duration)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.ID == movieId);

            if (movie != null)
            {
                if (!string.IsNullOrEmpty(title))
                {
                    movie.Title = title;
                }

                if (!string.IsNullOrEmpty(releaseDate.ToShortDateString()))
                {
                    movie.ReleaseDate = releaseDate;
                }

                if (!string.IsNullOrEmpty(description))
                {
                    movie.Description = description;
                }

                if (!string.IsNullOrEmpty(genre))
                {
                    movie.Genre = genre;
                }

                if (!string.IsNullOrEmpty(budget.ToString()))
                {
                    movie.Budget = budget;
                }

                if (!string.IsNullOrEmpty(duration.ToString()))
                {
                    movie.Duration = duration;
                }

                _context.SaveChanges();
                return "Movie updated succesfully!";
            }
            else
            {
                return $"Movie with id {movieId} does not exits!";
            }
        }

        public List<Movie> FilterMoviesByGenre(string genre)
        {
            List<Movie> movies = _context.Movies.Where(m => m.Genre == genre).ToList();

            if (movies.Count == 0)
            {
                throw new Exception($"{genre} movies does not exits!");
            }

            return movies;
        }

        public List<Movie> FilterMoviesByYear(int year)
        {
            List<Movie> movies = _context.Movies.Where(m => m.ReleaseDate.Year == year).ToList();

            if (movies.Count == 0)
            {
                throw new Exception($"Movies from year {year} does not exits!");
            }

            return movies;
        }

        public List<Movie> FilterMoviesByDateInterval(int year1, int year2)
        {
            List<Movie> movies = _context.Movies.Where(m => (m.ReleaseDate.Year >= year1) && (m.ReleaseDate.Year <= year2)).ToList();

            if (movies.Count == 0)
            {
                throw new Exception($"Movies between {year1} and {year2} does not exits!");
            }

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
