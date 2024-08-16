using System.ComponentModel.DataAnnotations;

namespace MoviesApi.ModelsDTO
{
    public class ReviewCUDto
    {
        [Required]
        [Range(0,100)]
        public int Rating { get; set; }
        public string Comment { get; set; }
        [Required]
        public int MovieID { get; set; }
    }
}
