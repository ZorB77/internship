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
        private ILogger<PersonsController> logger;
        public PersonsController(PersonService personService, ILogger<PersonsController> logger)
        {
            service = personService;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Person> GetPersons(int page = 1, int pageSize = 10)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetPersons WAS CALLED");
            logger.LogInformation(" ------ ");
            var persons = service.GetPersons().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            if (persons == null)
            {
                logger.LogInformation("No persons found");
                return null;
            }
            logger.LogInformation(" ------ ");
            logger.LogInformation("Returning persons");
            logger.LogInformation(" ------ ");
            return persons;

        }

        [HttpGet("{id}")]
        public Person GetPerson(int id)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetPerson{id} WAS CALLED");
            logger.LogInformation(" ------ ");
            var person = service.GetPerson(id);
            if (person == null)
            {
                logger.LogInformation("No person found");
                return null;
            }
            logger.LogInformation(" ------ ");
            logger.LogInformation("Returning person");
            logger.LogInformation(" ------ ");
            return person;

        }

        [HttpPost]
        public void Post(string firstName, string lastName, DateTime birthday, string nat, int award)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Post WAS CALLED");
            logger.LogInformation(" ------ ");
            var person = new Person(firstName, lastName, birthday, nat, award);
            service.AddPerson(person);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Person added succesfully");
            logger.LogInformation(" ------ ");
        }

        [HttpPut]
        public void Put(int id, string firstName, string lastName, DateTime birthday, string nat, int award)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Put WAS CALLED");
            logger.LogInformation(" ------ ");
            service.UpdatePerson(id, firstName, lastName, birthday, nat, award);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Person updated succesfully");
            logger.LogInformation(" ------ ");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Delete{id} WAS CALLED");
            logger.LogInformation(" ------ ");
            service.DeletePerson(id);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Person deleted succesfully");
            logger.LogInformation(" ------ ");
        }
        [HttpGet]
        public List<Person> FilteredPersonsByAge(int minAge, int maxAge, int page = 1, int pageSize = 10) 
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("FilteredPersonsByAge");
            logger.LogInformation(" ------ ");
            var persons = service.FilterPersonsByAge(minAge, maxAge);
            if(persons == null)
            {
                logger.LogInformation("No persons found");

            }
            logger.LogInformation(" ------ ");
            logger.LogInformation($"Succsesfully, returning {persons.Count()} persons");
            logger.LogInformation(" ------ ");
            return persons.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
