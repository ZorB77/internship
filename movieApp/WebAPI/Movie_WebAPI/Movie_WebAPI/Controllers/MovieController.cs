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
        public string AddMovie([FromBody]Movie movie)
        {
            return _movieService.AddMovie(movie.Title, movie.ReleaseDate, movie.Description, movie.Genre, movie.Budget, movie.Duration);
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
        public string UpdateMovie([FromBody]Movie movie) {
            return _movieService.UpdateMovie(movie.ID, movie.Title, movie.ReleaseDate, movie.Description, movie.Genre, movie.Budget, movie.Duration);
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
