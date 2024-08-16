using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Review
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ReviewId {  get; set; }
    public float Rating { get; set; }
    public string Comment { get; set; }
    public Movie Movie { get; set; }

    public DateTime DateTime { get; set; }

    public Review() { }
    public Review(int review_id, float rating, string comment, Movie movie)
    {
        ReviewId = review_id;
        Rating = rating;
        Comment = comment;
        Movie = movie;
        DateTime = DateTime.Now;
    }

    public string ToString() => $"review id: {ReviewId}, rating: {Rating}, comment: {Comment}, movie: {Movie.Name}, date:{DateTime:dd-MM-yyyy} {DateTime:HH:mm}";
}