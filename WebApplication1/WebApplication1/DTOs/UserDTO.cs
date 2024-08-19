using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class UserDTO
    {

        [Required(ErrorMessage = "First name is required")]
        [StringLength(60, ErrorMessage = "First name cannot be longer than 60 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(60, ErrorMessage = "Last name cannot be longer than 60 characters")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 255 characters")]
        public string Password { get; set; }

    }
}
