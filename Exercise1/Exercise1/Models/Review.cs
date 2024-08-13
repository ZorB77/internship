using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Models
{
    public class Review
    {
        public int ID { get; set; }
        public int Rating { get; set; }
        public string Comment {  get; set; }
        //another two fields
        public DateTime ReviewCreated { get; set; }
        public string ReviewerFirstName {  get; set; }

        public Movie Movie { get; set; }
        public int MovieId { get; set; }
    }
}
