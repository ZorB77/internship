using System.ComponentModel.DataAnnotations;

namespace MovieApplicationWebAPI.Models
{
    public class Review
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The rating is required.")]
        public int Rating { get; set; }
        [StringLength(100)]
        public string Comment { get; set; }
        [Required(ErrorMessage = "The movie is required.")]
        public Movie Movie { get; set; }
    }
}
