using Microsoft.AspNetCore.Mvc;
using Movie_WebAPI.Helpers;
using Movie_WebAPI.Services;
using MovieApp.Models;
using MovieApp.Services;
using MovieApplication.Models;
using MovieApplication.Services;

namespace Movie_WebAPI.Controllers
{
    public class MovieStudioController : Controller
    {
        private readonly MovieStudioService _movieStudioService;
        private readonly LogService _logService;
        public MovieStudioController(MovieStudioService movieStudioService, LogService logService)
        {
            _movieStudioService = movieStudioService;
            _logService = logService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/addAssociation")]
        [HttpPost]
        public string AddMovieStudioAssociation([FromBody] MovieStudio movieStudio)
        {
            try
            {
                _logService.LogRequest("Add new movie-studio association.");
                return _movieStudioService.AddMovieStudioAssociation(movieStudio.MovieID, movieStudio.StudioID);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                return ex.Message;
            }
        }

        [Route("api/getAssociations")]
        [HttpGet]
        public List<MovieStudio> GetMovieStudiosAssociations([FromQuery]PaginationFilter filter)
        {
            try
            {
                _logService.LogRequest("Get all movie-studio associations.");
                return PagedList<MovieStudio>.ToPagedList(_movieStudioService.GetAllMovieStudiosAssociations().AsQueryable(), filter.PageNumber, filter.PageSize);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/getStudiosForMovie/movieID={movieId}")]
        [HttpGet]
        public List<Studio> GetStudiosForMovie(int movieId, [FromQuery]PaginationFilter filter)
        {
            try
            {
                _logService.LogRequest($"Get studios for movie {movieId}.");
                return PagedList<Studio>.ToPagedList(_movieStudioService.GetStudiosForMovie(movieId).AsQueryable(), filter.PageNumber, filter.PageSize);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/getMoviesForStudio/studioID={studioId}")]
        [HttpGet]
        public List<Movie> GetMoviesForStudio(int studioId, [FromQuery] PaginationFilter filter)
        {
            try
            {
                _logService.LogRequest($"Get movies for studio {studioId}.");
                return PagedList<Movie>.ToPagedList(_movieStudioService.GetMoviesForStudio(studioId).AsQueryable(), filter.PageNumber, filter.PageSize);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/deleteAssociation/ID={id}")]
        [HttpDelete]
        public string DeleteAssociation(int id)
        {
            try
            {
                _logService.LogRequest("Delete a movie-studio association.");
                return _movieStudioService.DeleteMovieStudioAssociation(id);
            }
            catch (Exception ex) {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/updateAssociation/ID={id}")]
        [HttpPut]
        public string UpdateAssociation([FromBody] MovieStudio movieStudio)
        {
            try
            {
                _logService.LogRequest("Update a movie-studio association.");
                return _movieStudioService.UpdateMovieStudioAssociation(movieStudio.ID, movieStudio.MovieID, movieStudio.StudioID);
            }
            catch (Exception ex) {
                _logService.LogResponse(ex.Message);
                return ex.Message;
            }
        }
    }
}
