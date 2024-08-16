using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApplication.Services;

namespace Movie_WebAPI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/addRole")]
        [HttpPost]
        public string AddRole(int movieId, int personId, string name)
        {
            return _roleService.AddRole(movieId, personId, name);
        }

        [Route("api/getRoles")]
        [HttpGet]
        public List<Role> GetRoles()
        {
            return _roleService.GetAllRoles();
        }

        [Route("api/getRoleById/ID={id}")]
        [HttpGet]
        public Role GetRoleById(int id)
        {
            return _roleService.GetRoleById(id);
        }

        [Route("api/deleteRole/ID={id}")]
        [HttpDelete]
        public bool DeleteRole(int id)
        {
            return _roleService.DeleteRole(id);
        }

        [Route("api/updateRole/ID={id}")]
        [HttpPut]
        public string UpdateRole(int id, int movieId, int personId, string name)
        {
            return _roleService.UpdateRole(id, movieId, personId, name);
        }
    }
}
