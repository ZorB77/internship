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
    public class StudioController : ControllerBase
    {
       private readonly IStudioRepository _studioRepository;
        public StudioController(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudioDTO>>> GetAllStudios([FromQuery] Parameters parameters)
        {
            var studios = await _studioRepository.GetAllStudios(parameters);
            var metadata = new
            {
                studios.TotalCount,
                studios.PageSize,
                studios.CurrentPage,
                studios.HasNext,
                studios.HasPrevious,
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(studios);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetStudioByName(string name)
        {
            var studio = await _studioRepository.GetStudioByName(name);
            return Ok(studio);
        }
        [HttpPost]
        public async Task<ActionResult> AddStudio([FromBody] StudioDTO studioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(studioDTO.StudioName, @"^[a-zA-Z\s]+$"))
            {
                throw new FormatException("The format is invalid");
            }
            await _studioRepository.AddStudio(studioDTO);
            return Ok();
        }

        [HttpPut("{ name}")]
        public async Task<ActionResult> UpdateStudio(string name, [FromBody] StudioDTO studioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var studio = await _studioRepository.GetStudioByName(name);
            if (studio == null)
            {
                return NotFound();
            }
            await _studioRepository.UpdateStudio(studioDTO,name);
            return Ok();
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteStudio(string name)
        {
            var studio = await _studioRepository.GetStudioByName(name);
            if (studio == null)
            {
                return NotFound();
            }
            await _studioRepository.DeleteStudio(name);
            return Ok();
        }
    }
}
