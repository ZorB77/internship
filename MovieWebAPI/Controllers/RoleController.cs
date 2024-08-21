using Microsoft.AspNetCore.Mvc;
using MovieWebAPI.Models.DTOs;
using MovieWebAPI.Services.Interfaces;

namespace MovieWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> PostRole([FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _roleService.AddRoleAsync(roleDto.RoleId, roleDto.Movie, roleDto.Person, roleDto.Name, roleDto.Description);
            return CreatedAtAction(nameof(GetRolesOfPerson), new { personId = roleDto.Person }, roleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, [FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roleDto.RoleId)
            {
                return BadRequest($"There is no Role with ID {id}.");
            }

            await _roleService.UpdateRoleAsync(roleDto.RoleId, roleDto.Movie, roleDto.Person, roleDto.Name, roleDto.Description);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {

            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }

        [HttpGet("person/{personId}")]
        public async Task<IActionResult> GetRolesOfPerson(int personId)
        {

            var roles = await _roleService.GetRolesOfAPersonAsync(personId);
            return Ok(roles);
        }
    }
}
