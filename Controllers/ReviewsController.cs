using Microsoft.AspNetCore.Mvc;
using MovieAppRESTAPI.DTOs.MovieDTOs;
using MovieAppRESTAPI.DTOs.ReviewDTOs;
using MovieAppRESTAPI.Services;
using MovieWinForms.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAppRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewService _service;
        private readonly MovieService _movieService;

        public ReviewsController(ReviewService service, MovieService movieService)
        {
            _service = service;
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var reviews = _service.GetReviews();
                return Ok(reviews.Select(r => new ReviewDTO
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    CreationDate = r.CreationDate,
                    MovieId = r.Movie.Id
                }));
            } catch
            {
                return BadRequest("Couldn't fetch all the Reviews");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var review = _service.GetReviewById(id);
                return Ok(new ReviewDTO
                {
                    Id = review.Id,
                    Rating = review.Rating,
                    Comment = review.Comment,
                    CreationDate = review.CreationDate,
                    MovieId = review.Movie.Id
                });
            } catch
            {
                return NotFound($"Review with id {id} not found.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateReviewDTO reviewDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var review = new Review 
                {
                    Rating = reviewDTO.Rating,
                    Comment = reviewDTO.Comment,
                    CreationDate = DateTime.Now,
                    Movie = _movieService.GetMovieById(reviewDTO.MovieId)
                };
                _service.AddReview(review);
                return Ok("Review added successfully");
            } catch
            {
                return BadRequest("Couldn't create review.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateReviewDTO updatedReviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var review = new Review
                {
                    Id = id,
                    Rating = updatedReviewDto.Rating,
                    Comment = updatedReviewDto.Comment,
                    Movie = _movieService.GetMovieById(updatedReviewDto.MovieId)
                };
                _service.UpdateReview(review);
                return Ok("Review updated successfully");
            } catch
            {
                return BadRequest($"Couldn't update Review with ID {id}.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteReview(id);
                return Ok("Review deleted successfully");
            }
            catch
            {
                return BadRequest("Review not found");
            }
        }
    }
}
