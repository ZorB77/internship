using ETMovies.Models;
using ETMovies.Service;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private MovieService service;

        public MoviesController(MovieService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovies(int page = 1, int pageSize = 10)
        {

            return service.GetMovies().Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        [HttpGet("{id}")]
        public Movie GetMovie(int id)
        {
            var movie = service.GetMovie(id);
            if (movie == null)
                return null;
            return movie;
        }

        [HttpPost]
        public void Post(string title, string description, int year, string genre, int duration, decimal budget, int studioID)
        {
            var movie = new Movie(title, description, year, genre, duration, budget);
            service.AddMovie(movie, studioID);
        
        }

        [HttpPut]
        public void Put(int id, string title, string description, int year, string genre, int duration, decimal budget)
        {
            service.UpdateMovie(id, title, description, year, genre, duration, budget);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteMovie(id);
        }
        [HttpDelete("{title}")]
        public void DeleteByTitle(string title)
        {
            service.DeleteMovieByTitle(title);
        }

        [HttpGet]
        public List<Movie> GetMoviesByDateRange(int startYear=1900, int endYear = 2024, int page = 1, int pageSize = 10)
        {
            var filtered = service.GetMoviesByDateRange(startYear, endYear);
            return filtered.Skip((page-1)*pageSize).Take(pageSize).ToList();
        }

        [HttpGet]
        public List<Movie> SortMoviesByNameAndGenre(int page = 1, int pageSize = 10)
        {
            var sorted = service.SortMoviesByNameAndGenre();
            return sorted.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        [HttpGet]
        public List<Movie> TopTenMoviesByRating()
        {
            return service.TopTenMoviesByRating();
        }

        [HttpGet("{id}")]
        public double GetAverageRating(int id)
        {
            return service.GetAverageRating(id); 
        }
    }
}
