using Microsoft.EntityFrameworkCore;
using MovieApp;
using MovieApp.Models;
using MovieApplication.Models;
using System.Reflection.Metadata.Ecma335;

namespace MovieApplication.Services
{
    public class MovieStudioService
    {
        public readonly MovieContext _context;
        public MovieStudioService(MovieContext context)
        {
            _context = context;
        }

        public string AddMovieStudioAssociation(int movieId, int studioId)
        {
            try
            {
                var newMovieStudio = new MovieStudio
                {
                    MovieID = movieId,
                    StudioID = studioId,
                };

                _context.MovieStudios.Add(newMovieStudio);
                _context.SaveChanges();
                return "Association added succesfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<MovieStudio> GetAllMovieStudiosAssociations()
        {
            var movieStudioAss = _context.MovieStudios
                .Include(m => m.Movie)
                .Include(s => s.Studio)
                .ToList();

            if (movieStudioAss.Count == 0)
            {
                throw new Exception("There are no movie-studio associations!");
            }

            return movieStudioAss;
        }

        public List<Studio> GetStudiosForMovie(int movieId)
        {
            var studios = _context.MovieStudios
                .Where(m => m.MovieID == movieId)
                .Select(s => s.Studio)
                .ToList();

            if (studios.Count == 0)
            {
                throw new Exception($"There are no studios for movie {movieId}!");
            }

            return studios;
        }

        public List<Movie> GetMoviesForStudio(int studioId)
        {
            var movies = _context.MovieStudios
                .Where(s => s.StudioID == studioId)
                .Select(m => m.Movie)
                .ToList();

            if (movies.Count == 0)
            {
                throw new Exception($"There are no movies for studio {studioId}!");
            }

            return movies;
        }

        public string DeleteMovieStudioAssociation(int id)
        {
            var movieS = _context.MovieStudios.Find(id);

            if (movieS != null)
            {
                _context.MovieStudios.Remove(movieS);
                _context.SaveChanges();
                return "Association deleted succesfully!";
            }

            throw new Exception($"Association with id {id} does not exists!");
        }

        public string UpdateMovieStudioAssociation(int movieStudioId, int movieId, int studioId)
        {
            var movieStudio = _context.MovieStudios.FirstOrDefault(ms => ms.ID == movieStudioId);

            if (movieStudio != null)
            {
                if (!string.IsNullOrEmpty(movieId.ToString()))
                {
                    movieStudio.MovieID = movieId;
                }

                if (!string.IsNullOrEmpty(studioId.ToString()))
                {
                    movieStudio.StudioID = studioId;

                }

                _context.SaveChanges();
                return "Association updated succesfully!";
            }

            throw new Exception("Failed to update association!");
        }

        public void MovieStudiosOptions()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Add a movie studio association");
            Console.WriteLine("2 - Get movie studios association list");
            Console.WriteLine("3 - Get studios for movie");
            Console.WriteLine("4 - Get movies for studio");
            Console.WriteLine("5 - Delete a movie studio association");
            Console.WriteLine("6 - Update a movie studio association");
            Console.WriteLine("7 - Back to base options");
        }
    }
}
