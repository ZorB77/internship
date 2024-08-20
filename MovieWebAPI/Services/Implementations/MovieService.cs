using MovieWebAPI.Exceptions;
using MovieWebAPI.Persistance;

namespace Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _repository;

        public MovieService(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        public async Task AddMovieAsync(int movieId, string name, int year, string description, string genre, int duration)
        {

            var existingMovie = await _repository.GetByIdAsync(movieId);
            if (existingMovie != null)
            {
                throw new NotNullEntity("There is already a movie with this id");
            }

            await _repository.AddAsync(new Movie(movieId, name, year, description, genre, duration));

        }

        public async Task<List<Movie>> GetAllAsync()
        {
            var movies = await _repository.GetAllAsync();
            return movies.ToList();
        }

        public async Task<Movie> GetByIdAsync(int movieId)
        {

            var movie = await _repository.GetByIdAsync(movieId);
            if (movie == null)
            {
                throw new NullEntity(movieId, "Movie");
            }
            return movie;
        }

        public async Task UpdateMovieAsync(int movieId, string name, int year, string description, string genre, int duration)
        {

            var movie = await _repository.GetByIdAsync(movieId);
            if (movie == null)
            {
                throw new NullEntity(movieId, "Movie");
            }

            await _repository.UpdateAsync(new Movie(movieId, name, year, description, genre, duration));
        }

        public async Task DeleteMovieAsync(int movieId)
        {

            var movie = await _repository.GetByIdAsync(movieId);
            if (movie == null)
            {
                throw new NullEntity(movieId, "Movie");
            }

            await _repository.RemoveAsync(movie);
        }
        public async Task<List<Movie>> SortByTitleAsync()
        {
            var movies = await _repository.GetAllAsync();

            if(movies == null)
            {
                throw new NullList("No movies in our database");
            }

            return movies.OrderBy(movie => movie.Name).ToList();
        }

        public async Task<List<Movie>> SortByYearAsync()
        {
            var movies = await _repository.GetAllAsync();

            if(movies == null)
            {
                throw new NullList("No movies in our database");
            }

            return movies.OrderBy(movie => movie.Year).ToList();
        }

        public async Task<List<Movie>> FilterMoviesByDateAsync(DateTime dateStart, DateTime dateStop)
        {
            var movies = await _repository.GetAllAsync();

            if (movies == null)
            {
                throw new NullList($"No movies between: {dateStart} - {dateStop} in our database");
            }

            return movies.Where(movie => movie.Year >= dateStart.Year && movie.Year <= dateStop.Year).ToList();
        }

        public async Task<List<Movie>> FilterMoviesByGenreAsync(string genre)
        {
            var movies = await _repository.GetAllAsync();

            if (movies == null)
            {
                throw new NullList($"No movies with genre: {genre} in our database");
            }

            return movies.Where(movie => movie.Genre.ToLower() == genre.ToLower()).ToList();
        }

        public async Task<bool> CheckIfExistsAsync(int id)
        {
            var movie = await _repository.GetByIdAsync(id);
            return movie != null;
        }

        public async Task<List<Movie>> FilterMoviesByYearAsync(int year)
        {
            var movies = await _repository.GetAllAsync();

            if(movies == null)
            {
                throw new NullList($"No movies in the year {year} in our database");
            }

            return movies.Where(movie => movie.Year == year).ToList();
        }
    }
}
