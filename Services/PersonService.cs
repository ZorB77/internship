using MovieAppRESTAPI.Repositories;
using MovieWinForms.Models;

namespace MovieAppRESTAPI.Services
{
    public class PersonService
    {
        private readonly IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public void AddPerson(Person entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<Person> GetPeople()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Person> GetPaginatedPeople(int pageNr, int pageSize)
        {
            return _repository.GetAll().Skip((pageNr-1)*pageSize).Take(pageSize);
        }

        public Person GetPersonById(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdatePerson(Person entity)
        {
            var person = _repository.GetById(entity.Id);
            person.FirstName = entity.FirstName;
            person.LastName = entity.LastName;
            person.Birthdate = entity.Birthdate;
            _repository.Update(entity);
        }

        public void DeletePerson(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch
            {
                throw new Exception();
            }
        }

    }
}
