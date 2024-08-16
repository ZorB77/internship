using MovieWinForms.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieAppRESTAPI.DTOs.StudiosDTOs
{
    public class CreateStudioDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [Range(1900, 2024)]
        public int Year { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Location { get; set; }
    }
}
