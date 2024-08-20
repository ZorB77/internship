using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.Custom_Exceptions;
using MovieApplicationWebAPI.DataAccess;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Utilities;
using System.Diagnostics;


namespace MovieApplicationWebAPI.Services
{
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
            var existingMovie = await _dbContext.movies.FirstOrDefaultAsync(m => m.ID == id);
            if (existingMovie != null)
            {
                existingMovie.Name = movie.Name;
                existingMovie.Description = movie.Description;
                existingMovie.Genre = movie.Genre;
                existingMovie.ReleaseDate = movie.ReleaseDate;

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new MovieDoesNotExistException();
            }
        }

        public async Task DeleteMovieAsync(int id)
        {
            //Debug.WriteLine($"Id of the movie which is deleted is {id}...");
            var movie = _dbContext.movies.FirstOrDefault(m => m.ID == id);
            if (movie != null)
            {
                //Debug.WriteLine($"Deleting movie with id {id}...");
                _dbContext.movies.Remove(movie);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}