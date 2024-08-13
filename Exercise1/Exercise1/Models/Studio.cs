using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Models
{
    public class Studio
    {
        public int ID { get; set; }
        public string StudioName { get; set; }
        public int StudioYear { get; set; }

        public string StudioLocation { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    }
}
