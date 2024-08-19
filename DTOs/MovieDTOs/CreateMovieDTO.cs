using MovieWinForms.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieAppRESTAPI.DTOs.MovieDTOs
{
    public class CreateMovieDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Director { get; set; }
        public string Description { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Genre { get; set; }
    }
}
