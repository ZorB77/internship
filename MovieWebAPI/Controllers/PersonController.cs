using Microsoft.AspNetCore.Mvc;
using Movies.Services;

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

            var people = await _personService.GetAllAsync();
            _logger.LogInformation("GetAll entities");
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {

            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                _logger.LogInformation($"Entity with id {id} not found");
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Person data is null");
            }

            await _personService.AddPersonAsync(person.PersonId, person.FirstName, person.LastName, person.Birthdate, person.Email);
            return CreatedAtAction(nameof(GetById), new { id = person.PersonId }, person);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Person person)
        {
            if (id != person.PersonId)
            {
                return BadRequest("There is no person with this id");
            }


            await _personService.UpdatePersonAsync(person.PersonId, person.FirstName, person.LastName, person.Birthdate, person.Email);
            _logger.LogInformation("Person updated succesfully");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            await _personService.DeletePersonAsync(id);
            _logger.LogInformation($"Person deleted {id} succesfully");
            return NoContent();
        }

        [HttpGet("filterByDate")]
        public async Task<ActionResult<IEnumerable<Person>>> FilterByDate([FromQuery] DateTime dateStart, [FromQuery] DateTime dateStop)
        {

            var people = await _personService.FilterPersonByDateAsync(dateStart, dateStop);
            _logger.LogInformation($"FilterByDate: {people.Count} results found");
            return Ok(people);
        }
    }
}
