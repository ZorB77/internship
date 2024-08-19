using MovieApp.Models;
using MovieApplication.Models;

namespace MovieApplication.Services.Interfaces
{
    public interface IAPIService
    {
        //MOVIE API CALLS
        public string AddMovie(string title, DateTime releaseDate, string description, string genre, decimal budget, int duration);
        public List<Movie> GetAllMovies();
        public Movie GetMovieById(int id);
        public string DeleteMovie(int id);
        public string UpdateMovie(int id, string title, DateTime releaseDate, string description, string genre, decimal budget, int duration);
        public List<Movie> GetMoviesByGenre(string genre);
        public List<Movie> GetMoviesByYear(int year);
        public List<Movie> GetMoviesByDateInterval(int year1, int year2);

        //PERSON API CALLS
        public string AddPerson(string firstName, string lastName, DateTime birthday);
        public List<Person> GetAllPersons();
        public Person GetPersonById(int id);
        public string DeletePerson(int id);
        public string UpdatePerson(int id, string firstName, string lastName, DateTime birthday);

        //REVIEW API CALLS
        public string AddReview(int movieId, double rating, string comment, DateTime reviewDate, string reviewerName);
        public List<Review> GetAllReviews();
        public Review GetReviewById(int id);
        public string DeleteReview(int id);
        public string UpdateReview(int id, double rating, string comment, DateTime reviewDate, string reviewerName);
        public List<Review> GetReviewsByRating(double rating);
        public int GetAverageRatingForGivenMovie(int movieId);
        public List<Movie> Top10Movies();


        //ROLE API CALLS
        public string AddRole(int movieId, int personId, string name);
        public List<Role> GetAllRoles();
        public Role GetRoleById(int id);
        public string DeleteRole(int id);
        public string UpdateRole(int id, int movieId, int personId, string name);


        //STUDIO API CALLS
        public string AddStudio(string name, DateTime year, string location);
        public List<Studio> GetAllStudios();
        public Studio GetStudioById(int id);
        public string DeleteStudio(int id);
        public string UpdateStudio(int id, string name, DateTime year, string location);


        //MOVIE-STUDIO ASSOCIATIONS API CALLS
        public string AddMovieStudioAssociation(int movieId, int studioId);
        public List<MovieStudio> GetAllMovieStudiosAssociations();
        public List<Studio> GetStudiosForMovie(int movieId);
        public List<Movie> GetMoviesForStudio(int studioId);
        public string DeleteMovieStudioAssociation(int id);
        public string UpdateMovieStudioAssociation(int id, int movieId, int studioId);

    }
}
