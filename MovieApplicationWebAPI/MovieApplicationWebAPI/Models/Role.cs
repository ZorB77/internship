using System.ComponentModel.DataAnnotations;

namespace MovieApplicationWebAPI.Models
{
    public class Role
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The movie is required.")]
        public Movie Movie { get; set; }
        [Required(ErrorMessage = "The person is required.")]
        public Person Person { get; set; }
        [Required(ErrorMessage = "The name is required.")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The salary is required.")]
        [Range(1000, 7000,ErrorMessage = "Salary must be between 1000 and 7000.")]
        public int Salary { get; set; }
        public string Description { get; set; }
    }
}
