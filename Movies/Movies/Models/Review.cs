using System;

public class Review
{
    public int reviewId {  get; set; }
    public float rating { get; set; }
    public string comment { get; set; }
    public Movie movie { get; set; }

    public Review() { }
    public Review(int review_id, float rating, string comment)
    {
        review_id = review_id;
        rating = rating;
        comment = comment;
    }
}