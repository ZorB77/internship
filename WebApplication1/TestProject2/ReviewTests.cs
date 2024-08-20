using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace TestProject2
{
    [TestFixture]
   public class ReviewTests
    {
        private ReviewController _reviewController;
        private IReviewRepository _reviewRepository;

        [SetUp]
        public void Setup()
        {
            _reviewRepository = Substitute.For<IReviewRepository>();
            _reviewController = new ReviewController(_reviewRepository);
        }

        [Test]
        public async Task AddReview()
        { //arrange
            var review = new ReviewDTO
            {
                Rating = 4,
                Comment="Amazing",
                ReviewCreated = DateTime.Now,
                ReviewerFirstName = "Alexandra"

            };
            var movieName = "The Future of Us";
            //act
            var result = await _reviewController.AddReview(review, movieName);

            //assert
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task GetReviewByRating()
        {
            //arrange
            int rating = 4;
            var reviews = new List<ReviewDTO>
            {
                new ReviewDTO { Rating = rating, Comment = "Great", ReviewCreated = DateTime.Now, ReviewerFirstName = "ALE" },
                new ReviewDTO { Rating = rating, Comment = "Great", ReviewCreated = DateTime.Now, ReviewerFirstName = "daniel" }
            };
            _reviewRepository.GetAllReviewsByRating(rating);
       
            //act
            var result = await _reviewController.GetAllReviewsByRating(rating);
            //assert
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
