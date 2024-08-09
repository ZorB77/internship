using MovieApp.Models;

namespace MovieApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieContext _context;

        public MovieService(MovieContext context)
        {
            _context = context;
        }

        //ADD Movie
        public void AddMovie(string title, DateTime year, string description, string genre, int reviewId)
        {
            var newMovie = new Movie
            {
                Title = title,
                Year = year,
                Description = description,
                Genre = genre,
                ReviewID = reviewId,
            };

            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }

        //GET ALL MOVIES
        public List<Movie> GetAllMovies()
        {
            try
            {
                return _context.Movies.ToList();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return new List<Movie>();
            }
        }

        //GET MOVIE BY ID
        public Movie GetMovieById(int id) { 
            return _context.Movies.FirstOrDefault(m => m.MovieID == id);
        }

        //DELETE
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
    }
}
