using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Range(1, 10, ErrorMessage = "The rating of the movie must be between 1 and 10")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        [StringLength(100, ErrorMessage = "Comment cannot be longer than 100 characters")]
        public string Comment { get; set; }
        public DateTime ReviewCreated { get; set; }
        [Required(ErrorMessage = "Reviewer first name is required")]
        [StringLength(100, ErrorMessage = "Reviewer first name cannot be longer than 100 characters")]
        public string ReviewerFirstName { get; set; }

        public Movie Movie { get; set; }
        public int MovieId { get; set; }
    }
}
