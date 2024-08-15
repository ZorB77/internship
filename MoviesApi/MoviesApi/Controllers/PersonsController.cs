using ETMovies.Models;
using ETMovies.Service;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonsController : Controller
    {
        private PersonService service;
        public PersonsController(PersonService personService)
        {
            service = personService;
        }

        [HttpGet]
        public IEnumerable<Person> GetPersons(int page = 1, int pageSize = 10)
        {
            var persons = service.GetPersons().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return persons;

        }

        [HttpGet("{id}")]
        public Person GetPerson(int id)
        {
            var person = service.GetPerson(id);
            if (person == null)
                return null;
            return person;

        }

        [HttpPost]
        public void Post(string firstName, string lastName, DateTime birthday, string nat, int award)
        {
            var person = new Person(firstName, lastName, birthday, nat, award);
            service.AddPerson(person);
        }

        [HttpPut]
        public void Put(int id, string firstName, string lastName, DateTime birthday, string nat, int award)
        {
            service.UpdatePerson(id, firstName, lastName, birthday, nat, award);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeletePerson(id);
        }
        [HttpGet]
        public List<Person> FilteredPersonsByAge(int minAge, int maxAge, int page = 1, int pageSize = 10) 
        { 
            var persons = service.FilterPersonsByAge(minAge, maxAge);
            return persons.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
