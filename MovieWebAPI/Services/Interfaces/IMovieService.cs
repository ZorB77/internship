using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Movies.Services
{
    public interface IMovieService
    {
        Task AddMovieAsync(int movieId, string name, int year, string description, string genre, int duration);
        Task<bool> CheckIfExistsAsync(int id);
        Task DeleteMovieAsync(int movieId);
        Task<List<Movie>> FilterMoviesByDateAsync(DateTime dateStart, DateTime dateStop);
        Task<List<Movie>> FilterMoviesByGenreAsync(string genre);
        Task<List<Movie>> FilterMoviesByYearAsync(int year);
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int movieId);
        Task<List<Movie>> SortByTitleAsync();
        Task<List<Movie>> SortByYearAsync();
        Task UpdateMovieAsync(int movieId, string name, int year, string description, string genre, int duration);
    }
}