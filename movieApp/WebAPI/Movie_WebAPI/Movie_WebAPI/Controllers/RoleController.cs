using Microsoft.AspNetCore.Mvc;
using Movie_WebAPI.Services;
using MovieApp.Models;
using MovieApplication.Services;

namespace Movie_WebAPI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleService _roleService;
        private readonly LogService _logService;
        public RoleController(RoleService roleService, LogService logService)
        {
            _roleService = roleService;
            _logService = logService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/addRole")]
        [HttpPost]
        public string AddRole(int movieId, int personId, string name)
        {
            _logService.LogRequest("Add new role.");
            return _roleService.AddRole(movieId, personId, name);
        }

        [Route("api/getRoles")]
        [HttpGet]
        public List<Role> GetRoles()
        {
            _logService.LogRequest("Get all roles.");
            return _roleService.GetAllRoles();
        }

        [Route("api/getRoleById/ID={id}")]
        [HttpGet]
        public Role GetRoleById(int id)
        {
            _logService.LogRequest($"Get role with id {id}.");
            return _roleService.GetRoleById(id);
        }

        [Route("api/deleteRole/ID={id}")]
        [HttpDelete]
        public bool DeleteRole(int id)
        {
            _logService.LogRequest("Delete a role.");
            return _roleService.DeleteRole(id);
        }

        [Route("api/updateRole/ID={id}")]
        [HttpPut]
        public string UpdateRole(int id, int movieId, int personId, string name)
        {
            _logService.LogRequest("Update a role.");
            return _roleService.UpdateRole(id, movieId, personId, name);
        }
    }
}
