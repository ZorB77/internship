using System.ComponentModel.DataAnnotations;

namespace MovieApplicationWebAPI.Models
{
    public class ReviewMapper
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The rating is required.")]
        public int Rating { get; set; }
        public string Comment { get; set; }
        [Required(ErrorMessage = "The movieID is required.")]
        public int MovieID { get; set; }
    }
}
