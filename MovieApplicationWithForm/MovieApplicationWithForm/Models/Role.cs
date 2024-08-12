using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Role
    {
        public int roleID { get; set; }
        public Movie movie { get; set; }
        public Person person { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public string description { get; set; }
    }

    public class RoleViewModel
    {
        public int roleID { get; set; }
        public string movieName { get; set; }
        public string personName { get; set; }
        public string name { get; set; }
    }
