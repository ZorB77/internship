using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Birthday is required.")]
        public DateTime Birthday { get; set; }
    }
}
