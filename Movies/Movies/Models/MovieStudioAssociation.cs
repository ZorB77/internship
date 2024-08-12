using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class MovieStudioAssociation
{
    public int Id { get; set; }
    public Movie Movie { get; set; }

    public Studio Studio { get; set; }

    public DateTime DateStamp { get; private set; }

    public MovieStudioAssociation(int id, Movie movie, Studio studio)
    {
        Id = id;
        Movie = movie;
        Studio = studio;
        DateStamp = DateTime.Now;
    }

    public MovieStudioAssociation() { } 

    public string ToString()
    {
        return $"Id: {this.Id}, movie: {this.Movie.Name}, studio: {this.Studio.Name};";
    }
}
