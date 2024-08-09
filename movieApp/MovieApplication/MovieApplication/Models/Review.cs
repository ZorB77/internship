using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
