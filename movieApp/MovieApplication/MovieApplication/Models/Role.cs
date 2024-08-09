using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [ForeignKey("Movie")]
        public int MovieID { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey("Person")]
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public string Name { get; set; }
        public ICollection<Person> Persons { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
