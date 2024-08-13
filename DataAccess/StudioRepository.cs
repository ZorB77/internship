using Microsoft.EntityFrameworkCore;
using MovieWinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWinForms.DataAccess
{
    public class StudioRepository
    {

        private static MovieDbContext _context = new MovieDbContext();
        public static void CreateStudio(Studio studio)
        {
            _context.Add(studio);
            _context.SaveChanges();
        }
        public static List<Studio> GetStudios()
        {
            var studios = _context.Studios.ToList();
            return studios;
        }
        public static Studio GetStudioById(int id)
        {
            return _context.Studios.Where(s => s.Id == id).FirstOrDefault();
        }
        public static void UpdateStudio(int id, Studio newStudio)
        {
            var studio = GetStudioById(id);
            studio.Name = newStudio.Name;
            studio.Location = newStudio.Location;
            studio.Year = newStudio.Year;
            _context.Update(studio);
            _context.SaveChanges();
        }
        public static void DeleteStudio(int id)
        {
            var studio = GetStudioById(id);
            _context.Remove(studio);
            _context.SaveChanges();
        }
    }
}
