using MovieWebAPI.Persistance;

namespace Movies.Services
{
    internal class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _repository;

        public MovieService(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        public async Task AddMovieAsync(int movieId, string name, int year, string description, string genre, int duration)
        {
            try
            {
                var existingMovie = await _repository.GetByIdAsync(movieId);
                if (existingMovie != null)
                {
                    throw new Exception("Error: there is already a movie with this id");
                }
                else if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("Error: the name of the movie must not be null");
                }
                else if (year < 0 || year > 10000)
                {
                    throw new Exception("Error: the year of the movie is not valid");
                }
                else if (duration < 0)
                {
                    throw new Exception("Error: the duration of the movie is not valid");
                }

                await _repository.AddAsync(new Movie(movieId, name, year, description, genre, duration));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            var movies = await _repository.GetAllAsync();
            return movies.ToList();
        }

        public async Task<Movie> GetByIdAsync(int movieId)
        {
            try
            {
                var movie = await _repository.GetByIdAsync(movieId);
                if (movie == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }
                return movie;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task UpdateMovieAsync(int movieId, string name, int year, string description, string genre, int duration)
        {
            try
            {
                var movie = await _repository.GetByIdAsync(movieId);
                if (movie == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }

                await _repository.UpdateAsync(new Movie(movieId, name, year, description, genre, duration));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteMovieAsync(int movieId)
        {
            try
            {
                var movie = await _repository.GetByIdAsync(movieId);
                if (movie == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }

                await _repository.RemoveAsync(movie);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Movie>> SortByTitleAsync()
        {
            var movies = await _repository.GetAllAsync();
            return movies.OrderBy(movie => movie.Name).ToList();
        }

        public async Task<List<Movie>> SortByYearAsync()
        {
            var movies = await _repository.GetAllAsync();
            return movies.OrderBy(movie => movie.Year).ToList();
        }

        public async Task<List<Movie>> FilterMoviesByDateAsync(DateTime dateStart, DateTime dateStop)
        {
            var movies = await _repository.GetAllAsync();
            return movies.Where(movie => movie.Year >= dateStart.Year && movie.Year <= dateStop.Year).ToList();
        }

        public async Task<List<Movie>> FilterMoviesByGenreAsync(string genre)
        {
            var movies = await _repository.GetAllAsync();
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
            return movies.Where(movie => movie.Year == year).ToList();
        }
    }
}
