using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class StudioDTO
    {
       
        [Required(ErrorMessage = "Name of the studio is required")]
        [StringLength(100, ErrorMessage = "Name of the studio cannot be longer than 100 characters")]
        public string StudioName { get; set; }
        public int StudioYear { get; set; }

        [Required(ErrorMessage = "Location of the studio is required")]
        [StringLength(100, ErrorMessage = "Location of the studio cannot be longer than 100 characters")]
        public string StudioLocation { get; set; }

    }
}
