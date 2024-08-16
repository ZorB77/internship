using Microsoft.AspNetCore.Mvc;
using Movies.Services;
using System.Collections.Generic;

namespace Movies.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetAllReviews()
        {
            var reviews = _reviewService.GetAll();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public ActionResult<Review> GetReviewById(int id)
        {
            var review = _reviewService.GetByIdReview(id);
            if (review == null)
            {
                return NotFound(new { Message = "Review not found." });
            }
            return Ok(review);
        }

        [HttpPost]
        public IActionResult AddReview(int reviewId, float rating, string comment, int movieId)
        {
            _reviewService.AddReview(reviewId, rating, comment, movieId);
            return CreatedAtAction(nameof(GetReviewById), new { id = reviewId }, new { reviewId, rating, comment, movieId });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReview(int id, float rating, string comment, int movieId)
        {
            var existingReview = _reviewService.GetByIdReview(id);
            if (existingReview == null)
            {
                return NotFound(new { Message = "Review not found." });
            }

            _reviewService.UpdateReview(id, rating, comment, movieId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            var existingReview = _reviewService.GetByIdReview(id);
            if (existingReview == null)
            {
                return NotFound(new { Message = "Review not found." });
            }

            _reviewService.DeleteReview(id);
            return NoContent();
        }

        [HttpGet("AverageRating/{movieId}")]
        public ActionResult<float> GetAverageRating(int movieId)
        {
            var averageRating = _reviewService.GetTheAverageRatingOfAMovie(movieId);
            if (averageRating == -1)
            {
                return NotFound(new { Message = "Movie not found." });
            }

            return Ok(averageRating);
        }

        [HttpGet("Top10Movies")]
        public ActionResult<IEnumerable<Movie>> GetTop10Movies()
        {
            var topMovies = _reviewService.Top10MoviesWithHigherRating();
            return Ok(topMovies);
        }
    }
}
