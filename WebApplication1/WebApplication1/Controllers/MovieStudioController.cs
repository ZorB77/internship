using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieStudioController : ControllerBase
    {
        private readonly IMovieStudioRepository _movieStudioRepository;
        public MovieStudioController(IMovieStudioRepository movieStudioRepository)
        {
            _movieStudioRepository = movieStudioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieStudio>>> GetMovieStudios()
        {
            var movieStudio = await _movieStudioRepository.GetAll();
            return Ok(movieStudio);
        }

        [HttpGet("movie/{movieName}")]
        public async Task<ActionResult<IEnumerable<MovieStudio>>> GetStudiosByMovieName(string movieName)
        {
            var studio = await _movieStudioRepository.GetStudiosByMovieName(movieName);
            return Ok(studio);
        }
        [HttpGet("studio/{studioName}")]
        public async Task<ActionResult<IEnumerable<MovieStudio>>> GetMoviesByStudioName(string studioName)
        {
            var movie = await _movieStudioRepository.GetMoviesByStudioName(studioName);
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult> AddMovieStudio([FromQuery] string movieName, [FromQuery] string studioName)
        {
           
            await _movieStudioRepository.AddMovieStudio(movieName, studioName);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteMovieStudio([FromQuery] string movieName, [FromQuery]string studioName)
        {
            await _movieStudioRepository.DeleteMovieStudio(movieName, studioName);  
            return Ok();
        }
    }
}
