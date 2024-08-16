using Microsoft.AspNetCore.Mvc;
using Movie_WebAPI.Helpers;
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
        public string AddReview([FromBody] Review review)
        {
            try
            {
                _logService.LogRequest("Add new review.");
                return _reviewService.AddReview(review.MovieId, review.Rating, review.Comment, review.ReviewDate, review.ReviewerName);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                return ex.Message;
            }
        }

        [Route("api/getReviews")]
        [HttpGet]
        public List<Review> GetReviews([FromQuery] PaginationFilter filter)
        {
            try
            {
                _logService.LogRequest("Get all reviews.");
                return PagedList<Review>.ToPagedList(_reviewService.GetAllReviews().AsQueryable(), filter.PageNumber, filter.PageSize);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/getReviewById/ID={id}")]
        [HttpGet]
        public Review GetReviewById(int id)
        {
            try
            {
                _logService.LogRequest($"Get review with id {id}.");
                return _reviewService.GetReviewById(id);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/deleteReview/ID={id}")]
        [HttpDelete]
        public string DeleteReview(int id)
        {
            try
            {
                _logService.LogRequest("Delete a review.");
                return _reviewService.DeleteReview(id);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/updateReview/ID={id}")]
        [HttpPut]
        public string UpdateReview([FromBody] Review review)
        {
            try
            {
                _logService.LogRequest("Update a review.");
                return _reviewService.UpdateReview(review.ID, review.Rating, review.Comment, review.ReviewDate, review.ReviewerName);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                return ex.Message;
            }
        }

        [Route("api/filterByRating/rating={rating}")]
        [HttpGet]
        public List<Review> GetReviewsByRating(double rating, [FromQuery]PaginationFilter filter)
        {
            try
            {
                _logService.LogRequest($"Filter reviews by rating {rating}.");
                return PagedList<Review>.ToPagedList(_reviewService.FilterReviewByRating(rating).AsQueryable(), filter.PageNumber, filter.PageSize);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/averageRating/movieID={movieId}")]
        [HttpGet]
        public int GetAverageRating(int movieId)
        {
            try
            {
                _logService.LogRequest($"Get average rating for movie {movieId}.");
                return _reviewService.AverageRatingForGivenMovie(movieId);
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }

        [Route("api/top10Movies")]
        [HttpGet]
        public List<Movie> GetTop10Movies()
        {
            try
            {
                _logService.LogRequest("Get top 10 movies.");
                return _reviewService.Top10Movies();
            }
            catch (Exception ex)
            {
                _logService.LogResponse(ex.Message);
                throw ex;
            }
        }
    }
}
