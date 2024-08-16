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
            try
            {
                var existingPerson = await _repository.GetByIdAsync(personID);
                if (existingPerson != null)
                {
                    throw new Exception("Error: there is already a person with this id");
                }
                else if (string.IsNullOrEmpty(firstname))
                {
                    throw new Exception("Error: the firstname of the person must not be null");
                }
                else if (string.IsNullOrEmpty(lastname))
                {
                    throw new Exception("Error: the lastname of the person must not be null");
                }

                await _repository.AddAsync(new Person(personID, firstname, lastname, birthdate, email));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Person>> GetAllAsync()
        {
            var people = await _repository.GetAllAsync();
            return people.ToList();
        }

        public async Task<Person> GetByIdAsync(int personId)
        {
            try
            {
                var person = await _repository.GetByIdAsync(personId);
                if (person == null)
                {
                    throw new Exception("Error: there is no person with this id");
                }
                return person;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task UpdatePersonAsync(int personID, string firstname, string lastname, DateTime birthdate, string email)
        {
            try
            {
                var person = await _repository.GetByIdAsync(personID);
                if (person == null)
                {
                    throw new Exception("Error: there is no person with this id");
                }

                await _repository.UpdateAsync(new Person(personID, firstname, lastname, birthdate, email));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeletePersonAsync(int personId)
        {
            try
            {
                var person = await _repository.GetByIdAsync(personId);
                if (person == null)
                {
                    throw new Exception("Error: there is no person with this id");
                }

                await _repository.RemoveAsync(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Person>> FilterPersonByDateAsync(DateTime dateStart, DateTime dateStop)
        {
            var people = await _repository.GetAllAsync();
            return people.Where(person => person.Birthdate >= dateStart && person.Birthdate <= dateStop).ToList();
        }
    }
}
