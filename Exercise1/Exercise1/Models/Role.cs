using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Models
{
    public class Role
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        //added two new fields
        public string RoleDescription { get; set; }
        public int MovieAppereances {  get; set; }
        public int MovieId { get; set; }  
        public  Movie Movie { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; } 
      
    }
}
