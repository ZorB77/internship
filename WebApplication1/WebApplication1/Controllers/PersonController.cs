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
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetAllPersons([FromQuery] Parameters parameters)
        {
            var person = await _personRepository.GetAll(parameters);
            var metadata = new
            {
                person.TotalCount,
                person.PageSize,
                person.CurrentPage,
                person.HasNext,
                person.HasPrevious,
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(person);
        }

        [HttpGet("search")]
        public async Task<ActionResult<PersonDTO>> GetPerson([FromQuery] string firstName, [FromQuery] string lastName)
        {
            var person = await _personRepository.GetPerson(firstName, lastName);
            if (person == null)
            {
                return NotFound("Person not found");
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _personRepository.AddPerson(personDTO);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePerson([FromQuery] string firstName, [FromQuery] string lastName, [FromBody] PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _personRepository.UpdatePerson(firstName, lastName, personDTO);
            return Ok();
        }
    
        
        [HttpDelete("delete")]
        public async Task<IActionResult> DeletePerson([FromQuery] string firstName, [FromQuery] string lastName)
        {
            await _personRepository.DeletePerson(firstName, lastName);
            return Ok();
        }
    }
}
