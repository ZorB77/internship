using System.ComponentModel.DataAnnotations;

namespace MoviesApi.ModelsDTO
{
    public class MovieCUDto
    {
        public MovieCUDto(string title, string description, int year, string genre, int duration, decimal budget)
        {
            Title = title;
            Description = description;
            Year = year;
            Genre = genre;
            Duration = duration;
            Budget = budget;
        }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        [Required]
        [Range(1895, 2024)]
        public int Year { get; set; }
        [Required]
        [StringLength(100)]
        public string Genre { get; set; }
        [Required]
        [Range(1, 500)]
        public int Duration { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Budget { get; set; }
        public List<int> StudioIds { get; set; } = new List<int>();

    }
}
