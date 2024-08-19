using MovieApp.Models;
using MovieApplication.Models;

namespace MovieApplication.Services.Interfaces
{
    public interface IMovieStudioService
    {
        public bool AddMovieStudioAssociation(int movieId, int studioId);
        public List<MovieStudio> GetAllMovieStudiosAssociations();
        public List<Studio> GetStudiosForMovie(int movieId);
        public List<Movie> GetMoviesForStudio(int studioId);
        public bool DeleteMovieStudioAssociation(int id);
        public bool UpdateMovieStudioAssociation(int movieStudioId, int movieId, int studioId);
        public void MovieStudiosOptions();    }
}
