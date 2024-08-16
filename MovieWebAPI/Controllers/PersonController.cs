using Microsoft.AspNetCore.Mvc;
using Movies.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Movies.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            try
            {
                var people = await _personService.GetAllAsync();
                _logger.LogInformation("GetAll entities");
                return Ok(people);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all people.");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            try
            {
                var person = await _personService.GetByIdAsync(id);
                if (person == null)
                {
                    _logger.LogInformation($"Entity with id {id} not found");
                    return NotFound();
                }
                return Ok(person);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while getting person with id {id}.");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Person data is null.");
            }

            try
            {
                await _personService.AddPersonAsync(person.PersonId, person.FirstName, person.LastName, person.Birthdate, person.Email);
                return CreatedAtAction(nameof(GetById), new { id = person.PersonId }, person);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a person.");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Person person)
        {
            if (id != person.PersonId)
            {
                return BadRequest("Person ID mismatch.");
            }

            try
            {
                await _personService.UpdatePersonAsync(person.PersonId, person.FirstName, person.LastName, person.Birthdate, person.Email);
                _logger.LogInformation("Person updated");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating person.");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _personService.DeletePersonAsync(id);
                _logger.LogInformation($"Person deleted {id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting person.");
                return NotFound(ex.Message);
            }
        }

        [HttpGet("filterByDate")]
        public async Task<ActionResult<IEnumerable<Person>>> FilterByDate([FromQuery] DateTime dateStart, [FromQuery] DateTime dateStop)
        {
            try
            {
                var people = await _personService.FilterPersonByDateAsync(dateStart, dateStop);
                _logger.LogInformation($"FilterByDate: {people.Count} results found.");
                return Ok(people);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while filtering people by date.");
                return BadRequest(ex.Message);
            }
        }
    }
}
