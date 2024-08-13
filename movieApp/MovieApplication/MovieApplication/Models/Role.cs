using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class Role
    {
        public int ID { get; set; }
        public Movie Movie { get; set; }
        public Person Person { get; set; }
        public string Name { get; set; }
    }
}
