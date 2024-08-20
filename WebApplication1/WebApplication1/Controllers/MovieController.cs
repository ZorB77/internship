using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Middleware;
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
                throw new ArgumentException("The movie cannot be null");
            }
            else
            {
                return Ok(movie);
            }
        }

        [HttpPost]
       
        public async Task<ActionResult> AddMovie([FromBody] MovieDTO movieDTO)

        {
            if (movieDTO.Year <= 0 || movieDTO.Year < 1900 || movieDTO.Year > DateTime.Now.Year)
            {
                throw new OperationFailedException("Invalid year provided. The year must be between 1900 and 2024.");
            }
                if (string.IsNullOrWhiteSpace(movieDTO.Description))
                {
                throw new ArgumentNullException(nameof(movieDTO.Description), "You must provide movie info.");
            }
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
                throw new ArgumentNullException(nameof(movieDTO), "Movie data must be provided.");
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
                throw new ArgumentNullException(nameof(name), "Movie name must be introduced");
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
