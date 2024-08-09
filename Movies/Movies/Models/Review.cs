using System;

public class Review
{
    public int ReviewId {  get; set; }
    public float Rating { get; set; }
    public string Comment { get; set; }
    public Movie Movie { get; set; }

    public Review() { }
    public Review(int review_id, float rating, string comment, Movie movie)
    {
        ReviewId = review_id;
        Rating = rating;
        Comment = comment;
        Movie = movie;
    }

    public string ToString()
    {
        return $"review id: {ReviewId}, rating: {Rating}, comment: {Comment}, movie: {Movie.Name}";
    }
}