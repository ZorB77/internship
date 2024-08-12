using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Models
{

	public class Studio
	{
		public int StudioID { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }
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
