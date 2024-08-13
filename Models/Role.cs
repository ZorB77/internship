using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWinForms.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Movie Movie { get; set; }
        public Person Person { get; set; }
    }
}
