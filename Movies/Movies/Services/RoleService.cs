using Movies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    internal class RoleService
    {
        private readonly RoleRepository _repository;

        private readonly Repository<Movie> _movieRepository;

        private readonly Repository<Person> _personRepository;

        public RoleService(RoleRepository repository, Repository<Movie> movieRepository, Repository<Person> personRepository)
        {
            _repository = repository;
            _movieRepository = movieRepository;
            _personRepository = personRepository;
        }

        public void AddRole(int roleId, int movieId, int personId, string name, string description)
        {
            try
            {

                if (_movieRepository.GetById(movieId) == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }
                else if (_personRepository.GetById(personId) == null)
                {
                    throw new Exception("Error: there is no person with this id");
                }
                else if (name == null)
                {
                    throw new Exception("Error: the role name must not be null");
                }

                _repository.Add(new Role(roleId, _movieRepository.GetById(movieId), _personRepository.GetById(personId), name, description));

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
  
        public void UpdateRole(int roleId, int movieId, int personId, string name, string description)
        {
            try
            {
                if (_repository.GetById(roleId) == null)
                {
                    throw new Exception("Error: there is no role with this id");
                }

                _repository.Update(new Role(roleId, _movieRepository.GetById(movieId), _personRepository.GetById(personId), name, description));

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

        public List<Role> GetRolesOfAPerson(int personId)
        {
            return _repository.GetAll().Where(r => r.Person.PersonId == personId).ToList();
        }
    }
}
