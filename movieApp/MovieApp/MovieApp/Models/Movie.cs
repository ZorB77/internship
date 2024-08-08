using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        [ForeignKey("Review")]
        public int ReviewID { get; set; }
        public Review Review { get; set; }
    }
}
