using System;


public class Movie
{
    public int MovieId { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }

    public Movie() { }
    public Movie(int movieId, string name, int year, string description, string genre)
    {

        this.MovieId = movieId;
        this.Name = name;
        this.Year = year;
        this.Description = description;
        this.Genre = genre;
    }
    public string ToString()
    {
        return $"id: {MovieId}, name: {Name}, year: {Year}, description: {Description}, genre: {Genre}";
    }
}