using Microsoft.AspNetCore.Mvc;
using Movies.Services;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<Studio>> GetStudios()
        {
            var studios = _studioService.GetStudios();
            return Ok(studios);
        }

        [HttpGet("{id}")]
        public ActionResult<Studio> GetStudioById(int id)
        {
            var studio = _studioService.GetById(id);
            if (studio == null)
            {
                return NotFound(new { Message = "Studio not found." });
            }
            return Ok(studio);
        }

        [HttpPost]
        public IActionResult AddStudio(int id, string name, int year, string location)
        {
            try
            {
                _studioService.AddStudio(id, name, year, location);
                return CreatedAtAction(nameof(GetStudioById), new { id = id }, new { id, name, year, location });
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
