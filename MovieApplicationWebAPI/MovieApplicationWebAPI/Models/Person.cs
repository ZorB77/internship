using System.ComponentModel.DataAnnotations;

namespace MovieApplicationWebAPI.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The first name of the person is required.")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The last name of the person is required.")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The birthdate of the person is required.")]
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
