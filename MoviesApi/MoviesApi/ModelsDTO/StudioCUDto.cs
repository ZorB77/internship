using System.ComponentModel.DataAnnotations;

namespace MoviesApi.ModelsDTO
{
    public class StudioCUDto
    {
        public int Year;

        public StudioCUDto(string title, int year, string location)
        {
            Title = title;
            Year = year;
            Location = location;
        }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Location { get; set; }
    }
}
