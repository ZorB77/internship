using Microsoft.AspNetCore.Mvc;
using Movie_WebAPI.Helpers;
using Movie_WebAPI.Services;
using MovieApp.Models;
using MovieApp.Services;
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
            try
            {
                _logService.LogRequest("Add new role.");
                return _roleService.AddRole(movieId, personId, name);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                return ex.Message;
            }
        }

        [Route("api/getRoles")]
        [HttpGet]
        public List<Role> GetRoles([FromQuery]PaginationFilter filter)
        {
            try
            {
                _logService.LogRequest("Get all roles.");
                return PagedList<Role>.ToPagedList(_roleService.GetAllRoles().AsQueryable(), filter.PageNumber, filter.PageSize);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/getRoleById/ID={id}")]
        [HttpGet]
        public Role GetRoleById(int id)
        {
            try
            {
                _logService.LogRequest($"Get role with id {id}.");
                return _roleService.GetRoleById(id);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/deleteRole/ID={id}")]
        [HttpDelete]
        public string DeleteRole(int id)
        {
            try
            {
                _logService.LogRequest("Delete a role.");
                return _roleService.DeleteRole(id);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/updateRole/ID={id}")]
        [HttpPut]
        public string UpdateRole(int id, int movieId, int personId, string name)
        {
            try
            {
                _logService.LogRequest("Update a role.");
                return _roleService.UpdateRole(id, movieId, personId, name);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                return ex.Message;
            }
        }
    }
}
