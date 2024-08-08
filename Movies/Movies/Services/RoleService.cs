using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    internal class RoleService
    {
        private Repository<Role> _repository;

        private Repository<Movie> _movieRepository;

        private Repository<Person> _personRepository;

        public RoleService(Repository<Role> repository, Repository<Movie> movieRepository, Repository<Person> personRepository)
        {
            _repository = repository;
            _movieRepository = movieRepository;
            _personRepository = personRepository;
        }

        public void AddRole(int roleId, int movieId, int personId, string name)
        {
            try
            {
                if (roleId == null)
                {
                    throw new Exception("Error: the id must not be null");
                }
                else if (_repository.GetById(movieId) == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }
                else if (_repository.GetById(personId) == null)
                {
                    throw new Exception("Error: there is no person with this id");
                }
                else if (name == null)
                {
                    throw new Exception("Error: the role name must not be null");
                }

                _repository.Add(new Role(roleId, _movieRepository.GetById(movieId), _personRepository.GetById(personId), name));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public List<Role> GetAll()
        {
            return _repository.GetAll().ToList();
        }
  
        public void UpdateRole(int roleId, int movieId, int personId, string name)
        {
            try
            {
                if (_repository.GetById(roleId) == null)
                {
                    throw new Exception("Error: there is no role with this id");
                }

                _repository.Update(new Role(roleId, _movieRepository.GetById(movieId), _personRepository.GetById(personId), name));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteRole(int roleId)
        {
            try
            {
                if (_repository.GetById(roleId) == null)
                {
                    throw new Exception("Error: there is no role with this id");
                }

                _repository.Remove(_repository.GetById(roleId));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
