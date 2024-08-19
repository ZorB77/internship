using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Models
{

	public class Studio
	{
		public int ID { get; set; }
        [Required(ErrorMessage = "Tite=le is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; }
		[Range(1895, 2024, ErrorMessage = "Year must be between 1895 and 2024")]
		public int Year { get; set; }
        [Required(ErrorMessage = "Location is required")]
        [StringLength(100, ErrorMessage = "Location cannot be longer than 100 characters")]
        public string Location { get; set; }

		public List<Movie> Movies { get; set; } = new List<Movie>();

		public Studio()
		{
		}

        public override string ToString()
        {
			return $"{Title}";
        }

        public Studio(string title, int year, string location)
		{
			Title = title;
			Year = year;
			Location = location;
			Movies = new List<Movie>();
		}
	}

}
