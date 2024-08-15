using ETMovies.Models;
using ETMovies.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewsController : Controller

    {
        private ReviewService service;
        public ReviewsController(ReviewService reviewService) 
        {
            service = reviewService;
        }

        [HttpGet]
        public  IEnumerable<Review> GetReviews(int page = 1, int pageSize= 10)
        {
            var reviews = service.GetReviews().Skip((page-1) * pageSize).Take(pageSize).ToList();  
            return reviews;

        }

        [HttpGet("{id}")]
        public Review GetReview(int id)
        {
            var review = service.GetReview(id);
            if (review == null)
                return null;
            return review;
            
        }

        [HttpPost]
        public void Post(int rating, string comment, int movieID)
        {
            var rev = new Review(rating, comment);
            service.AddReview(rev, movieID);
        }

        [HttpPut]
        public void Put(int id, int rating, string comment)
        { 
            service.UpdateReview(id, rating, comment);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteReview(id);
        }
    }
}
