using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //deleted field - public DateTime Birthday 
      
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
