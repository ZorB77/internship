using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class MovieStudioAssociation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

    public string ToString => $"Id: {this.Id}, movie: {this.Movie.Name}, studio: {this.Studio.Name};";
}
