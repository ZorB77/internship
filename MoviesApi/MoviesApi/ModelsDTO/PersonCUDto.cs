using System.ComponentModel.DataAnnotations;

namespace MoviesApi.ModelsDTO
{
    public class PersonCUDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }

        [StringLength(100)]
        public string Nationality { get; set; }
        public int Awards { get; set; }
    }
}
