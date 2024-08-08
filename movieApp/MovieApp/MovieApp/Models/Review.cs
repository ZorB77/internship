using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
