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
        public async Task<ActionResult<IEnumerable<Studio>>> GetStudios(int page = 1, int pageSize = 10)
        {
            var studios = await _studioService.GetStudiosAsync();
            var totalStudios = studios.Count;
            var totalPages = Math.Ceiling((decimal)totalStudios / pageSize);
            var studiosPerPage = studios.Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();

            return Ok(studiosPerPage);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Studio>> GetStudioById(int id)
        {
            var studio = await _studioService.GetByIdAsync(id);
            if (studio == null)
            {
                return NotFound($"There is no studio with ID {id}.");
            }
            return Ok(studio);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudio([FromBody] Studio studio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _studioService.AddStudioAsync(studio.StudioId, studio.Name, studio.Year, studio.Location);
            return CreatedAtAction(nameof(GetStudioById), new { id = studio.StudioId }, studio);
        }
    }
}
