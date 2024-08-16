using Microsoft.AspNetCore.Mvc;
using Movie_WebAPI.Services;
using MovieApp.Models;
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
        public string AddMovieStudioAssociation([FromBody]MovieStudio movieStudio)
        {
            _logService.LogRequest("Add new movie-studio association.");
            return _movieStudioService.AddMovieStudioAssociation(movieStudio.MovieID, movieStudio.StudioID);
        }

        [Route("api/getAssociations")]
        [HttpGet]
        public List<MovieStudio> GetMovieStudiosAssociations()
        {
            _logService.LogRequest("Get all movie-studio associations.");
            return _movieStudioService.GetAllMovieStudiosAssociations();
        }

        [Route("api/getStudiosForMovie/movieID={movieId}")]
        [HttpGet]
        public List<Studio> GetStudiosForMovie(int movieId)
        {
            _logService.LogRequest($"Get studios for movie {movieId}.");
            return _movieStudioService.GetStudiosForMovie(movieId);
        } 
        
        [Route("api/getMoviesForStudio/studioID={studioId}")]
        [HttpGet]
        public List<Movie> GetMoviesForStudio(int studioId)
        {
            _logService.LogRequest($"Get movies for studio {studioId}.");
            return _movieStudioService.GetMoviesForStudio(studioId);
        }

        [Route("api/deleteAssociation/ID={id}")]
        [HttpDelete]
        public bool DeleteAssociation(int id)
        {
            _logService.LogRequest("Delete a movie-studio association.");
            return _movieStudioService.DeleteMovieStudioAssociation(id);
        }

        [Route("api/updateAssociation/ID={id}")]
        [HttpPut]
        public string UpdateAssociation([FromBody]MovieStudio movieStudio)
        {
            _logService.LogRequest("Update a movie-studio association.");
            return _movieStudioService.UpdateMovieStudioAssociation(movieStudio.ID, movieStudio.MovieID, movieStudio.StudioID);
        }
    }
}
