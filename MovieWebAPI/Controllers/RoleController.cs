using Microsoft.AspNetCore.Mvc;
using Movies.Services;
using MovieWebAPI.Models.DTOs;
using MovieWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public IActionResult GetRoles()
        {
            try
            {
                var roles = _roleService.GetAll();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

       [HttpPost]
        public IActionResult PostRole([FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _roleService.AddRole(roleDto.RoleId, roleDto.Movie, roleDto.Person, roleDto.Name, roleDto.Description);
                return CreatedAtAction(nameof(GetRolesOfPerson), new { id = roleDto.Person }, roleDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutRole(int id, [FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (id != roleDto.RoleId)
                {
                    return BadRequest();
                }

                _roleService.UpdateRole(roleDto.RoleId, roleDto.Movie, roleDto.Person, roleDto.Name, roleDto.Description);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            try
            {
                _roleService.DeleteRole(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("person/{personId}")]
        public IActionResult GetRolesOfPerson(int personId)
        {
            try
            {
                var roles = _roleService.GetRolesOfAPerson(personId);
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }


}
