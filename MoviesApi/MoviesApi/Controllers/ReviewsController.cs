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
        private ILogger<ReviewsController> logger;
        public ReviewsController(ReviewService reviewService, ILogger<ReviewsController> logger) 
        {
            service = reviewService;
            this.logger = logger;
        }

        [HttpGet]
        public  IEnumerable<Review> GetReviews(int page = 1, int pageSize= 10)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetReviews WAS CALLED");
            logger.LogInformation(" ------ ");
            var reviews = service.GetReviews().Skip((page-1) * pageSize).Take(pageSize).ToList();
            if (reviews == null)
            {
                logger.LogInformation("No reviews found");
                return null;
            }
            logger.LogInformation(" ------ ");
            logger.LogInformation("Returning reviews");
            logger.LogInformation(" ------ ");
            return reviews;

        }

        [HttpGet("{id}")]
        public Review GetReview(int id)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetReview{id} WAS CALLED");
            logger.LogInformation(" ------ ");
            var review = service.GetReview(id);
            if (review == null)
            {
                logger.LogInformation("No review Found");
                return null;
            }
            logger.LogInformation(" ------ ");
            logger.LogInformation("Returning review");
            logger.LogInformation(" ------ ");
            return review;
            
        }

        [HttpPost]
        public void Post(int rating, string comment, int movieID)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Post WAS CALLED");
            logger.LogInformation(" ------ ");
            var rev = new Review(rating, comment);
            service.AddReview(rev, movieID);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Review added succesfully");
            logger.LogInformation(" ------ ");
        }

        [HttpPut]
        public void Put(int id, int rating, string comment)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Put WAS CALLED");
            logger.LogInformation(" ------ ");
            service.UpdateReview(id, rating, comment);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Review updated succesfully");
            logger.LogInformation(" ------ ");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Delete{id} WAS CALLED");
            logger.LogInformation(" ------ ");
            service.DeleteReview(id);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Review deleted succesfully");
            logger.LogInformation(" ------ ");
        }
    }
}
