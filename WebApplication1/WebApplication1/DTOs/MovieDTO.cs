using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class MovieDTO
    {
      //  public int Id { get; set; }
        [Required(ErrorMessage = "Movie is required")]
        [StringLength(100, ErrorMessage = "Movie name cannot be longer than 100 characters")]
        public string Name { get; set; }
        [Range(1900, 2024, ErrorMessage = "The year of the movie must be between 1900 and 2024")]
        public int Year { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [StringLength(100, ErrorMessage = "Genre cannot be longer than 100 characters")]
        public string Genre { get; set; }
    }
}
