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
            try
            {
                var reviews = await _reviewService.GetAllAsync();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReviewById(int id)
        {
            try
            {
                var review = await _reviewService.GetByIdReviewAsync(id);
                if (review == null)
                {
                    return NotFound($"Review with ID {id} not found");
                }
                return Ok(review);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewDto reviewDto)
        {
            if (reviewDto == null)
            {
                return BadRequest("Review data is null");
            }

            try
            {
                await _reviewService.AddReviewAsync(reviewDto.ReviewId, reviewDto.Rating, reviewDto.Comment, reviewDto.MovieId);
                return CreatedAtAction(nameof(GetReviewById), new { id = reviewDto.ReviewId }, reviewDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewDto reviewDto)
        {
            if (reviewDto == null || id != reviewDto.ReviewId)
            {
                return BadRequest("Invalid review data");
            }

            try
            {
                var existingReview = await _reviewService.GetByIdReviewAsync(id);
                if (existingReview == null)
                {
                    return NotFound($"Review with ID {id} not found.");
                }

                await _reviewService.UpdateReviewAsync(id, reviewDto.Rating, reviewDto.Comment, reviewDto.MovieId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                var existingReview = await _reviewService.GetByIdReviewAsync(id);
                if (existingReview == null)
                {
                    return NotFound($"Review with ID {id} not found.");
                }

                await _reviewService.DeleteReviewAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("AverageRating/{movieId}")]
        public async Task<ActionResult<float>> GetAverageRating(int movieId)
        {
            try
            {
                var averageRating = await _reviewService.GetTheAverageRatingOfAMovieAsync(movieId);
                if (averageRating == -1)
                {
                    return NotFound($"Movie with ID {movieId} not found.");
                }
                return Ok(averageRating);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Top10Movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetTop10Movies()
        {
            try
            {
                var topMovies = await _reviewService.Top10MoviesWithHigherRatingAsync();
                return Ok(topMovies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
