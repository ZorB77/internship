using System.ComponentModel.DataAnnotations;

namespace MovieApplicationWebAPI.Models
{
    public class Studio
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The name of the studio is required.")]
        [StringLength(100)]
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        [Required(ErrorMessage = "The location of the studio is required.")]
        public string Location { get; set; }
    }
}
