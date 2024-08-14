using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Services;

namespace MovieApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private RoleService _roleService;

        public RolesController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _roleService.GetRoleAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            await _roleService.UpdateRoleAsync(id, role);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostRole(Role role)
        {
            _roleService.AddRoleAsync(role);
            return CreatedAtAction(nameof(GetRole), new { id = role.ID }, role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {

            _roleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
