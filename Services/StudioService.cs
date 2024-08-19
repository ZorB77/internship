using MovieAppRESTAPI.Repositories;
using MovieWinForms.Models;

namespace MovieAppRESTAPI.Services
{
    public class StudioService
    {
        private readonly IRepository<Studio> _repository;

        public StudioService(IRepository<Studio> repository)
        {
            _repository = repository;
        }

        public void AddStudio(Studio studio)
        {
            _repository.Add(studio);
        }

        public IEnumerable<Studio> GetAllStudios()
        {
            return _repository.GetAll();
        }

        public Studio GetStudio(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateStudio(Studio entity) 
        { 
            var studio = _repository.GetById(entity.Id);
            studio.Name = entity.Name;
            studio.Location = entity.Location;
            studio.Year = entity.Year;
            _repository.Update(studio);
        }

        public void DeleteStudio(int id)
        {
            _repository.Delete(id);
        }
    }
}
