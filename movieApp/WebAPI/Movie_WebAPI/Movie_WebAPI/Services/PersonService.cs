using Microsoft.EntityFrameworkCore;
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
            var persons = _context.Persons.AsNoTracking().ToList();

            if (persons.Count == 0)
            {
                throw new Exception("There are no persons!");
            }

            return persons;
        }

        public Person GetPersonById(int id)
        {
            var person = _context.Persons.FirstOrDefault(p => p.ID == id);

            if (person != null)
            {
                return person;
            }
            else
            {
                throw new Exception($"Person with id {id} does not exits!");
            }
        }

        public string DeletePerson(int id)
        {
            var person = _context.Persons.Find(id);

            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();
                return "Person deleted succesfully";
            }
            else
            {
                return $"Person with id {id} does not exits!";
            }
        }

        public string UpdatePerson(int personId, string firstName, string lastName, DateTime birthday)
        {
            var person = _context.Persons.FirstOrDefault(p => p.ID == personId);

            if (person != null)
            {
                if (!string.IsNullOrEmpty(firstName))
                {
                    person.FirstName = firstName;
                }
                
                if (!string.IsNullOrEmpty(lastName))
                {
                    person.LastName = lastName;
                }
                
                if (!string.IsNullOrEmpty(birthday.ToShortDateString()))
                {
                    person.Birthday = birthday;
                }

                _context.SaveChanges();
                return "Person updated succesfully!";
            }
            else
            {
                return $"Person with id {personId} does not exits!";
            }
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
