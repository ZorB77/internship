using AutoMapper;
using ETMovies.Models;
using ETMovies.Service;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.ModelsDTO;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : Controller
    {

        private RoleService service;
        ILogger<RolesController> logger;
        private IMapper mapper;
        public RolesController(RoleService roleService, ILogger<RolesController> logger, IMapper mapper)
        {
            service = roleService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<RoleReadDto> GetRoles(int page = 1, int pageSize = 10)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetRoles WAS CALLED");
            logger.LogInformation(" ------ ");
            var roles = service.GetRoles();
            if(roles == null)
            {
                logger.LogInformation("No roles found");
                return null;
            }
            var rolesDto = mapper.Map<List<RoleReadDto>>(roles);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Returning roles");
            logger.LogInformation(" ------ ");
            return rolesDto.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        }

        [HttpGet("{id}")]
        public RoleReadDto GetRole(int id)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetRole{id} WAS CALLED");
            logger.LogInformation(" ------ ");
            var role = service.GetRole(id);
            if (role == null)
            {
                logger.LogInformation("No role Found");
                return null;
            }
            var roleDto = mapper.Map<RoleReadDto>(role);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Returning role");
            logger.LogInformation(" ------ ");
            return roleDto;

        }

        [HttpPost]
        public void Post(string name, int personID, int movieID)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Post WAS CALLED");
            logger.LogInformation(" ------ ");
/*            var roleDto = new RoleReadDto(name, personID, movieID);
            var role = mapper.Map<Role>(roleDto);*/
            service.AddRole(name, movieID, personID);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Role added succesfully");
            logger.LogInformation(" ------ ");
        }

        [HttpPut]
        public void Put(int id, int movieID, int personID, string name)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Put WAS CALLED");
            logger.LogInformation(" ------ ");
            service.UpdateRole(id, movieID, personID, name);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Role updated succesfully");
            logger.LogInformation(" ------ ");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Delete{id} WAS CALLED");
            logger.LogInformation(" ------ ");
            service.DeleteRole(id);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Role deleted succesfully");
            logger.LogInformation(" ------ ");
        }

        [HttpGet]
        public List<string> FilteredActorsByRole(string role, int page = 1, int pageSize = 10)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetMoviesByDateRange WAS CALLED");
            logger.LogInformation(" ------ ");
            var filtered = service.FilterActorsByRole(role);
            if (filtered == null)
            {
                logger.LogInformation("No movies found");
                return null;
            }
            logger.LogInformation(" ------ ");
            logger.LogInformation($"Succesfully, returning {filtered.Count()} movies");
            logger.LogInformation(" ------ ");
            return filtered.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
