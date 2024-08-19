using MovieApp.Models;

namespace MovieApplication.Services.Interfaces
{
    public interface IMovieService
    {
        public bool AddMovie(string title, DateTime releaseDate, string description, string genre, decimal budget, int duration);
        public List<Movie> GetAllMovies();
        public Movie GetMovieById(int id);
        public bool DeleteMovie(int id);
        public bool UpdateMovie(int movieId, string title, DateTime releaseDate, string description, string genre, decimal budget, int duration);
        public List<Movie> FilterMoviesByGenre(string genre);
        public List<Movie> FilterMoviesByYear(int year);
        public List<Movie> FilterMoviesByDateInterval(int year1, int year2);
        public void MovieOptions();
    }
}
