using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Review
    {
        public int ID { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewerName { get; set; }
        public int MovieId { get; set; }
        public Movie Movies { get; set; }
    }
}
