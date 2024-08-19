using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Login
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 255 characters")]
        public string Password { get; set; }
    }
}
