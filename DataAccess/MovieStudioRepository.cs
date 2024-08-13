using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieWinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieWinForms.DataAccess
{
    public class MovieStudioRepository
    {
        private MovieDbContext _context = new MovieDbContext();
        public void AddStudioToMovie(int movieId, int studioId)
        {
            var studio = StudioRepository.GetStudioById(studioId);
            var movie = GetMovieWithStudio(movieId);
            if (movie.Studios.Contains(studio)) 
            {
                MessageBox.Show("Studio already associated with movie!");
            } else
            {
                movie.Studios.Add(studio);
               // _context.Movies.Update(movie);
                _context.SaveChanges();
            }
        }
        public Movie GetMovieWithStudio(int movieId)
        {
            return _context.Movies.Include(m => m.Studios).Where(m => m.Id == movieId).FirstOrDefault();
        }
        public void DeleteStudioFromMovie(int movieId, int studioId)
        {
            var studio = StudioRepository.GetStudioById(studioId);
            var movie = GetMovieWithStudio(movieId);
            movie.Studios.Remove(studio);
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }
    }
}
