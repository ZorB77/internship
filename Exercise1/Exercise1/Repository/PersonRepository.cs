using Exercise1.ConfigDatabase;
using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MovieContext _movieContext;
        public PersonRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public void AddPerson(Person person)
        {
            _movieContext.Persons.Add(person);
            _movieContext.SaveChanges();
        }

        public void DeletePerson(string firstname, string lastname)
        {
            var person = _movieContext.Persons.FirstOrDefault(p => p.FirstName.ToLower() == firstname.ToLower() && p.LastName.ToLower() == lastname.ToLower());
            _movieContext.Persons.Remove(person);
            _movieContext.SaveChanges();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _movieContext.Persons.ToList();

        }

        public Person GetPerson(string firstname, string lastname)
        {
            return _movieContext.Persons.FirstOrDefault(p => p.FirstName.ToLower() == firstname.ToLower() && p.LastName.ToLower() == lastname.ToLower());
        }

        public void UpdatePerson(Person person)
        {
            
            _movieContext.SaveChanges();
        }
    }
}
