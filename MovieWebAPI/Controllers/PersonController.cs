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

        public PersonController(IPersonService personService) => _personService = personService;

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            var people = _personService.GetAll();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
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
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/person/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _personService.DeletePerson(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/person/filterByDate
        [HttpGet("filterByDate")]
        public ActionResult<IEnumerable<Person>> FilterByDate([FromQuery] DateTime dateStart, [FromQuery] DateTime dateStop)
        {
            var people = _personService.FilterPersonByDate(dateStart, dateStop);
            return Ok(people);
        }
    }
}
