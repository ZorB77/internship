using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    internal class StudioService : IStudioService
    {
        private readonly IRepository<Studio> _repository;

        public StudioService(IRepository<Studio> repository)
        {
            _repository = repository;
        }

        public void AddStudio(int id, string name, int year, string location)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
                }

                if (string.IsNullOrEmpty(location))
                {
                    throw new ArgumentException($"'{nameof(location)}' cannot be null or empty.", nameof(location));
                }

                _repository.Add(new Studio(id, name, year, location));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public List<Studio> GetStudios()
        {
            return _repository.GetAll().ToList();
        }

        public Studio GetById(int id)
        {

            return _repository.GetById(id);

        }
    }
}
