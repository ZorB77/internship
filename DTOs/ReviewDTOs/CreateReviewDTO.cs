using System.ComponentModel.DataAnnotations;

namespace MovieAppRESTAPI.DTOs.ReviewDTOs
{
    public class CreateReviewDTO
    {
        [Required]
        [Range(1, 10)]
        public decimal Rating { get; set; }
        [StringLength(500, MinimumLength = 2)]
        public string Comment { get; set; }
        public int MovieId { get; set; }
    }
}
