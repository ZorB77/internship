using MovieAppRESTAPI.Repositories;
using MovieWinForms.Models;

namespace MovieAppRESTAPI.Services
{
    public class ReviewService
    {
        private readonly IRepository<Review> _reviewRepository;
        private readonly IRepository<Movie> _movieRepository;
        public ReviewService(IRepository<Review> reviewRepository, IRepository<Movie> movieRepository)
        {
            _reviewRepository = reviewRepository;
            _movieRepository = movieRepository;
        }
        public void AddReview(Review entity)
        {
            _reviewRepository.Add(entity);
        }
        public IEnumerable<Review> GetReviews()
        {
            return _reviewRepository.GetAll();
        }
        public Review GetReviewById(int id)
        {
            return _reviewRepository.GetById(id);
        }
        public IEnumerable<Review> GetReviewsByMovieId(int movieId)
        {
            return _reviewRepository.GetAll().Where(r => r.Movie.Id == movieId).ToList();
        }
        public decimal GetAverageRating(int movieId)
        {
            return Math.Round(GetReviewsByMovieId(movieId).Average(r => r.Rating), 2);
        }
        public void UpdateReview(Review entity)
        {
            var review = _reviewRepository.GetById(entity.Id);
            review.Rating = entity.Rating;
            review.Comment = entity.Comment;
            review.CreationDate = review.CreationDate;
            review.Movie = entity.Movie;
            _reviewRepository.Update(review);
        }
        public void DeleteReview(int id)
        {
            try
            {
                _reviewRepository.Delete(id);
            }
            catch
            {
                throw new Exception();
            }
        }

    }
}
