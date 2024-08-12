using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public Movie Movie { get; set; }
        public Person Person { get; set; }
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
