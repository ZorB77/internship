using ETMovies.DatabaseContext;
using ETMovies.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Service
{
    public class MovieService
    {
        public MyDbContext Context;

        public MovieService(MyDbContext context)
        {
            Context = context;
        }

        #region MoviesCRUD

        // Add a movie
        public void AddMovie(Movie movie, int studioID)
        {
            var studio = Context.Studios.FirstOrDefault(s => s.ID == studioID);

            if (studioID != null)
            { 
            studio.Movies.Add(movie);
            movie.Studios.Add(studio);
            Context.Movies.Add(movie);
            Context.SaveChanges();
            }
        }

        // Select * movies
        public List<Movie> GetMovies()
        {
            return Context.Movies.AsNoTracking().Include( s=> s.Studios).Include(r => r.Reviews).ToList();
        }

        public Movie GetMovie(int id)
        {
            var movie = Context.Movies.AsNoTracking().Include(s => s.Studios).Include(r => r.Reviews).FirstOrDefault(m => m.ID == id);
            return movie;
        }

        // Update a movie

        public void UpdateMovie(int index, string title, string description, int year, string genre, int duration, decimal budget)
        {
            var movieToUpdate = Context.Movies.FirstOrDefault(m => m.ID == index);
            if (movieToUpdate != null)
            {
                movieToUpdate.Title = title;
                movieToUpdate.Description = description;
                movieToUpdate.Year = year;
                movieToUpdate.Genre = genre;
                movieToUpdate.Duration = duration;
                movieToUpdate.Budged = budget;
                Context.SaveChanges();

            }
        }

        // Delete a movie

        public void DeleteMovie(int index)
        {
            var movieToDelete = Context.Movies.First(m => m.ID == index);
            if (movieToDelete != null)
            {
                Context.Movies.Remove(movieToDelete);
                Context.SaveChanges();
            }

        }

        // Delete a movie by title

        public void DeleteMovieByTitle(string title)
        {
            var movieToDelete = Context.Movies.First(m => m.Title == title);
            if (movieToDelete != null)
            {

                Context.Movies.Remove(movieToDelete);
                Context.SaveChanges();
            }
        }

        #endregion

        #region requirements

        public List<Movie> GetMoviesByDateRange(int startYear, int endYear)
        {
            return Context.Movies.AsNoTracking().Include(s => s.Studios).Include(r => r.Reviews).Where(m => m.Year >= startYear && m.Year <= endYear).ToList();
        }

        public List<Movie> SortMoviesByNameAndGenre()
        {
            return Context.Movies.AsNoTracking().Include(s => s.Studios).Include(r => r.Reviews).OrderBy(m => m.Title).ThenBy(m => m.Genre).ToList();
        }

        public List<Movie> TopTenMoviesByRating()
        {
            return Context.Movies.AsNoTracking().Include(s => s.Studios).Include(r => r.Reviews).AsEnumerable().OrderByDescending(t => t.GetAverageRating()).Take(10).ToList();
        }

        public double GetAverageRating(int movieID)
        {
            var movie = Context.Movies.Include(r => r.Reviews).FirstOrDefault(m => m.ID == movieID);
            if (movie != null)
            {
                return movie.GetAverageRating();
            }
            return 0.0;
        }

        #endregion

    }
}
