using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.ComponentModel;


public class Movie
{
    [Key]
    public int MovieId { get; set; }
    [Required(ErrorMessage = "A movie name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "A year for the movie is required")]
    public int Year { get; set; }
    public string? Description { get; set; }
    [DisplayName("Genre")]
    public string Genre { get; set; }
    [Required(ErrorMessage = "The movie duration is required")]
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