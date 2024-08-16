using Microsoft.AspNetCore.Mvc;
using Movie_WebAPI.Services;
using MovieApp.Models;
using MovieApp.Services;
using MovieApplication.Services;

namespace Movie_WebAPI.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;
        private readonly LogService _logService;
        public ReviewController(ReviewService reviewService, LogService logService)
        {
            _reviewService = reviewService;
            _logService = logService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/addReview")]
        [HttpPost]
        public string AddReview([FromBody]Review review)
        {
            _logService.LogRequest("Add new review.");
            return _reviewService.AddReview(review.MovieId, review.Rating, review.Comment, review.ReviewDate, review.ReviewerName); 
        }

        [Route("api/getReviews")]
        [HttpGet]
        public List<Review> GetReviews()
        {
            _logService.LogRequest("Get all reviews.");
            return _reviewService.GetAllReviews();
        }

        [Route("api/getReviewById/ID={id}")]
        [HttpGet]
        public Review GetReviewById(int id)
        {
            _logService.LogRequest($"Get review with id {id}.");
            return _reviewService.GetReviewById(id);
        }

        [Route("api/deleteReview/ID={id}")]
        [HttpDelete]
        public bool DeleteReview(int id)
        {
            _logService.LogRequest("Delete a review.");
            return _reviewService.DeleteReview(id);
        }

        [Route("api/updateReview/ID={id}")]
        [HttpPut]
        public string UpdateReview([FromBody]Review review)
        {
            _logService.LogRequest("Update a review.");
            return _reviewService.UpdateReview(review.ID, review.Rating, review.Comment, review.ReviewDate, review.ReviewerName);
        }

        [Route("api/filterByRating/rating={rating}")]
        [HttpGet]
        public List<Review> GetReviewsByRating(double rating)
        {
            _logService.LogRequest($"Filter reviews by rating {rating}.");
            return _reviewService.FilterReviewByRating(rating);
        }

        [Route("api/averageRating/movieID={movieId}")]
        [HttpGet]
        public int GetAverageRating(int movieId)
        {
            _logService.LogRequest($"Get average rating for movie {movieId}.");
            return _reviewService.AverageRatingForGivenMovie(movieId);
        }

        [Route("api/top10Movies")]
        [HttpGet]
        public List<Movie> GetTop10Movies()
        {
            _logService.LogRequest("Get top 10 movies.");
            return _reviewService.Top10Movies();
        }
    }
}
