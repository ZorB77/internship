using Microsoft.AspNetCore.Mvc;
using Movie_WebAPI.Services;
using MovieApp.Models;
using MovieApplication.Models;
using MovieApplication.Services;

namespace Movie_WebAPI.Controllers
{
    public class StudioController : Controller
    {
        private readonly StudioService _studioService;
        private readonly LogService _logService;
        public StudioController(StudioService studioService, LogService logService)
        {
            _studioService = studioService;
            _logService = logService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/addStudio")]
        [HttpPost]
        public string AddStudio([FromBody] Studio studio)
        {
            _logService.LogRequest("Add new studio.");
            return _studioService.AddStudio(studio.Name, studio.Year, studio.Locatiton);
        }

        [Route("api/getStudios")]
        [HttpGet]
        public List<Studio> GetStudios()
        {
            _logService.LogRequest("Get all studios.");
            return _studioService.GetAllStudios();
        }

        [Route("api/getStudioById/ID={id}")]
        [HttpGet]
        public Studio GetStudioById(int id)
        {
            _logService.LogRequest($"Get studio with id {id}.");
            return _studioService.GetStudioById(id);
        }

        [Route("api/deleteStudio/ID={id}")]
        [HttpDelete]
        public bool DeleteStudio(int id)
        {
            _logService.LogRequest("Delete a studio.");
            return _studioService.DeleteStudio(id);
        }

        [Route("api/updateStudio/ID={id}")]
        [HttpPut]
        public string UpdateStudio([FromBody] Studio studio)
        {
            _logService.LogRequest("Update a studio.");
            return _studioService.UpdateStudio(studio.ID, studio.Name, studio.Year, studio.Locatiton);
        }
    }
}
