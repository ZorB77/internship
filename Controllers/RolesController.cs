using Microsoft.AspNetCore.Mvc;
using MovieAppRESTAPI.DTOs.RoleDTOs;
using MovieAppRESTAPI.Services;
using MovieWinForms.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAppRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly RoleService _service;
        private readonly PersonService _personService;
        private readonly MovieService _movieService;

        public RolesController(RoleService service, PersonService personService, MovieService movieService)
        {
            _service = service;
            _personService = personService;
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetRoles().Select(r => new RoleDTO
                {
                    Id = r.Id,
                    Name = r.Name,
                    MovieId = r.Movie.Id,
                    PersonId = r.Person.Id
                }));
            } catch
            {
                return BadRequest("Couldn't get all the roles.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var role = _service.GetRole(id);
                return Ok(new RoleDTO             
                {
                    Id = role.Id,
                    Name = role.Name,
                    MovieId = role.Movie.Id,
                    PersonId = role.Person.Id
                });
            } catch
            {
                return NotFound($"Not found Role with ID {id}.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateRoleDTO newRoleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var role = new Role 
                {
                    Name = newRoleDTO.Name,
                    Movie = _movieService.GetMovieById(newRoleDTO.MovieId),
                    Person = _personService.GetPersonById(newRoleDTO.PersonId)
                };
                _service.AddRole(role);
                return Ok("Role added successfully");
            } catch
            {
                return BadRequest("Couldn't create the role.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateRoleDTO updatedRoleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var role = new Role
                {
                    Id = id,
                    Name = updatedRoleDTO.Name
                };
                _service.UpdateRole(role);
                return Ok("Role updated successfully");
            } catch
            {
                return BadRequest($"Couldn't update the role with the ID {id}.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try 
            {
                _service.DeleteRole(id);
                return Ok($"Successfully deleted the role with the ID {id}");
            }
            catch
            {
                return BadRequest($"Couldn't delete the role with the ID {id}.");
            }
        }

    }
}
