using System.ComponentModel.DataAnnotations;

namespace MovieApplicationWebAPI.Models
{
    public class RoleMapper
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The movieID is required.")]
        public int MovieID { get; set; }
        [Required(ErrorMessage = "The personID is required.")]
        public int PersonID { get; set; }
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The salary is required.")]
        [Range(1000, 7000, ErrorMessage = "Salary must be between 1000 and 7000.")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "The description is required.")]
        public string Description { get; set; }
    }
}
