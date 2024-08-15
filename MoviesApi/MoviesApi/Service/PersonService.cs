using ETMovies.DatabaseContext;
using ETMovies.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Service
{
    public class PersonService
    {
        public MyDbContext Context;

        public PersonService(MyDbContext context)
        { 
            Context = context;
        }
        #region PersonCRUD

        // Add a person
        public void AddPerson(Person person)
        {

            Context.Persons.Add(person);
            Context.SaveChanges();

        }

        // Select * persons
        public List<Person> GetPersons()
        {
            return Context.Persons.AsNoTracking().ToList();
        }

        // Update a person

        public void UpdatePerson(int index, string firstName, string lastName, DateTime birthday, string nat, int award)
        {
            var personToUpdate = Context.Persons.FirstOrDefault(m => m.ID == index);
            if (personToUpdate != null)
            {
                personToUpdate.FirstName = firstName;
                personToUpdate.LastName = lastName;
                personToUpdate.Birthdate = birthday;
                personToUpdate.Nationality = nat;
                personToUpdate.Award = award;
                Context.SaveChanges();
            }
        }

        // Delete a person

        public void DeletePerson(int index)
        {
            var personToDelete = Context.Persons.FirstOrDefault(m => m.ID == index);
            if (personToDelete != null)
            {
                Context.Persons.Remove(personToDelete);
                Context.SaveChanges();
            }

        }
        #endregion

        public List<Person> FilterPersonsByAge(int minAge, int maxAge)
        {

            DateTime currentDate = DateTime.Today;

            return Context.Persons.Where(r => (currentDate.Year - r.Birthdate.Year) >= minAge && (currentDate.Year - r.Birthdate.Year <= maxAge)).AsEnumerable().ToList();
        }

        internal Person GetPerson(int id)
        {
            var review = Context.Persons.AsNoTracking().FirstOrDefault(r => r.ID == id);
            return review;
        }
    }
}
