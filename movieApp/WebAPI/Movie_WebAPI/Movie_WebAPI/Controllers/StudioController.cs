using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApplication.Models;
using MovieApplication.Services;

namespace Movie_WebAPI.Controllers
{
    public class StudioController : Controller
    {
        private readonly StudioService _studioService;
        public StudioController(StudioService studioService)
        {
            _studioService = studioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/addStudio")]
        [HttpPost]
        public bool AddStudio(string name, DateTime year, string location)
        {
            return _studioService.AddStudio(name, year, location);
        }

        [Route("api/getStudios")]
        [HttpGet]
        public List<Studio> GetStudios()
        {
            return _studioService.GetAllStudios();
        }

        [Route("api/getStudioById/ID={id}")]
        [HttpGet]
        public Studio GetStudioById(int id)
        {
            return _studioService.GetStudioById(id);
        }

        [Route("api/deleteStudio/ID={id}")]
        [HttpDelete]
        public bool DeleteStudio(int id)
        {
            return _studioService.DeleteStudio(id);
        }

        [Route("api/updateStudio/ID={id}")]
        [HttpPut]
        public bool UpdateStudio(int id, string name, DateTime year, string location)
        {
            return _studioService.UpdateStudio(id, name, year, location);
        }
    }
}
