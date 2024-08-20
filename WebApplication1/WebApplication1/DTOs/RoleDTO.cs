using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class RoleDTO
    {
        [Required(ErrorMessage = "Name of the role is required")]
        [StringLength(100, ErrorMessage = "Name of the role cannot be longer than 100 characters")]
        public string Name { get; set; }
        //added two new fields

        [Required(ErrorMessage = "Role Description  is required")]
        [StringLength(100, ErrorMessage = "Role Description cannot be longer than 100 characters")]
        public string RoleDescription { get; set; }
        public int MovieAppereances { get; set; }
    }
}
