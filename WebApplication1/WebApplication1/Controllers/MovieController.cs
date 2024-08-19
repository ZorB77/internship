using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies([FromQuery] Parameters parameters)
        {
            var movies = await _movieRepository.GetAllMovies(parameters);
            var metadata = new
            {
                movies.TotalCount,
                movies.PageSize,
                movies.CurrentPage,
                movies.HasNext,
                movies.HasPrevious,
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));    
            return Ok(movies);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Movie>> GetMovieByName(string name)
        {
            var movie = await _movieRepository.GetMovieByName(name);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie([FromBody] MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _movieRepository.AddMovie(movieDTO);
            return Ok();
        }

        [HttpPut("{name}")]

        public async Task<ActionResult> UpdateMovie(string name, [FromBody] MovieDTO movieDTO)
        {
           

            var movie = await _movieRepository.GetMovieByName(name);
            if (movie == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _movieRepository.UpdateMovie(movieDTO,name);
            return Ok();
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteMovie(string name)
        {
            var movie = await _movieRepository.GetMovieByName(name);
            if (movie == null)
            {
                return NotFound();
            }
            await _movieRepository.DeleteMovie(name);
            return Ok();
        }

        [HttpGet("genre/{genre}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByGenre(string genre)
        {
            var movie = await _movieRepository.GetMoviesByGenre(genre);
            return Ok(movie);
        }

        [HttpGet("genre/{genre}/year/{year}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByGenreAndYear(string genre,int year)
        {
            var movie = await _movieRepository.GetMoviesByGenreAndYear(genre,year);
            return Ok(movie);   
        }
        [HttpGet("year/{year}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByYear(int year)
        {
            var movie = await _movieRepository.GetMoviesByYear(year);
            return Ok(movie);

        }
        [HttpGet("topTen")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetTopTenMovies()
        {
            var movie = await _movieRepository.GetTopTenMovies();
            return Ok(movie);
        }
        [HttpGet("range/{startYear}/{endYear}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByYearRange(int startYear, int endYear)
        {
            var movies = await _movieRepository.GetMoviesByYearRange(startYear, endYear);
            return Ok(movies);
        }

    }
}
