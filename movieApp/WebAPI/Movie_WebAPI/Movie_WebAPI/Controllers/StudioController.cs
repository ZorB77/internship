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
            try
            {
                _logService.LogRequest("Add new studio.");
                return _studioService.AddStudio(studio.Name, studio.Year, studio.Locatiton);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                return ex.Message;
            }
        }

        [Route("api/getStudios")]
        [HttpGet]
        public List<Studio> GetStudios()
        {
            try
            {
                _logService.LogRequest("Get all studios.");
                return _studioService.GetAllStudios();
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/getStudioById/ID={id}")]
        [HttpGet]
        public Studio GetStudioById(int id)
        {
            try
            {
                _logService.LogRequest($"Get studio with id {id}.");
                return _studioService.GetStudioById(id);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/deleteStudio/ID={id}")]
        [HttpDelete]
        public bool DeleteStudio(int id)
        {
            try
            {
                _logService.LogRequest("Delete a studio.");
                return _studioService.DeleteStudio(id);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/updateStudio/ID={id}")]
        [HttpPut]
        public string UpdateStudio([FromBody] Studio studio)
        {
            try
            {
                _logService.LogRequest("Update a studio.");
                return _studioService.UpdateStudio(studio.ID, studio.Name, studio.Year, studio.Locatiton);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                return ex.Message;
            }
        }
    }
}
