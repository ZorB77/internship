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

        public bool AddStudio(string name, DateTime year, string location)
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Studio> GetAllStudios()
        {
            return _context.Studios.ToList();
        }

        public Studio GetStudioById(int id)
        {
            return _context.Studios.FirstOrDefault(m => m.ID == id);
        }

        public bool DeleteStudio(int id)
        {
            var studio = _context.Studios.Find(id);

            if (studio != null)
            {
                _context.Studios.Remove(studio);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateStudio(int studioId, string name, DateTime year, string location)
        {
            var studio = _context.Studios.FirstOrDefault(s => s.ID == studioId);

            if (studio != null)
            {
                studio.Name = name;
                studio.Year = year;
                studio.Locatiton = location;

                _context.SaveChanges();
                return true;
            }
            return false;
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
