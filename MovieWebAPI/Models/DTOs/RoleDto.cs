using System.ComponentModel.DataAnnotations;

namespace MovieWebAPI.Models.DTOs
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        [Required(ErrorMessage ="The movie ID is required")]
        public int Movie { get; set; }
        [Required(ErrorMessage = "The person ID is required")]
        public int Person { get; set; }
        [Required(ErrorMessage = "The role name is required")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
