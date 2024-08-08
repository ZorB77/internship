using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication
{
    public class PersonService
    {
        private MyDBContext db;
        public PersonService(MyDBContext db) { this.db = db; }
        public int addPerson(string firstName, string lastName, DateTime birthdate, string email)
        {
            db.Add(new Person { firstName = firstName, lastName = lastName, birthdate = birthdate, email = email });
            db.SaveChanges();
            return 0;
        }

        public int deletePerson(int personID)
        {
            Person person = db.persons.SingleOrDefault(p => p.personID == personID);
            if (person != null)
            {
                db.Remove(person);
                db.SaveChanges();
                return 0;
            }
            return 1;
        }

        public int updatePerson(int personID, string firstName, string lastName, DateTime birthdate, string email)
        {
            Person person = db.persons.SingleOrDefault(p => p.personID == personID);
            if (person != null)
            {
                person.firstName = firstName;
                person.lastName = lastName;
                person.birthdate = birthdate;
                person.email = email;

                db.SaveChanges();
                return 0;
            }
            return 1;
        }

        public string printPersons()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine();
            s.AppendLine("The list of persons is:");

            foreach (Person person in db.persons)
            {
                s.AppendLine($"{person.personID}. {person.firstName} {person.lastName}");
            }
            return s.ToString();
        }

        public string getPersonInformation(int personID)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine();

            Person person = db.persons.SingleOrDefault(p => p.personID == personID);
            if (person != null)
            {
                s.AppendLine("First Name: " + person.firstName);
                s.AppendLine("Last Name: " + person.lastName);
                s.AppendLine("Birthdate: " + person.birthdate);
                s.AppendLine("Email: " + person.email);
            }
            else
            {
                s.AppendLine("There is no person with such id.");
            }
            return s.ToString();
        }

        public void printMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add a person.");
            Console.WriteLine("2. Delete a person.");
            Console.WriteLine("3. Update a person.");
            Console.WriteLine("4. See all persons.");
            Console.WriteLine("5. See information about a given person.");
            Console.WriteLine("0. Back to the main menu.");
        }

    }
}
