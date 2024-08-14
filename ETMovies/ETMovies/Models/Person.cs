using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public DateTime Birthdate { get; set; }

        public string Nationality { get; set; }
        public int Award { get; set; }

        public Person() { }

        public Person(string firstName, string lastName, DateTime birthdate, string nat, int award)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Nationality = nat;
            Award = award;
        }
    }
}
