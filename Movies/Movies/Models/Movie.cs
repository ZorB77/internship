using System;
using System.Data.SqlTypes;


public class Movie
{
    public int MovieId { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }

    public int Duration { get; set; }

    public SqlMoney Budget { get; set; }


    public Movie() { }
    public Movie(int movieId, string name, int year, string description, string genre, int Duration, SqlMoney Budget)
    {

        this.MovieId = movieId;
        this.Name = name;
        this.Year = year;
        this.Description = description;
        this.Genre = genre;
        this.Duration = Duration;
        this.Budget = Budget;
    }
    public string ToString()
    {
        return $"id: {MovieId}, name: {Name}, year: {Year}, description: {Description}, genre: {Genre}, duration: {Duration}, budget: {Budget};";
    }
}