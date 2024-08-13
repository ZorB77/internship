using Exercise1.ConfigDatabase;
using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Repository
{
    public class StudioRepository :IStudioRepository
    {

        private readonly MovieContext _movieContext;
        public StudioRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public void AddStudio(Studio studio)
        {
           foreach(var movie in studio.Movies)
            {
                _movieContext.Movies.Attach(movie);
            }
           _movieContext.Studios.Add(studio);
            _movieContext.SaveChanges();
        }

        public void DeleteStudio(int id)
        {
            var studio = _movieContext.Studios.Find(id);
            if (studio != null)
            {
                _movieContext.Studios.Remove(studio);
                _movieContext.SaveChanges();
            }
        }


        public IEnumerable<Studio> GetAll()
        {
            return _movieContext.Studios.Include(s => s.Movies).ToList();
        }

        public Studio GetStudio(string name)
        {
            return _movieContext.Studios.Include(m => m.Movies).FirstOrDefault(s => s.StudioName.ToLower() == name.ToLower());
        }

        public void UpdateStudio(Studio studio)
        {
           
            _movieContext.SaveChanges();
        }
    }
}
