using Microsoft.AspNetCore.Mvc;
using Movies.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILogger _logger;

        public PersonController(IPersonService personService, ILogger<Person> logger){
            _personService = personService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            var people = _personService.GetAll();
            _logger.LogInformation($"GetAll entities");
            return Ok(people);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                _logger.LogInformation($"Entity with id {id} not found");
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Person data is null.");
            }

            try
            {
                _personService.AddPerson(person.PersonId, person.FirstName, person.LastName, person.Birthdate, person.Email);
                return CreatedAtAction(nameof(GetById), new { id = person.PersonId }, person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Person person)
        {
            if (id != person.PersonId)
            {
                return BadRequest("Person ID mismatch.");
            }

            try
            {
                _personService.UpdatePerson(person.PersonId, person.FirstName, person.LastName, person.Birthdate, person.Email);
                _logger.LogInformation("Person updated");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _personService.DeletePerson(id);
                _logger.LogInformation($"Person deleted {id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpGet("filterByDate")]
        public ActionResult<IEnumerable<Person>> FilterByDate([FromQuery] DateTime dateStart, [FromQuery] DateTime dateStop)
        {
            var people = _personService.FilterPersonByDate(dateStart, dateStop);
            _logger.LogInformation($"FilterByDate: {people}");
            return Ok(people);
        }
    }
}
