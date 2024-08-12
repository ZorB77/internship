using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Models
{
   public class Movie
    {
        public int MovieID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Role> Roles { get; set; }

    }
}
