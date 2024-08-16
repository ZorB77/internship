using Microsoft.EntityFrameworkCore;
using MovieApp;
using MovieApp.Models;
using MovieApplication.Models;

namespace MovieApplication.Services
{
    public class StudioService
    {
        private readonly MovieContext _context;
        public StudioService(MovieContext context)
        {
            _context = context;
        }

        public string AddStudio(string name, DateTime year, string location)
        {
            try
            {
                var newStudio = new Studio
                {
                    Name = name,
                    Year = year,
                    Locatiton = location,
                };

                _context.Studios.Add(newStudio);
                _context.SaveChanges();
                return "Studio added succesfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Studio> GetAllStudios()
        {
            var studios = _context.Studios.AsNoTracking().ToList();

            if (studios.Count == 0)
            {
                throw new Exception("There are no studios!");
            }

            return studios;
        }

        public Studio GetStudioById(int id)
        {
            var studio = _context.Studios.FirstOrDefault(m => m.ID == id);

            if (studio != null)
            {
                return studio;
            }
            else
            {
                throw new Exception($"Studio with id {id} does not exits!");
            }
        }

        public string DeleteStudio(int id)
        {
            var studio = _context.Studios.Find(id);

            if (studio != null)
            {
                _context.Studios.Remove(studio);
                _context.SaveChanges();
                return "Studio deleted succesfully!";
            }
            else
            {
                return $"Studio with id {id} does not exits!";
            }
        }

        public string UpdateStudio(int studioId, string name, DateTime year, string location)
        {
            var studio = _context.Studios.FirstOrDefault(s => s.ID == studioId);

            if (studio != null)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    studio.Name = name;
                }

                if (!string.IsNullOrEmpty(year.ToShortDateString()))
                {
                    studio.Year = year;
                }

                if (!string.IsNullOrEmpty(location))
                {
                    studio.Locatiton = location;
                }

                _context.SaveChanges();
                return "Studio updated succesfully!";
            }
            else
            {

                return $"Studio with {studioId} does not exists!";
            }
        }

        public void StudioOptions()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Add a studio");
            Console.WriteLine("2 - Get studios list");
            Console.WriteLine("3 - Get studio by id");
            Console.WriteLine("4 - Delete a studio");
            Console.WriteLine("5 - Update a studio");
            Console.WriteLine("6 - Back to base options");
        }
    }
}
