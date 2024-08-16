using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class Role
    {
        public int ID { get; set; }
        [Required]
        public Movie Movie { get; set; }
        [Required]
        public Person Person { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
