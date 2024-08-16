using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Movies.Services
{
    public interface IMovieService
    {
        void AddMovie(int movieId, string name, int year, string description, string genre, int duration);
        bool CheckIfExists(int id);
        void DeleteMovie(int movieId);
        List<Movie> FilterMoviesByDate(DateTime dateStart, DateTime dateStop);
        List<Movie> FilterMoviesByGenre(string genre);
        List<Movie> FilterMoviesByYear(int year);
        List<Movie> GetAll();
        Movie GetById(int movieId);
        List<Movie> SortbyTitle();
        List<Movie> SortbyYear();
        void UpdateMovie(int movieId, string name, int year, string description, string genre, int duration);
    }
}