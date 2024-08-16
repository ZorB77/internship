using Microsoft.AspNetCore.Mvc;
using Movie_WebAPI.Helpers;
using Movie_WebAPI.Services;
using MovieApp.Models;
using MovieApp.Services;
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
        public ActionResult<string> AddStudio([FromBody] Studio studio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
        public ActionResult<PagedList<Studio>> GetStudios([FromQuery] PaginationFilter filter)
        {
            try
            {
                _logService.LogRequest("Get all studios.");
                return PagedList<Studio>.ToPagedList(_studioService.GetAllStudios().AsQueryable(), filter.PageNumber, filter.PageSize);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/getStudioById/ID={id}")]
        [HttpGet]
        public ActionResult<Studio> GetStudioById(int id)
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
        public ActionResult<string> DeleteStudio(int id)
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
        public ActionResult<string> UpdateStudio([FromBody] Studio studio)
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
