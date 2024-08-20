using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Utilities;

namespace MovieApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private PersonService _personService;
        private LogWriter _logWriter;

        public PeopleController(PersonService personService, LogWriter logWriter)
        {
            _personService = personService;
            _logWriter = logWriter;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var persons =  await _personService.GetAllPersonsAsync();
            _logWriter.Log($"Get persons.");
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _personService.GetPersonAsync(id);

            if (person == null)
            {
                return NotFound();
            }
            _logWriter.Log($"Get person with id {id}.");
            return Ok(person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            await _personService.UpdatePersonAsync(id, person);
            _logWriter.Log($"Update person with id {id}.");
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _personService.AddPersonAsync(person);
            _logWriter.Log($"Add person: {person.FirstName} {person.LastName}.");
            return CreatedAtAction(nameof(GetPerson), new { id = person.ID }, person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            _personService.DeletePersonAsync(id);
            _logWriter.Log($"Delete person with id {id}.");
            return NoContent();
        }
    }
}
