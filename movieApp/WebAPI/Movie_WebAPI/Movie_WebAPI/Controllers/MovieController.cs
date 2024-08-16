using Microsoft.AspNetCore.Mvc;
using Movie_WebAPI.Helpers;
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
            try
            {
                _logService.LogRequest("Add new movie.");
                return _movieService.AddMovie(movie.Title, movie.ReleaseDate, movie.Description, movie.Genre, movie.Budget, movie.Duration);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                return ex.Message;
            }
        }

        [Route("api/getMovies")]
        [HttpGet]
        public PagedList<Movie> GetMovies([FromQuery] PaginationFilter filter)
        {
            try
            {
                _logService.LogRequest("Get all movies.");
                return PagedList<Movie>.ToPagedList(_movieService.GetAllMovies().AsQueryable(), filter.PageNumber, filter.PageSize);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/getMovieById/ID={id}")]
        [HttpGet]
        public Movie GetMovieById(int id)
        {
            try
            {
                _logService.LogRequest($"Get movie with id {id}.");
                return _movieService.GetMovieById(id);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/deleteMovie/ID={id}")]
        [HttpDelete]
        public string DeleteMovie(int id)
        {
            try
            {
                _logService.LogRequest("Delete a movie.");
                return _movieService.DeleteMovie(id);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/updateMovie/ID={id}")]
        [HttpPut]
        public string UpdateMovie([FromBody] Movie movie)
        {
            try
            {
                _logService.LogRequest("Update a movie.");
                return _movieService.UpdateMovie(movie.ID, movie.Title, movie.ReleaseDate, movie.Description, movie.Genre, movie.Budget, movie.Duration);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                return ex.Message;
            }
        }

        [Route("api/filterByGenre/genre={genre}")]
        [HttpGet]
        public List<Movie> GetMoviesByGenre(string genre, [FromQuery]PaginationFilter filter)
        {
            try
            {
                _logService.LogRequest($"Filter movies by genre {genre}.");
                return PagedList<Movie>.ToPagedList(_movieService.FilterMoviesByGenre(genre).AsQueryable(), filter.PageNumber, filter.PageSize);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/filterByYear/year={year}")]
        [HttpGet]
        public List<Movie> GetMoviesByYear(int year, [FromQuery]PaginationFilter filter)
        {
            try
            {
                _logService.LogRequest($"Filter movies by year {year}");
                return PagedList<Movie>.ToPagedList(_movieService.FilterMoviesByYear(year).AsQueryable(), filter.PageNumber, filter.PageSize);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/filterByDateInterval/year1={year1}&year2={year2}")]
        [HttpGet]
        public List<Movie> GetMoviesByDateInterval(int year1, int year2, [FromQuery]PaginationFilter filter)
        {
            try
            {
                _logService.LogRequest($"Filter movies by date interval. Between {year1} and {year2}.");
                return PagedList<Movie>.ToPagedList(_movieService.FilterMoviesByDateInterval(year1, year2).AsQueryable(), filter.PageNumber, filter.PageSize);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }
    }
}
