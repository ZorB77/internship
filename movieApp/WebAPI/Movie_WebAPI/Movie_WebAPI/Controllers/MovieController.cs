using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Services;

namespace Movie_WebAPI.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/addMovie")]
        [HttpPost]
        public bool AddMovie(string title, DateTime releaseDate, string description, string genre, decimal budget, int duration)
        {
            return _movieService.AddMovie(title, releaseDate, description, genre, budget, duration);
        }

        [Route("api/getMovies")]
        [HttpGet]
        public List<Movie> GetMovies() { 
            return _movieService.GetAllMovies();
        }

        [Route("api/getMovieById/ID={id}")]
        [HttpGet]
        public Movie GetMovieById(int id) {
            return _movieService.GetMovieById(id);
        }

        [Route("api/deleteMovie/ID={id}")]
        [HttpDelete]
        public bool DeleteMovie(int id) { 
            return _movieService.DeleteMovie(id);
        }

        [Route("api/updateMovie/ID={id}")]
        [HttpPut]
        public bool UpdateMovie(int id, string title, DateTime releaseDate, string description, string genre, decimal budget, int duration) {
            return _movieService.UpdateMovie(id, title, releaseDate, description, genre, budget, duration);
        }

        [Route("api/filterByGenre/genre={genre}")]
        [HttpGet]
        public List<Movie> GetMoviesByGenre(string genre)
        {
            return _movieService.FilterMoviesByGenre(genre);
        }
        
        [Route("api/filterByYear/year={year}")]
        [HttpGet]
        public List<Movie> GetMoviesByYear(int year)
        {
            return _movieService.FilterMoviesByYear(year);
        }
        
        [Route("api/filterByDateInterval/year1={year1}&year2={year2}")]
        [HttpGet]
        public List<Movie> GetMoviesByDateInterval(int year1, int year2)
        {
            return _movieService.FilterMoviesByDateInterval(year1, year2);
        }
    }
}
