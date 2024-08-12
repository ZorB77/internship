using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieWinForms;
using MovieWinForms.Models;
namespace MovieWinForms.DataAccess
{
    public class PeopleRepository
    {
        private static MovieDbContext _context = new MovieDbContext();
        public static void CreatePerson(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
        }
        public static List<Person> GetPeople()
        {
            var people = _context.People.ToList();
            return people;
        }
        public static List<Person> GetPeopleByGenre(string genre)
        {
            var people = _context.People
                .Select(p => new
                {
                    Person = p,
                    RoleInMovie = _context.Roles.Any(
                        r => r.Movie.Genre == genre && r.Person.Id == p.Id
                        )
                }
                )
                .Where(p => p.RoleInMovie != false)
                .Select(p => p.Person)
                .ToList();
            return people;
        }
        public static List<Person> GetPeopleByNumberOfRoles(int numberOfRoles)
        {
            var people = _context.People
                .Select(p => new
                {
                    Person = p,
                    RolesInMovies = _context.Roles
                    .Where(r => r.Person.Id == p.Id)
                    .Count()
                })
                .Where(p => p.RolesInMovies >= numberOfRoles)
                .Select(p => p.Person)
                .ToList();
            return people;
        }
        public static Person GetPersonById(int id)
        {
            var person = _context.People.Where(m => m.Id == id).FirstOrDefault();
            return person;
        }
        public static void UpdatePerson(int id, Person newPerson)
        {
            var person = GetPersonById(id);
            person.FirstName = newPerson.FirstName;
            person.LastName = newPerson.LastName;
            person.Birthdate = newPerson.Birthdate;
            person.Email = newPerson.Email ?? person.Email;
            _context.Update(person);
            _context.SaveChanges();
        }
        public static void DeletePerson(int id)
        {
            var person = GetPersonById(id);
            _context.Remove(person);
            _context.SaveChanges();
        }
    }
}
