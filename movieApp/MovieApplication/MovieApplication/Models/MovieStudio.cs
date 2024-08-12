using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Models
{
    public class MovieStudio
    {
        public int MovieStudioID { get; set; }
        public int MovieID {  get; set; }
        public Movie Movie { get; set; }
        public int StudioID { get; set; }
        public Studio Studio { get; set; }
    }
}
