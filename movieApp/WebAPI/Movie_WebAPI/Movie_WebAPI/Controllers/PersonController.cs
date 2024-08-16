using Microsoft.AspNetCore.Mvc;
using Movie_WebAPI.Services;
using MovieApp.Models;
using MovieApp.Services;

namespace Movie_WebAPI.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonService _personService;
        private readonly LogService _logService;

        public PersonController(PersonService personService, LogService logService)
        {
            _personService = personService;
            _logService = logService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/addPerson")]
        [HttpPost]
        public string AddPerson([FromBody] Person person)
        {
            try
            {
                _logService.LogRequest("Add new person.");
                return _personService.AddPerson(person.FirstName, person.LastName, person.Birthday);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                return ex.Message;
            }
        }

        [Route("api/getPersons")]
        [HttpGet]
        public List<Person> GetPersons()
        {
            try
            {
                _logService.LogRequest("Get all persons.");
                return _personService.GetAllPersons();
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/getPersonById/ID={id}")]
        [HttpGet]
        public Person GetPersonById(int id)
        {
            try
            {
                _logService.LogRequest($"Get person with id {id}.");
                return _personService.GetPersonById(id);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/deletePerson/ID={id}")]
        [HttpDelete]
        public bool DeletePerson(int id)
        {
            try
            {
                _logService.LogRequest("Delete a person.");
                return _personService.DeletePerson(id);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/updatePerson/ID={id}")]
        [HttpPut]
        public string UpdatePerson([FromBody] Person person)
        {
            try
            {
                _logService.LogRequest("Update a person.");
                return _personService.UpdatePerson(person.ID, person.FirstName, person.LastName, person.Birthday);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                return ex.Message;
            }
        }
    }
}
