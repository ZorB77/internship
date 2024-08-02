using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Movie
    {
        public int id { get; set; }
        public string title { get; set; }

        public int year { get; set; }

        public override string ToString()
        {
            return $"Id: {id}, Title: {title}";
        }
    }
}
