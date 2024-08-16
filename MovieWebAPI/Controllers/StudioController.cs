using Microsoft.AspNetCore.Mvc;
using Movies.Services;
using MovieWebAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudioController : ControllerBase
    {
        private readonly IStudioService _studioService;

        public StudioController(IStudioService studioService)
        {
            _studioService = studioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studio>>> GetStudios()
        {
            try
            {
                var studios = await _studioService.GetStudiosAsync();
                return Ok(studios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the studios.", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Studio>> GetStudioById(int id)
        {
            try
            {
                var studio = await _studioService.GetByIdAsync(id);
                if (studio == null)
                {
                    return NotFound(new { Message = "Studio not found." });
                }
                return Ok(studio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the studio.", Details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStudio([FromBody] Studio studio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _studioService.AddStudioAsync(studio.StudioId, studio.Name, studio.Year, studio.Location);
                return CreatedAtAction(nameof(GetStudioById), new { id = studio.StudioId }, studio);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while adding the studio.", Details = ex.Message });
            }
        }
    }
}
