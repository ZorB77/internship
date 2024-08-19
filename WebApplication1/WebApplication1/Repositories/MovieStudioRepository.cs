using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class MovieStudioRepository : IMovieStudioRepository
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<MovieStudioRepository> _logger;
        public MovieStudioRepository(DataContext dataContext, ILogger<MovieStudioRepository> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task AddMovieStudio(string movieName, string studioName)
        {
            _logger.LogInformation("AddMovieStudio method was called! ");
            var movie = await _dataContext.Movies.FirstOrDefaultAsync(m => m.Name == movieName);
            var studio = await _dataContext.Studios.FirstOrDefaultAsync(s => s.StudioName == studioName);

            if (movie == null || studio == null)
            {
                throw new KeyNotFoundException();
            }

            var movieStudio = new MovieStudio
            {
                MovieId = movie.Id,
                StudioId = studio.Id,
            };
            _dataContext.MovieStudios.Add(movieStudio);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteMovieStudio(string movieName, string studioName)
        {
            _logger.LogInformation("DeleteMovieStudio method was called! ");
            var movie = await _dataContext.Movies.FirstOrDefaultAsync(m => m.Name == movieName);
            var studio = await _dataContext.Studios.FirstOrDefaultAsync(s => s.StudioName == studioName);

            if (movie == null || studio == null)
            {
                throw new KeyNotFoundException();
            }

            var movieStudio = await _dataContext.MovieStudios.FirstOrDefaultAsync(m => m.MovieId == movie.Id && m.StudioId == studio.Id);

            if(movieStudio!= null)
            {
                _dataContext.MovieStudios.Remove(movieStudio);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MovieStudio>> GetAll()
        {
            return await _dataContext.MovieStudios.Include(m => m.Movie).Include(m => m.Studio).ToListAsync();
        }
        public async Task<IEnumerable<MovieStudio>> GetMoviesByStudioName(string studioName)
        {
            var studio = await _dataContext.Studios.FirstOrDefaultAsync(m => m.StudioName == studioName);
            if (studio == null)
            {
                throw new KeyNotFoundException("Studio not found");
            }

            return await _dataContext.MovieStudios.Where(ms => ms.StudioId == studio.Id).Include(ms => ms.Movie).ToListAsync();
        }

        public async Task<IEnumerable<MovieStudio>> GetStudiosByMovieName(string movieName)
        {
            var movie = await _dataContext.Movies.FirstOrDefaultAsync(s => s.Name == movieName);
            if (movie == null)
            {
                throw new KeyNotFoundException("Movie not found");
            }

            return await _dataContext.MovieStudios.Where(ms => ms.MovieId == movie.Id).Include(ms => ms.Studio).ToListAsync();
        }
    }
}
