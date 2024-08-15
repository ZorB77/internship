using ETMovies.Models;
using ETMovies.Service;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudiosController : Controller
    {
        private StudioService service;
        public StudiosController(StudioService studioService)
        {
            service = studioService;
        }

        [HttpGet]
        public IEnumerable<Studio> GetStudios(int page = 1, int pageSize = 10)
        {
            var studios = service.GetStudios().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return studios;

        }

        [HttpGet("{id}")]
        public Studio GetStudio(int id)
        {
            var studio = service.GetStudio(id);
            if (studio == null)
                return null;
            return studio;

        }

        [HttpPost]
        public void Post(string title, int year, string location)
        {
            var studio = new Studio(title, year, location);
            service.AddStudio(studio);
        }

        [HttpPut]
        public void Put(int id, string title, int year, string location)
        {
            service.UpdateStudio(id, title, year, location);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteStudio(id);
        }

        [HttpGet]
        public List<string> GetStudiosWithTheirMovies(int page = 1, int pageSize = 10)
        {
            var studios = service.GetStudiosWithMovies();
            return studios.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

    }
}
