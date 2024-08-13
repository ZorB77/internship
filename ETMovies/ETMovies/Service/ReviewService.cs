using ETMovies.DatabaseContext;
using ETMovies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Service
{
    public class ReviewService
    {
        public MyDbContext Context;

        public ReviewService(MyDbContext context) 
        { 
            Context = context; 
        }    
        
     #region ReviewsCRUD

    // Add a review
    public void AddReview(Review review, int movieID)
    {
        if (movieID != null)
        {


            var movie = Context.Movies.FirstOrDefault(m => m.ID == movieID);
            movie.Reviews.Add(review);
            Context.SaveChanges();

        }

    }

    // Select * reviews
    public List<Movie> GetReviews()
    {
        return Context.Movies.Include(m => m.Reviews).AsNoTracking().ToList();

    }

    // Update a review

    public void UpdateReview(int index, int rating, string comment)
    {
        var reviewToUpdate = Context.Reviews.FirstOrDefault(m => m.ID == index);
        if (reviewToUpdate != null)
        {
            reviewToUpdate.Rating = rating;
            reviewToUpdate.Comment = comment;
            Context.SaveChanges();
        }
    }

    // Delete a review

    public void DeleteReview(int index)
    {
        var reviewToDelete = Context.Reviews.FirstOrDefault(m => m.ID == index);
        if (reviewToDelete != null)
        {
            Context.Reviews.Remove(reviewToDelete);
            Context.SaveChanges();
        }

    }
    #endregion

    }




}
