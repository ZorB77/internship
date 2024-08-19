using Abp.Domain.Entities;
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
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {

            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound($"Movie with ID {id} not found.");
            }
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMovie([FromBody] Movie movie)
        {

            if (movie == null)
            {
                return BadRequest("Movie data is required.");
            }

            await _movieService.AddMovieAsync(
                movie.MovieId,
                movie.Name,
                movie.Year,
                movie.Description,
                movie.Genre,
                movie.Duration);

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.MovieId }, movie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (movie == null || id != movie.MovieId)
            {
                return BadRequest("Invalid movie data.");
            }

            await _movieService.UpdateMovieAsync(
                movie.MovieId,
                movie.Name,
                movie.Year,
                movie.Description,
                movie.Genre,
                movie.Duration);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            return NoContent();
        }

        [HttpGet("SortByTitle")]
        public async Task<ActionResult<IEnumerable<Movie>>> SortByTitle()
        {

            var movies = await _movieService.SortByTitleAsync();
            return Ok(movies);
        }

        [HttpGet("SortByYear")]
        public async Task<ActionResult<IEnumerable<Movie>>> SortByYear()
        {

            var movies = await _movieService.SortByYearAsync();
            return Ok(movies);
        }

        [HttpGet("FilterByDate")]
        public async Task<ActionResult<IEnumerable<Movie>>> FilterByDate([FromQuery] DateTime dateStart, [FromQuery] DateTime dateStop)
        {

            var movies = await _movieService.FilterMoviesByDateAsync(dateStart, dateStop);
            return Ok(movies);
        }

        [HttpGet("FilterByGenre")]
        public async Task<ActionResult<IEnumerable<Movie>>> FilterByGenre([FromQuery] string genre)
        {
            var movies = await _movieService.FilterMoviesByGenreAsync(genre);
            return Ok(movies);
        }

        [HttpGet("FilterByYear")]
        public async Task<ActionResult<IEnumerable<Movie>>> FilterByYear([FromQuery] int year)
        {

            var movies = await _movieService.FilterMoviesByYearAsync(year);
            return Ok(movies);
        }
    }
}
