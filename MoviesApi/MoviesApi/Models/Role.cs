using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Models
{
    public class Role
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Movie ID is required")]
        public Movie Movie { get; set; }
        [Required(ErrorMessage = "Person ID is required")]
        public Person Person { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        public Role() { }

        public Role(Movie movie, Person person, string name)
        {
            Movie = movie;
            Person = person;
            Name = name;
        }
    }
}
