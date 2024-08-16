using Microsoft.AspNetCore.Mvc;
using Movie_WebAPI.Services;
using MovieApp.Models;
using MovieApp.Services;

namespace Movie_WebAPI.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieService _movieService;
        private readonly LogService _logService;

        public MovieController(MovieService movieService, LogService logService)
        {
            _movieService = movieService;
            _logService = logService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/addMovie")]
        [HttpPost]
        public string AddMovie([FromBody] Movie movie)
        {
            _logService.LogRequest("Add new movie.");
            return _movieService.AddMovie(movie.Title, movie.ReleaseDate, movie.Description, movie.Genre, movie.Budget, movie.Duration);
        }

        [Route("api/getMovies")]
        [HttpGet]
        public List<Movie> GetMovies()
        {
            _logService.LogRequest("Get all movies.");
            return _movieService.GetAllMovies();
        }

        [Route("api/getMovieById/ID={id}")]
        [HttpGet]
        public Movie GetMovieById(int id)
        {
            _logService.LogRequest($"Get movie with id {id}.");
            return _movieService.GetMovieById(id);
        }

        [Route("api/deleteMovie/ID={id}")]
        [HttpDelete]
        public bool DeleteMovie(int id)
        {
            _logService.LogRequest("Delete a movie.");
            return _movieService.DeleteMovie(id);
        }

        [Route("api/updateMovie/ID={id}")]
        [HttpPut]
        public string UpdateMovie([FromBody] Movie movie)
        {
            _logService.LogRequest("Update a movie.");
            return _movieService.UpdateMovie(movie.ID, movie.Title, movie.ReleaseDate, movie.Description, movie.Genre, movie.Budget, movie.Duration);
        }

        [Route("api/filterByGenre/genre={genre}")]
        [HttpGet]
        public List<Movie> GetMoviesByGenre(string genre)
        {
            _logService.LogRequest($"Filter movies by genre {genre}.");
            return _movieService.FilterMoviesByGenre(genre);
        }

        [Route("api/filterByYear/year={year}")]
        [HttpGet]
        public List<Movie> GetMoviesByYear(int year)
        {
            _logService.LogRequest($"Filter movies by year {year}");
            return _movieService.FilterMoviesByYear(year);
        }

        [Route("api/filterByDateInterval/year1={year1}&year2={year2}")]
        [HttpGet]
        public List<Movie> GetMoviesByDateInterval(int year1, int year2)
        {
            _logService.LogRequest($"Filter movies by date interval. Between {year1} and {year2}.");
            return _movieService.FilterMoviesByDateInterval(year1, year2);
        }
    }
}
