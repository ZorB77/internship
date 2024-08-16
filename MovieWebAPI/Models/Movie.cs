using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;


public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int MovieId { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }

    public int Duration { get; set; }

    public Movie() { }
    public Movie(int movieId, string name, int year, string description, string genre, int Duration)
    {

        this.MovieId = movieId;
        this.Name = name;
        this.Year = year;
        this.Description = description;
        this.Genre = genre;
        this.Duration = Duration;
    }
    public string ToString()
    {
        return $"id: {MovieId}, name: {Name}, year: {Year}, description: {Description}, genre: {Genre}, duration: {Duration};";
    }
}