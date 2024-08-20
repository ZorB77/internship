using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Services;
using MovieApplicationWebAPI.Utilities;

namespace MovieApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private RoleService _roleService;
        private LogWriter _logWriter;

        public RolesController(RoleService roleService, LogWriter logWriter)
        {
            _roleService = roleService;
            _logWriter = logWriter;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            _logWriter.Log($"Get roles.");
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
            _logWriter.Log($"Get role with id {id}.");
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, RoleMapper roleMapper)
        {
            await _roleService.UpdateRoleAsync(id, roleMapper);
            _logWriter.Log($"Update role with id {id}.");
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostRole(RoleMapper roleMapper)
        {
            await _roleService.AddRoleAsync(roleMapper);
            _logWriter.Log($"Post role: {roleMapper.Name}.");
            return CreatedAtAction(nameof(GetRole), new { id = roleMapper.ID }, roleMapper);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {

            _roleService.DeleteRoleAsync(id);
            _logWriter.Log($"Delete role with id {id}.");
            return NoContent();
        }
    }
}
