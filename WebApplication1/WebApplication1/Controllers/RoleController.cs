using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] RoleDTO roleDTO, [FromQuery] string movieName, [FromQuery] string firstName, [FromQuery] string lastName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _roleRepository.AddRole(roleDTO, movieName, firstName, lastName);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRoleByID(int id)
        {
            var role = await _roleRepository.GetRoleByID(id);
            if (role == null)
            {
                return NotFound("Role not found");
            }
            return Ok(role);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<RoleDTO>> GetRoleByName(string name)
        {
            var role = await _roleRepository.GetRoleByName(name);
            if (role == null)
            {
                return NotFound("Role not found");
            }
            return Ok(role);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleDTO roleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _roleRepository.UpdateRole(id, roleDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleRepository.DeleteRole(id);
            return Ok();
        }

        [HttpGet("movie/{movieName}")]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRolesByMovieName(string movieName)
        {
            var roles = await _roleRepository.GetRolesByMovieName(movieName);
            return Ok(roles);
        }

        [HttpGet("person")]
        public async Task<ActionResult<RoleDTO>> GetRoleByPersonName([FromQuery] string firstName, [FromQuery] string lastName)
        {
            var role = await _roleRepository.GetRoleByPersonName(firstName, lastName);
            return Ok(role);
        }
    }
}
