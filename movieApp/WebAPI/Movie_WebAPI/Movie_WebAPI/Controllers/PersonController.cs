using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Services;

namespace Movie_WebAPI.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/addPerson")]
        [HttpPost]
        public bool AddPerson(string firstName, string lastName, DateTime birthday)
        {
            return _personService.AddPerson(firstName, lastName, birthday);
        }

        [Route("api/getPersons")]
        [HttpGet]
        public List<Person> GetPersons()
        {
            return _personService.GetAllPersons();
        }

        [Route("api/getPersonById/ID={id}")]
        [HttpGet]
        public Person GetPersonById(int id)
        {
            return _personService.GetPersonById(id);
        }

        [Route("api/deletePerson/ID={id}")]
        [HttpDelete]
        public bool DeletePerson(int id)
        {
            return _personService.DeletePerson(id);
        }

        [Route("api/updatePerson/ID={id}")]
        [HttpPut]
        public bool UpdatePerson(int id, string firstName, string lastName, DateTime birthday)
        {
            return _personService.UpdatePerson(id, firstName, lastName, birthday);
        }
    }
}
