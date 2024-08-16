using MovieWinForms.Models;

namespace MovieAppRESTAPI.DTOs.StudiosDTOs
{
    public class StudioDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Location { get; set; }
    }
}
