using System.ComponentModel.DataAnnotations;

namespace MovieAppRESTAPI.DTOs.PersonDTO.cs
{
    public class CreatePersonDTO 
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
    }
}
