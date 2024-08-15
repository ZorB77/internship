using ETMovies.Models;
using ETMovies.Service;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : Controller
    {

        private RoleService service;
        public RolesController(RoleService roleService)
        {
            service = roleService;
        }

        [HttpGet]
        public IEnumerable<Role> GetRoles(int page = 1, int pageSize = 10)
        {
            var roles = service.GetRoles().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return roles;

        }

        [HttpGet("{id}")]
        public Role GetRole(int id)
        {
            var role = service.GetRole(id);
            if (role == null)
                return null;
            return role;

        }

        [HttpPost]
        public void Post(string name, int personID, int movieID)
        {
            service.AddRole(name, movieID, personID);
        }

        [HttpPut]
        public void Put(int id, int movieID, int personID, string name)
        {
            service.UpdateRole(id, movieID, personID, name);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteRole(id);
        }

        [HttpGet]
        public List<string> FilteredActorsByRole(string role, int page = 1, int pageSize = 10)
        {
            var filtered = service.FilterActorsByRole(role);
            return filtered.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
