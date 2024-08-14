using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Services;

namespace MovieApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private ReviewService _reviewService;

        public ReviewsController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
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

            return Ok(review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            await _reviewService.UpdateReviewAsync(id, review);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostReview(Review review)
        {
            _reviewService.AddReviewAsync(review);
            return CreatedAtAction(nameof(GetReview), new { id = review.ID }, review);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {

            _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }

    }
}
