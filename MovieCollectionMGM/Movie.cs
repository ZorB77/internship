using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollectionMGM
{
    public class Movie
    {
        public Movie(string Title)
        {
           this.Title = Title;
        }
        public string Title { get; set; }
    }
}
