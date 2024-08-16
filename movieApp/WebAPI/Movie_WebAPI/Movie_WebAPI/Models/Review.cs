using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Review
    {
        public int ID { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime ReviewDate { get; set; }
        [Required]
        public string ReviewerName { get; set; }
        public int MovieId { get; set; }
        public Movie Movies { get; set; }
    }
}
