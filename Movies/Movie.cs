using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Movies
{
    class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public string producer { get; set; }

        public Movie(int id, string title, string producer)
        {
            this.id = id; 
            this.title = title;
            this.producer = producer;
        }

        public override string ToString()
        {
            return System.String.Format("This instance of my object has the following: Id = {0}, Title = {1}, Producer = {2}", id, title, producer);
        }
    }
}
/*
 // Create a file to write to.
string createText = "Hello and Welcome" + Environment.NewLine;
File.WriteAllText(path, createText);

...

// Open the file to read from.
string readText = File.ReadAllText(path);
 
 */
