using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public DateOnly Birthdate { get; set; }

        public string Nationality { get; set; }
        public int Award { get; set; }

        public Person() { }

        public Person(string firstName, string lastName, DateOnly birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }
    }
}
