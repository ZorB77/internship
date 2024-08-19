using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Models
{
    public class MovieStudio
    {
        public int ID { get; set; }
        [Required]
        public int MovieID {  get; set; }
        public Movie Movie { get; set; }
        [Required]
        public int StudioID { get; set; }
        public Studio Studio { get; set; }
    }
}
