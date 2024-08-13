using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWinForms.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }
        public Movie Movie { get; set; }
    }
}
