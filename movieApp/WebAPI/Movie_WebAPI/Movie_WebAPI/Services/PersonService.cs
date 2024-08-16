using Microsoft.EntityFrameworkCore.Query;
using MovieApp.Models;

namespace MovieApp.Services
{
    public class PersonService
    {
        private readonly MovieContext _context;

        public PersonService(MovieContext context)
        {
            _context = context;
        }

        public string AddPerson(string firstName, string lastName, DateTime birthday)
        {
            try
            {
                var newPerson = new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Birthday = birthday,
                };

                _context.Persons.Add(newPerson);
                _context.SaveChanges();
                return "Person added succesfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _context.Persons.FirstOrDefault(p => p.ID == id);
        }

        public bool DeletePerson(int id)
        {
            var person = _context.Persons.Find(id);

            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public string UpdatePerson(int personId, string firstName, string lastName, DateTime birthday)
        {
            var person = _context.Persons.FirstOrDefault(p => p.ID == personId);

            if (person != null)
            {
                person.FirstName = firstName;
                person.LastName = lastName;
                person.Birthday = birthday;

                _context.SaveChanges();
                return "Person updated succesfully!";
            }

            return "Person not found! Please try again!";
        }

        public void PersonOptions()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Add a person");
            Console.WriteLine("2 - Get persons list");
            Console.WriteLine("3 - Get person by id");
            Console.WriteLine("4 - Delete a person");
            Console.WriteLine("5 - Update a person");
            Console.WriteLine("6 - Back to base options");
        }
    }
}
