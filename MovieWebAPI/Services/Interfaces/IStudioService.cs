using System.Collections.Generic;

namespace Movies.Services
{
    public interface IStudioService
    {
        void AddStudio(int id, string name, int year, string location);
        Studio GetById(int id);
        List<Studio> GetStudios();
    }
}