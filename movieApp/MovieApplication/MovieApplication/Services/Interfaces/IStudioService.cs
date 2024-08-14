using MovieApplication.Models;

namespace MovieApplication.Services.Interfaces
{
    public interface IStudioService
    {
        public bool AddStudio(string name, DateTime year, string location);
        public List<Studio> GetAllStudios();
        public Studio GetStudioById(int id);
        public bool DeleteStudio(int id);
        public bool UpdateStudio(int studioId, string name, DateTime year, string location);
        public void StudioOptions();
    }
}
