using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of the role is required")]
        [StringLength(100, ErrorMessage = "Name of the role cannot be longer than 100 characters")]
        public string Name { get; set; }
        //added two new fields

        [Required(ErrorMessage = "Role Description  is required")]
        [StringLength(100, ErrorMessage = "Role Description cannot be longer than 100 characters")]
        public string RoleDescription { get; set; }
        public int MovieAppereances { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
