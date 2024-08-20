using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAllReviews([FromQuery] Parameters parameters)
        {
            var reviews = await _reviewRepository.GetAllRevies(parameters);
            var metadata = new
            {
                reviews.TotalCount,
                reviews.PageSize,
                reviews.CurrentPage,
                reviews.HasNext,
                reviews.HasPrevious,
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReviewById(int id)
        {
            var review = await _reviewRepository.GetReviewById(id);
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewDTO reviewDTO, [FromQuery] string movieName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _reviewRepository.AddReview(reviewDTO, movieName);
                return Ok();
           
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewDTO reviewDTO, [FromQuery] string movieName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            await _reviewRepository.UpdateReview(id, reviewDTO, movieName);
                return Ok();
         
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            var review = await _reviewRepository.GetReviewById(id);
         
            await _reviewRepository.DeleteReview(id);
            return Ok();
        }

        [HttpGet("movie/{movieName}")]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReviewByMovie(string movieName)
        {
            var reviews = await _reviewRepository.GetReviewByMovie(movieName);
            return Ok(reviews);
        }

        [HttpGet("rating/{rating}")]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAllReviewsByRating(int rating)
        {
            var reviews = await _reviewRepository.GetAllReviewsByRating(rating);
            return Ok(reviews);
        }

        [HttpGet("keywords/{keywords}")]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAllReviewsByKeywords(string keywords)
        {
            var reviews = await _reviewRepository.GetAllReviewsByKeywords(keywords);
            return Ok(reviews);
        }

        [HttpGet("average-rating/{movieName}")]
        public async Task<ActionResult<double>> AverageRating(string movieName)
        {
            var rating = await _reviewRepository.AverageRating(movieName);
            return Ok(rating);
        }
    }
}
