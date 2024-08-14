using System.ComponentModel.DataAnnotations;

namespace MovieApplicationWebAPI.Models
{
    public class Distribution
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The movie is required.")]
        public Movie Movie { get; set; }
        [Required(ErrorMessage = "The studio is required.")]
        public Studio Studio { get; set; }
        [Required(ErrorMessage = "The distribution date is required.")]
        public DateTime DistributionDate { get; set; }
        [Required(ErrorMessage = "The details are required.")]
        public string Details { get; set; }
    }
}
