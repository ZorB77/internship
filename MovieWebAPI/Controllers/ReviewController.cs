using Microsoft.AspNetCore.Mvc;
using Movies.Services;
using MovieWebAPI.Models.DTOs;

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
        public async Task<ActionResult<IEnumerable<Review>>> GetAllReviews()
        {

            var reviews = await _reviewService.GetAllAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReviewById(int id)
        {

            var review = await _reviewService.GetByIdReviewAsync(id);
            if (review == null)
            {
                return NotFound($"Review with ID {id} not found");
            }
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewDto reviewDto)
        {
            if (reviewDto == null)
            {
                return BadRequest("Review data is null");
            }


            await _reviewService.AddReviewAsync(reviewDto.ReviewId, reviewDto.Rating, reviewDto.Comment, reviewDto.MovieId);
            return CreatedAtAction(nameof(GetReviewById), new { id = reviewDto.ReviewId }, reviewDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewDto reviewDto)
        {
            if (reviewDto == null || id != reviewDto.ReviewId)
            {
                return BadRequest("Invalid review data");
            }


            var existingReview = await _reviewService.GetByIdReviewAsync(id);
            if (existingReview == null)
            {
                return NotFound($"Review with ID {id} not found.");
            }

            await _reviewService.UpdateReviewAsync(id, reviewDto.Rating, reviewDto.Comment, reviewDto.MovieId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {

            var existingReview = await _reviewService.GetByIdReviewAsync(id);
            if (existingReview == null)
            {
                return NotFound($"Review with ID {id} not found.");
            }

            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }

        [HttpGet("AverageRating/{movieId}")]
        public async Task<ActionResult<float>> GetAverageRating(int movieId)
        {
            var averageRating = await _reviewService.GetTheAverageRatingOfAMovieAsync(movieId);
            if (averageRating == -1)
            {
                return NotFound($"Movie with ID {movieId} not found.");
            }
            return Ok(averageRating);
        }

        [HttpGet("Top10Movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetTop10Movies()
        {
            var topMovies = await _reviewService.Top10MoviesWithHigherRatingAsync();
            return Ok(topMovies);
        }
    }

}
