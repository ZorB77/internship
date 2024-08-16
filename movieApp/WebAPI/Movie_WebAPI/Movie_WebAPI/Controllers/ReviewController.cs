using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Services;
using MovieApplication.Services;

namespace Movie_WebAPI.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;
        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/addReview")]
        [HttpPost]
        public string AddReview([FromBody]Review review)
        {
           return _reviewService.AddReview(review.MovieId, review.Rating, review.Comment, review.ReviewDate, review.ReviewerName); 
        }

        [Route("api/getReviews")]
        [HttpGet]
        public List<Review> GetReviews()
        {
            return _reviewService.GetAllReviews();
        }

        [Route("api/getReviewById/ID={id}")]
        [HttpGet]
        public Review GetReviewById(int id)
        {
            return _reviewService.GetReviewById(id);
        }

        [Route("api/deleteReview/ID={id}")]
        [HttpDelete]
        public bool DeleteReview(int id)
        {
            return _reviewService.DeleteReview(id);
        }

        [Route("api/updateReview/ID={id}")]
        [HttpPut]
        public string UpdateReview([FromBody]Review review)
        {
            return _reviewService.UpdateReview(review.ID, review.Rating, review.Comment, review.ReviewDate, review.ReviewerName);
        }

        [Route("api/filterByRating/rating={rating}")]
        [HttpGet]
        public List<Review> GetReviewsByRating(double rating)
        {
            return _reviewService.FilterReviewByRating(rating);
        }

        [Route("api/averageRating/movieID={movieId}")]
        [HttpGet]
        public int GetAverageRating(int movieId)
        {
            return _reviewService.AverageRatingForGivenMovie(movieId);
        }

        [Route("api/top10Movies")]
        [HttpGet]
        public List<Movie> GetTop10Movies()
        {
            return _reviewService.Top10Movies();
        }
    }
}
