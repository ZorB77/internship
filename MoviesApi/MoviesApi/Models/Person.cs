using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(100, ErrorMessage = "FirstName cannot be longer than 100 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(100, ErrorMessage = "LastName cannot be longer than 100 characters")]
        public string LastName{ get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }
        [StringLength(100, ErrorMessage ="Nationality cannot be longer than 100 characters")]
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
