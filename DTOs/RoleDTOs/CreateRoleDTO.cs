using System.ComponentModel.DataAnnotations;

namespace MovieAppRESTAPI.DTOs.RoleDTOs
{
    public class CreateRoleDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}
