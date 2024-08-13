using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieWinForms;
using MovieWinForms.Models;
namespace MovieWinForms.DataAccess
{
    public class ReviewRepository 
    {
        private static MovieDbContext _context = new MovieDbContext();
        public static void CreateReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
        public static List<Review> GetReviews()
        {
            var reviews= _context.Reviews.ToList();
            return reviews;
        }
        public static Review GetReviewById(int id)
        {
            var review = _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
            return review;
        }
        public static void UpdateReview(int id, Review newReview)
        {
            var review = GetReviewById(id);
            review.Rating = newReview.Rating;
            review.Comment = newReview.Comment;
            _context.Update(review);
            _context.SaveChanges();
        }
        public static void DeleteReview(int id)
        {
            var review = GetReviewById(id);
            _context.Remove(review);
            _context.SaveChanges();
        }
    }
}
