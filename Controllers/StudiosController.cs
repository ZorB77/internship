using Microsoft.AspNetCore.Mvc;
using MovieAppRESTAPI.DTOs.StudiosDTOs;
using MovieAppRESTAPI.Services;
using MovieWinForms.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAppRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiosController : ControllerBase
    {

        private readonly StudioService _studioService;

        public StudiosController(StudioService studioService)
        {
            _studioService = studioService; 
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               return Ok(_studioService.GetAllStudios().Select(m => new StudioDTO
               {
                   Id = m.Id,
                   Name = m.Name,
                   Location = m.Location,
                   Year = m.Year
               }));
            } catch
            {
                return BadRequest("Couldn't get all Studios");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var studio = _studioService.GetStudio(id);
                return Ok(new StudioDTO
                {
                    Id = id,
                    Name = studio.Name,
                    Location = studio.Location,
                    Year = studio.Year
                });
            } catch
            {
                return NotFound($"Studio with id {id} not found.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateStudioDTO studioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var studio = new Studio
                {
                    Name = studioDTO.Name,
                    Location = studioDTO.Location,
                    Year = studioDTO.Year
                };
                _studioService.AddStudio(studio);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateStudioDTO studioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var studio = new Studio
                {
                    Id = id,
                    Name = studioDTO.Name,
                    Location = studioDTO.Location,
                    Year = studioDTO.Year
                };
                _studioService.UpdateStudio(studio);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _studioService.DeleteStudio(id);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

    }
}
