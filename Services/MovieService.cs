using MovieAppRESTAPI.Repositories;
using MovieWinForms.Models;

namespace MovieAppRESTAPI.Services
{
    public class MovieService
    {
        private readonly IRepository<Movie> _repository;

        public MovieService(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        public void AddMovie(Movie entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Movie> GetPaginatedMovies(int pageNr, int pageSize)
        {
            return _repository.GetAll().Skip((pageNr - 1) * pageSize).Take(pageSize).ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateMovie(Movie entity)
        {
            var movie = _repository.GetById(entity.Id);
            movie.Name = entity.Name;
            movie.Description = entity.Description;
            movie.Year  = entity.Year;
            movie.Director = entity.Director;
            if (entity.Studios != null)
            {
                movie.Studios = entity.Studios;
            }
            _repository.Update(movie);
        }

        public void DeleteMovie(int id)
        {
            try
            {
                _repository.Delete(id);
            } catch
            {
                throw new Exception();
            }
        }

    }
}
