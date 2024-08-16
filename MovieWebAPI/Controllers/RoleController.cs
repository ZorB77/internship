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
            try
            {
                var roles = await _roleService.GetAllAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRole([FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _roleService.AddRoleAsync(roleDto.RoleId, roleDto.Movie, roleDto.Person, roleDto.Name, roleDto.Description);
                return CreatedAtAction(nameof(GetRolesOfPerson), new { personId = roleDto.Person }, roleDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, [FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (id != roleDto.RoleId)
                {
                    return BadRequest($"There is no Role with ID {id}.");
                }

                await _roleService.UpdateRoleAsync(roleDto.RoleId, roleDto.Movie, roleDto.Person, roleDto.Name, roleDto.Description);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                await _roleService.DeleteRoleAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("person/{personId}")]
        public async Task<IActionResult> GetRolesOfPerson(int personId)
        {
            try
            {
                var roles = await _roleService.GetRolesOfAPersonAsync(personId);
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
