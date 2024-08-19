using MovieApp.Models;

namespace MovieApplication.Services.Interfaces
{
    public interface IPersonService
    {
        public bool AddPerson(string firstName, string lastName, DateTime birthday);
        public List<Person> GetAllPersons();
        public Person GetPersonById(int id);
        public bool DeletePerson(int id);
        public bool UpdatePerson(int personId, string firstName, string lastName, DateTime birthday);
        public void PersonOptions();
    }
}
