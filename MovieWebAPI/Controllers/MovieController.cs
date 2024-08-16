using Microsoft.AspNetCore.Mvc;
using Movies.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService) => _movieService = movieService;

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAllMovies()
        {
            try
            {
                var movies = _movieService.GetAll();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            try
            {
                var movie = _movieService.GetById(id);
                if (movie == null)
                {
                    return NotFound($"Movie with ID {id} not found.");
                }
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateMovie([FromBody] Movie movie)
        {
            try
            {
                if (movie == null)
                {
                    return BadRequest("Movie data is required.");
                }

                await Task.Run(() => _movieService.AddMovie(
                    movie.MovieId,
                    movie.Name,
                    movie.Year,
                    movie.Description,
                    movie.Genre,
                    movie.Duration));

                return CreatedAtAction(nameof(GetMovieById), new { id = movie.MovieId }, movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            try
            {
                if (movie == null || id != movie.MovieId)
                {
                    return BadRequest("Invalid movie data.");
                }

                _movieService.UpdateMovie(
                    movie.MovieId,
                    movie.Name,
                    movie.Year,
                    movie.Description,
                    movie.Genre,
                    movie.Duration);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            try
            {
                _movieService.DeleteMovie(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("SortByTitle")]
        public ActionResult<IEnumerable<Movie>> SortByTitle()
        {
            try
            {
                var movies = _movieService.SortbyTitle();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("SortByYear")]
        public ActionResult<IEnumerable<Movie>> SortByYear()
        {
            try
            {
                var movies = _movieService.SortbyYear();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FilterByDate")]
        public ActionResult<IEnumerable<Movie>> FilterByDate([FromQuery] DateTime dateStart, [FromQuery] DateTime dateStop)
        {
            try
            {
                var movies = _movieService.FilterMoviesByDate(dateStart, dateStop);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FilterByGenre")]
        public ActionResult<IEnumerable<Movie>> FilterByGenre([FromQuery] string genre)
        {
            try
            {
                var movies = _movieService.FilterMoviesByGenre(genre);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FilterByYear")]
        public ActionResult<IEnumerable<Movie>> FilterByYear([FromQuery] int year)
        {
            try
            {
                var movies = _movieService.FilterMoviesByYear(year);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
