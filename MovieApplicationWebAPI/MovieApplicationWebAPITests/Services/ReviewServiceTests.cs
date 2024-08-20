using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.DataAccess;
using MovieApplicationWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationWebAPI.Services
{
    public class ReviewServiceTests
    {
        private ReviewService _reviewService;
        private MyDBContext _myDBContext;

        public ReviewServiceTests()
        {
            var options = new DbContextOptionsBuilder<MyDBContext>()
                .UseInMemoryDatabase(databaseName: "MovieApplicationTestDatabaseReviews")
                .Options;

            _myDBContext = new MyDBContext(options);
            _myDBContext.reviews.RemoveRange(_myDBContext.reviews);
            _myDBContext.SaveChanges();

            var movie = new Movie { Name = "Frozen", Description = "Two sisters.", Genre = "Animation", ReleaseDate = new DateTime(2014, 12, 5) };

            _myDBContext.reviews.Add(new Review { ID = 1, Comment = "Good movie.", Movie = movie, Rating = 5 });
            _myDBContext.reviews.Add(new Review { ID = 2, Comment = "Bad movie.", Movie = movie, Rating = 2 });
            _myDBContext.SaveChanges();

            _reviewService = new ReviewService(_myDBContext);
        }

        [Fact]
        public async Task ShouldGetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();

            Assert.NotNull(reviews);
            Assert.Equal(2, reviews.ToList().Count());
        }

        [Fact]
        public async Task ShouldGetSpecificReview()
        {
            var review = await _reviewService.GetReviewAsync(99999);
            var review2 = await _reviewService.GetReviewAsync(1);

            Assert.Null(review);
            Assert.NotNull(review2);
            Assert.Equal("Good movie.", review2.Comment);


        }

        [Fact]
        public async Task ShouldAddReview()
        {
            var newReview = new ReviewMapper { Id = 3, Comment = "Very nice.", Rating = 4, MovieID = 1 };

            await _reviewService.AddReviewAsync(newReview);
            var review = await _myDBContext.reviews.FirstOrDefaultAsync(r => r.Comment == "Very nice.");

            Assert.NotNull(review);
            Assert.Equal("Very nice.", review.Comment);
        }

        [Fact]
        public async Task ShouldUpdateReview()
        {
            var reviewToUpdate = new ReviewMapper { Id = 2, Comment = "Comment updated", Rating = 5, MovieID = 1 };

            await _reviewService.UpdateReviewAsync(2, reviewToUpdate);
            var updatedReview = await _reviewService.GetReviewAsync(2);

            Assert.NotNull(updatedReview);
            Assert.Equal("Comment updated", updatedReview.Comment);
        }

        [Fact]
        public async Task ShouldDeleteReview()
        {
            await _reviewService.DeleteReviewAsync(1);
            var deletedReview = await _reviewService.GetReviewAsync(1);

            Assert.Null(deletedReview);
        }
    }
}
