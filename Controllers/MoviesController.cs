using Microsoft.AspNetCore.Mvc;
using MovieAppRESTAPI.DTOs.MovieDTOs;
using MovieAppRESTAPI.Services;
using MovieWinForms.Models;
using System.ComponentModel;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAppRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly MovieService _service;
        private readonly StudioService _studioService;
        private readonly ReviewService _reviewService;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(MovieService service, ILogger<MoviesController> logger, StudioService studioService, ReviewService reviewService)
        {
            _service = service;
            _logger = logger;
            _studioService = studioService;
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult Get(int pageNr, int pageSize, int nameSort = 0, int releaseSort = 0)
        {
            try
            {
                var movies = _service.GetPaginatedMovies(pageNr, pageSize).Select(m => new MovieDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Director = m.Director,
                    AverageRating = _reviewService.GetAverageRating(m.Id),
                    Studios = m.Studios.Select(s => new StudioSimplified { Id = s.Id, Name = s.Name }).ToList(),
                    Year = m.Year,
                    Description = m.Description,
                    Genre = m.Genre
                });
                if (nameSort == 1)
                {
                    movies = movies.OrderBy(m => m.Name);
                }
                if (releaseSort == 1)
                {
                    movies = movies.OrderBy(m => m.Year);
                }
                _logger.LogInformation("Called GET on /api/Movies/");
                return Ok(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("/api/Movies/Top10MoviesByRating")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var movies = _service.GetMovies().Select(m => new MovieDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Director = m.Director,
                    AverageRating = _reviewService.GetAverageRating(m.Id),
                    Studios = m.Studios.Select(s => new StudioSimplified { Id = s.Id, Name = s.Name }).ToList(),
                    Year = m.Year,
                    Description = m.Description,
                    Genre = m.Genre
                });
                return Ok(movies.OrderByDescending(m => m.AverageRating).Where(m => m.AverageRating != 0).Take(10).ToList());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("/api/Movies/Filter/Date/{startDate:datetime:required}/{endDate:datetime:required}")]
        [HttpGet]
        public IEnumerable<MovieDTO> Get(DateTime startDate, DateTime endDate)
        {
            var movies = _service.GetMovies().Select(m => new MovieDTO
            {
                Id = m.Id,
                Name = m.Name,
                Director = m.Director,
                AverageRating = _reviewService.GetAverageRating(m.Id),
                Studios = m.Studios.Select(s => new StudioSimplified { Id = s.Id, Name = s.Name }).ToList(),
                Year = m.Year,
                Description = m.Description,
                Genre = m.Genre
            });
            return movies.Where(m => m.Year >= startDate && m.Year <= endDate);
        } 

        [Route("/api/Movies/Filter/Genre/{genre:required}")]
        [ProducesResponseType(typeof(IEnumerable<MovieDTO>), 200)]
        [HttpGet]
        public IActionResult Get(string genre)
        {
            try
            {
                var movies = _service.GetMovies().Select(m => new MovieDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Director = m.Director,
                    AverageRating = _reviewService.GetAverageRating(m.Id),
                    Studios = m.Studios.Select(s => new StudioSimplified { Id = s.Id, Name = s.Name }).ToList(),
                    Year = m.Year,
                    Description = m.Description,
                    Genre = m.Genre
                });
                return Ok(movies.Where(m => m.Genre.ToLower() == genre.ToLower()));
            } catch
            {
                return NotFound($"No movies associated with the {genre} genre.");
            }

        } 

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var movie = _service.GetMovieById(id);
                return Ok(new MovieDTO
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Director = movie.Director,
                    Studios = movie.Studios.Select(s => new StudioSimplified { Id = s.Id, Name = s.Name }).ToList(),
                    Year = movie.Year,
                    Description = movie.Description,
                    Genre = movie.Genre
                });
            } catch
            {
                return NotFound($"Movie with ID {id} not found.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateMovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var movie = new Movie
                {
                    Name = movieDTO.Name,
                    Year = movieDTO.Year,
                    Description = movieDTO.Description,
                    Director = movieDTO.Director,
                    Genre = movieDTO.Genre
                };
                _service.AddMovie(movie);

                var responseMovie = new MovieDTO
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Year = movie.Year,
                    Description = movie.Description,
                    Genre = movie.Genre,
                    Director = movie.Director
                };

                return CreatedAtAction(nameof(Get), new { id = movie.Id }, responseMovie);
            } catch
            {
                return BadRequest("Encountered an error when creating the movie.");
            }
        }

        [Route("/api/Movies/AddStudio")]
        [HttpPost]
        public IActionResult Post([FromBody] MovieStudio movieStudio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var movie = _service.GetMovieById(movieStudio.MovieId);
            var studio = _studioService.GetStudio(movieStudio.StudioId);
            if (movie.Studios.Contains(studio))
            {
                return BadRequest("Studio already added to movie.");
            }
            movie.Studios.Add(studio);
            _service.UpdateMovie(movie);

            return Ok("Studio added to movie successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateMovieDTO updatedMovieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var movie = new Movie
                {
                    Id = id,
                    Name = updatedMovieDto.Name,
                    Year = updatedMovieDto.Year,
                    Description = updatedMovieDto.Description,
                    Director = updatedMovieDto.Director,
                    Genre = updatedMovieDto.Genre
                };
                _service.UpdateMovie(movie);
                return Created();
            } catch
            {
                return BadRequest("Error encountered when updating the movie.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteMovie(id);
                _logger.LogInformation($"Deleted movie with id {id} and associated entities.");
                return Ok("Movie deleted successfully.");
            } catch ( Exception ex )
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest($"Couldn't delete Movie with id {id}.");
            }

        }

        [Route("/api/Movies/DeleteStudio")]
        [HttpDelete]
        public IActionResult Delete([FromBody] MovieStudio movieStudio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var movie = _service.GetMovieById(movieStudio.MovieId);
                var studio = _studioService.GetStudio(movieStudio.StudioId);
                if (!movie.Studios.Contains(studio))
                {
                    return BadRequest("Studio isn't associated to the movie.");
                } 
                movie.Studios.Remove(studio);
                _service.UpdateMovie(movie);
                return Ok("Studio removed from movie successfully.");
            } catch
            {
                return BadRequest("Movie or studio not found.");
            }

        }
    }
}
