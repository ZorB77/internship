using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.Models;

public class MovieService
{
    private readonly MyDBContext _dbContext;

    public MovieService(MyDBContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
    {
        return await _dbContext.movies.ToListAsync();
    }

    public async Task<Movie> GetMovieAsync(int id)
    {
        return await _dbContext.movies.FirstOrDefaultAsync(m => m.ID == id);
    }

    public async Task AddMovieAsync(Movie movie)
    {
        _dbContext.movies.Add(movie);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateMovieAsync(int id, Movie movie)
    {
        if (id == movie.ID)
        {
            _dbContext.Update(movie);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteMovieAsync(int id)
    {
        var movie = _dbContext.movies.FirstOrDefault(m => m.ID == id);
        if (movie != null)
        {
            _dbContext.movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}
