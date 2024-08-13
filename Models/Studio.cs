using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWinForms.Models
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
