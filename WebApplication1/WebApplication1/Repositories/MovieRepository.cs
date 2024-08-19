using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class MovieRepository :IMovieRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<MovieRepository> _logger;

        public MovieRepository(DataContext dataContext, IMapper mapper, ILogger<MovieRepository> logger)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddMovie(MovieDTO movieDTO)
        {
            _logger.LogInformation("Add Movie method was called! ");
            var movie = _mapper.Map<Movie>(movieDTO);
            _dataContext.Movies.Add(movie);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteMovie(string name)
        {
            _logger.LogInformation("Delete method was called! ");
            var movie = await _dataContext.Movies.FirstOrDefaultAsync(m =>m.Name == name);

            if (movie != null)
            {
                _dataContext.Movies.Remove(movie);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<PagedList<MovieDTO>> GetAllMovies(Parameters parameters)
        {
            _logger.LogInformation("GetAllMovies method was called! ");
            var movies = _dataContext.Movies.AsQueryable();
            var pagedMovies = await PagedList<Movie>.ToPagedList(movies, parameters.PageNumber, parameters.PageSize);
            var mappedMovies = _mapper.Map<List<MovieDTO>>(pagedMovies);
            var pagedMoviesDto = new PagedList<MovieDTO>( mappedMovies,pagedMovies.TotalCount,pagedMovies.CurrentPage,pagedMovies.PageSize);
            return pagedMoviesDto;
        }

            public async Task<MovieDTO> GetMovieByName(string name)
        {
            _logger.LogInformation("GetMovieByName method was called! ");
            var movie = await _dataContext.Movies.FirstOrDefaultAsync(m => m.Name == name);
            return _mapper.Map<MovieDTO>(movie);
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByGenre(string genre)
        {
            var movies = await _dataContext.Movies.Where(m => m.Genre == genre).ToListAsync();
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);

        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByGenreAndYear(string genre, int year)
        {
            var movie =  await _dataContext.Movies.Where(m =>m.Genre == genre && m.Year == year).ToListAsync();
            return _mapper.Map<IEnumerable<MovieDTO>>(movie);
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByYear(int year)
        {
           var movie = await _dataContext.Movies.Where(m =>m.Year == year).ToListAsync();
            return _mapper.Map<IEnumerable<MovieDTO>>(movie);

        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByYearRange(int startYear, int endYear)
        {
            var movie = await _dataContext.Movies.Where(m =>m.Year >= startYear &&  m.Year <= endYear).ToListAsync();
            return _mapper.Map<IEnumerable<MovieDTO>>(movie);
        }

        public async Task<IEnumerable<MovieDTO>> GetTopTenMovies()
        {
          var movie =  await _dataContext.Movies.OrderByDescending(m => m.Year).Take(10).ToListAsync();
          return _mapper.Map<IEnumerable<MovieDTO>>(movie);
        }

        public async Task UpdateMovie(MovieDTO movieDTO, string name)
        {
            var movie = await _dataContext.Movies.FirstOrDefaultAsync(m => m.Name == name);

            if (movie != null)
            {
                _mapper.Map(movieDTO, movie);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
