using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Services;
using MovieApplicationWebAPI.Utilities;

namespace MovieApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private MovieService _movieService;
        private LogWriter _logWriter;

        public MoviesController(MovieService movieService, LogWriter logWriter)
        {
            _movieService = movieService;
            _logWriter = logWriter;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            _logWriter.Log("Get movies.");
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            _logWriter.Log($"Get movie with id {id}.");
            return Ok(movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            await _movieService.UpdateMovieAsync(id, movie);
            _logWriter.Log($"Update movie with id {id}.");
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _movieService.AddMovieAsync(movie);
            _logWriter.Log($"Add movie: {movie.Name}.");
            return CreatedAtAction(nameof(GetMovie), new { id = movie.ID }, movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {

            _movieService.DeleteMovieAsync(id);
            _logWriter.Log($"Delete movie with id {id}.");
            return NoContent();
        }


        //example: https://localhost:7063/api/Movies/paged?pageNumber=1&pageSize=5
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedData(int pageNumber, int pageSize)
        {
            var allMovies = await _movieService.GetAllMoviesAsync();

            var pagedMovies = allMovies
                .OrderBy(m => m.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalRecords = allMovies.Count();

            var pagedData = new
            {
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Data = pagedMovies
            };
            _logWriter.Log($"Get paged movie data .");
            return Ok(pagedData);
        }
    }
}
