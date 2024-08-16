using AutoMapper;
using ETMovies.Models;
using ETMovies.Service;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.ModelsDTO;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private MovieService service;
        private ILogger<MoviesController> logger;
        private IMapper mapper;

        public MoviesController(MovieService service, ILogger<MoviesController> logger, IMapper mapper)
        {
            this.service = service;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<MovieReadDto> GetMovies(int page = 1, int pageSize = 10)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetMovies WAS CALLED");
            logger.LogInformation(" ------ ");
            var movies = service.GetMovies();
            var moviesDto = mapper.Map<List<MovieReadDto>>(movies);
            return moviesDto.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        [HttpGet("{id}")]
        public MovieReadDto GetMovie(int id)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetMovie{id} WAS CALLED");
            logger.LogInformation(" ------ ");
            var movie = service.GetMovie(id);
            if (movie == null)
            {
                logger.LogInformation("No movie found");
                return null;
            }
            var movieDto = mapper.Map<MovieReadDto>(movie);
            logger.LogInformation(" ------ ");
            logger.LogInformation($"Returning movie -> {movieDto.Title}");
            logger.LogInformation(" ------ ");
            return movieDto;
        }

        [HttpPost]
        public void Post(string title, string description, int year, string genre, int duration, decimal budget, int studioID)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Post WAS CALLED");
            logger.LogInformation(" ------ ");
            var movieDto = new MovieCUDto(title, description, year, genre, duration, budget);
            var movie = mapper.Map<Movie>(movieDto);
            service.AddMovie(movie, studioID);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Movie added succesfully");
            logger.LogInformation(" ------ ");

        }

        [HttpPut]
        public void Put(int id, string title, string description, int year, string genre, int duration, decimal budget)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Put WAS CALLED");
            logger.LogInformation(" ------ ");
            service.UpdateMovie(id, title, description, year, genre, duration, budget);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Movie updated succesfully");
            logger.LogInformation(" ------ ");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Delete{id} WAS CALLED");
            logger.LogInformation(" ------ ");
            service.DeleteMovie(id);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Movie deleted succesfully");
            logger.LogInformation(" ------ ");
        }
        [HttpDelete("{title}")]
        public void DeleteByTitle(string title)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Delete{title} WAS CALLED");
            logger.LogInformation(" ------ ");
            service.DeleteMovieByTitle(title);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Movie deleted succesfully");
            logger.LogInformation(" ------ ");
        }

        [HttpGet]
        public List<MovieReadDto> GetMoviesByDateRange(int startYear=1895, int endYear = 2024, int page = 1, int pageSize = 10)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetMoviesByDateRange WAS CALLED");
            logger.LogInformation(" ------ ");
            var filtered = service.GetMoviesByDateRange(startYear, endYear);
                if(filtered == null)
                {
                    logger.LogInformation("No movies found");
                    return null;
                }
            var filteredDto = mapper.Map<List<MovieReadDto>>(filtered);
            logger.LogInformation(" ------ ");
            logger.LogInformation($"Succesfully, returning {filteredDto.Count()} movies");
            logger.LogInformation(" ------ ");
            return filteredDto.Skip((page-1)*pageSize).Take(pageSize).ToList();
        }

        [HttpGet]
        public List<MovieReadDto> SortMoviesByNameAndGenre(int page = 1, int pageSize = 10)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("SortMoviesByNameAndGenre WAS CALLED");
            logger.LogInformation(" ------ ");
            var sorted = service.SortMoviesByNameAndGenre();
            if(sorted == null)
            {
                logger.LogInformation(" ------ ");
                logger.LogInformation("No movies found to be sorted");
                logger.LogInformation(" ------ ");
                return null;
            }
            var sortedDto = mapper.Map<List<MovieReadDto>>(sorted);
            logger.LogInformation(" ------ ");
            logger.LogInformation($"Succesfully, returning {sorted.Count()} movies");
            logger.LogInformation(" ------ ");
            return sortedDto.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        [HttpGet]
        public List<MovieReadDto> TopTenMoviesByRating()
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("TopTenMoviesByRating WAS CALLED");
            logger.LogInformation(" ------ ");
            var movies = service.TopTenMoviesByRating();
            var moviesDto = mapper.Map<List<MovieReadDto>>(movies);
            return moviesDto.ToList();
        }

        [HttpGet("{id}")]
        public double GetAverageRating(int id)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetAverageRating WAS CALLED");
            logger.LogInformation(" ------ ");
            return service.GetAverageRating(id); 
        }
    }
}
