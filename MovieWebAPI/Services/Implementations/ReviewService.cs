using Movies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Services
{
    internal class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IRepository<Movie> _movieRepository;
        public ReviewService(IReviewRepository reviewRepository, IRepository<Movie> movieRepository)
        {
            _reviewRepository = reviewRepository;
            _movieRepository = movieRepository;
        }

        public void AddReview(int reviewId, float rating, string comment, int movieId)
        {
            try
            {
                if (_reviewRepository.GetById(reviewId) != null)
                {
                    throw new Exception("Error: there is already a review with this id");
                }
                else if (_movieRepository.GetById(movieId) == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }
                _reviewRepository.Add(new Review(reviewId, rating, comment, _movieRepository.GetById(movieId)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateReview(int reviewId, float rating, string comment, int movieId)
        {
            try
            {
                if (_reviewRepository.GetById(reviewId) == null)
                {
                    throw new Exception("Error: there is no review with this id");
                }
                else if (_movieRepository.GetById(movieId) == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }
                _reviewRepository.Update(new Review(reviewId, rating, comment, _movieRepository.GetById(movieId)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteReview(int reviewId)
        {
            try
            {
                if (_reviewRepository.GetById(reviewId) == null)
                {
                    throw new Exception("Error: there is no review with this id");
                }
                _reviewRepository.Remove(_reviewRepository.GetById(reviewId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public Review GetByIdReview(int reviewId)
        {
            try
            {
                if (_reviewRepository.GetById(reviewId) == null)
                {
                    throw new Exception("Error: there is no review with this id");
                }
                return _reviewRepository.GetById(reviewId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public List<Review> GetAll()
        {
            return _reviewRepository.GetAll().ToList();
        }

        public float GetTheAverageRatingOfAMovie(int movieId)
        {
            if (_movieRepository.GetById(movieId) != null)
            {
                var reviews = _reviewRepository.GetAll().Where(r => r.Movie.MovieId == movieId);
                if (!reviews.Any())
                {
                    return 0;
                }
                else
                {
                    return reviews.Average(r => r.Rating);
                }
            }
            else
            {
                return -1;
            }
        }
        public List<Movie> Top10MoviesWithHigherRating()
        {

            var moviesWithRatings = _movieRepository.GetAll()
            .OrderByDescending(m => GetTheAverageRatingOfAMovie(m.MovieId))
            .Take(10)
            .ToList();

            return moviesWithRatings;
        }


    }

}
