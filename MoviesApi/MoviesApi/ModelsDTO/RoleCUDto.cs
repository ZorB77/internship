using System.ComponentModel.DataAnnotations;

namespace MoviesApi.ModelsDTO
{
    public class RoleCUDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int PersonId {  get; set; }
    }
}
