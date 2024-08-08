using System;


public class Movie
{
    public int movieId { get; set; }
    public string name { get; set; }
    public int year { get; set; }
    public string description { get; set; }
    public string genre { get; set; }

    public Movie() { }
    public Movie(int movieId, string name, int year, string description, string genre)
    {

        this.movieId = movieId;
        this.name = name;
        this.year = year;
        this.description = description;
        this.genre = genre;
    }
    public string ToString()
    {
        return $"id: {movieId}; \t name: {name} \t year: {year} \t description: {description} \t genre: {genre}";
    }
}