using MovieWebAPI.Exceptions;
using MovieWebAPI.Persistance;

namespace Movies.Services
{
    internal class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task AddPersonAsync(int personID, string firstname, string lastname, DateTime birthdate, string email)
        {
            var existingPerson = await _repository.GetByIdAsync(personID);

            if (existingPerson != null)
            {
                throw new NotNullEntity("There is already a person with this id");
            }
            
            await _repository.AddAsync(new Person(personID, firstname, lastname, birthdate, email));

        }

        public async Task<List<Person>> GetAllAsync()
        {
            var people = await _repository.GetAllAsync();

            if (people == null) 
            {
                throw new NullList("No people in our database");
            }

            return people.ToList();
        }

        public async Task<Person> GetByIdAsync(int personId)
        {

            var person = await _repository.GetByIdAsync(personId);
            if (person == null)
            {
                throw new NullEntity(personId, "Person");
            }
            return person;
        }

        public async Task UpdatePersonAsync(int personID, string firstname, string lastname, DateTime birthdate, string email)
        {

            var person = await _repository.GetByIdAsync(personID);
            if (person == null)
            {
                throw new NullEntity(personID, "Person");
            }

            await _repository.UpdateAsync(new Person(personID, firstname, lastname, birthdate, email));
        }

        public async Task DeletePersonAsync(int personId)
        {

            var person = await _repository.GetByIdAsync(personId);
            if (person == null)
            {
                throw new NullEntity(personId, "Person");
            }

            await _repository.RemoveAsync(person);
        }

        public async Task<List<Person>> FilterPersonByDateAsync(DateTime dateStart, DateTime dateStop)
        {
            var people = await _repository.GetAllAsync();

            var filteredPeople = people.Where(person => person.Birthdate >= dateStart && person.Birthdate <= dateStop).ToList();

            if (filteredPeople == null)
            {
                throw new NullList($"There is no people born between {dateStart} - {dateStop} in our database");
            }

            return filteredPeople;
        }
    }
}
