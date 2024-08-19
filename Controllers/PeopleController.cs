using Microsoft.AspNetCore.Mvc;
using MovieAppRESTAPI.DTOs.MovieDTOs;
using MovieAppRESTAPI.DTOs.PersonDTO.cs;
using MovieAppRESTAPI.Services;
using MovieWinForms.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAppRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonService _service;

        public PeopleController(PersonService personService)
        { 
            _service = personService;
        }

        [HttpGet]
        [Route("/api/PeoplePaginated")]
        public IActionResult Get(int pageNr, int pageSize)
        {
            try
            {
                var people = _service.GetPaginatedPeople(pageNr, pageSize);
                return Ok(people.Select(p => new PersonDTO
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthdate = p.Birthdate
                }));
            } catch
            {
                return BadRequest("Couldn't retrieve people properly.");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var people = _service.GetPeople();
                return Ok(people.Select(p => new PersonDTO
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthdate = p.Birthdate
                }));
            } catch
            {
                return BadRequest("Couldn't retrieve people properly.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var person = _service.GetPersonById(id);
                return Ok(new PersonDTO
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Birthdate = person.Birthdate
                });
            } catch
            {
                return NotFound($"Couln't retrieve Person with ID {id}.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreatePersonDTO personDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var person = new Person
                {
                    FirstName = personDTO.FirstName,
                    LastName = personDTO.LastName,
                    Birthdate = personDTO.Birthdate
                };
                _service.AddPerson(person);
                return Created();
            } catch
            {
                return BadRequest("Couldn't add the new person in the database.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreatePersonDTO updatedPersonDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var person = new Person
                {
                    Id = id,
                    FirstName = updatedPersonDTO.FirstName,
                    LastName = updatedPersonDTO.LastName,
                    Birthdate = updatedPersonDTO.Birthdate
                };
                _service.UpdatePerson(person);
                return Ok($"Person with id {id} updated.");
            } catch
            {
                return BadRequest("Couldn't update the person.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeletePerson(id);
                return Ok($"Person with id {id} deleted.");
            } catch
            {
                return BadRequest($"Couldn't delete the person with the ID {id}");
            }
        }
    }
}
