using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApplication.Models;
using MovieApplication.Services;

namespace Movie_WebAPI.Controllers
{
    public class MovieStudioController : Controller
    {
        private readonly MovieStudioService _movieStudioService;
        public MovieStudioController(MovieStudioService movieStudioService)
        {
            _movieStudioService = movieStudioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/addAssociation")]
        [HttpPost]
        public string AddMovieStudioAssociation([FromBody]MovieStudio movieStudio)
        {
            return _movieStudioService.AddMovieStudioAssociation(movieStudio.MovieID, movieStudio.StudioID);
        }

        [Route("api/getAssociations")]
        [HttpGet]
        public List<MovieStudio> GetMovieStudiosAssociations()
        {
            return _movieStudioService.GetAllMovieStudiosAssociations();
        }

        [Route("api/getStudiosForMovie/movieID={movieId}")]
        [HttpGet]
        public List<Studio> GetStudiosForMovie(int movieId)
        {
            return _movieStudioService.GetStudiosForMovie(movieId);
        } 
        
        [Route("api/getMoviesForStudio/studioID={studioId}")]
        [HttpGet]
        public List<Movie> GetMoviesForStudio(int studioId)
        {
            return _movieStudioService.GetMoviesForStudio(studioId);
        }

        [Route("api/deleteAssociation/ID={id}")]
        [HttpDelete]
        public bool DeleteAssociation(int id)
        {
            return _movieStudioService.DeleteMovieStudioAssociation(id);
        }

        [Route("api/updateAssociation/ID={id}")]
        [HttpPut]
        public string UpdateAssociation([FromBody]MovieStudio movieStudio)
        {
            return _movieStudioService.UpdateMovieStudioAssociation(movieStudio.ID, movieStudio.MovieID, movieStudio.StudioID);
        }
    }
}
