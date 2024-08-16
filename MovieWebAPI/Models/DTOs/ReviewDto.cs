using System.ComponentModel.DataAnnotations;

namespace MovieWebAPI.Models.DTOs
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        [Range(0.00, 5.00,
            ErrorMessage = "Rating must be in this interval [0, 5]")]
        public float Rating { get; set; }
        public string? Comment { get; set; }
        [Required(ErrorMessage = "The movie ID is required")]
        public int MovieId { get; set; }
    }
}
