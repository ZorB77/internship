using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Services;
using MovieApplicationWebAPI.Utilities;

namespace MovieApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private ReviewService _reviewService;
        private LogWriter _logWriter;

        public ReviewsController(ReviewService reviewService, LogWriter logWriter)
        {
            _reviewService = reviewService;
            _logWriter = logWriter;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            _logWriter.Log($"Get reviews.");
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _reviewService.GetReviewAsync(id);

            if (review == null)
            {
                return NotFound();
            }
            _logWriter.Log($"Get review with id {id}.");
            return Ok(review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, ReviewMapper reviewMapper)
        {
            await _reviewService.UpdateReviewAsync(id, reviewMapper);
            _logWriter.Log($"Update review with id {id}.");
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostReview(ReviewMapper reviewMapper)
        {

            _reviewService.AddReviewAsync(reviewMapper);
            _logWriter.Log($"Add review: {reviewMapper.Comment}.");
            return CreatedAtAction(nameof(GetReview), new { id = reviewMapper.Id }, reviewMapper);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {

            _reviewService.DeleteReviewAsync(id);
            _logWriter.Log($"Delete review with id {id}.");
            return NoContent();
        }

    }
}
