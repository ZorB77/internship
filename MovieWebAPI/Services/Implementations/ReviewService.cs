using Movies.Persistance;
using MovieWebAPI.Persistance;

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

        public async Task AddReviewAsync(int reviewId, float rating, string comment, int movieId)
        {
            try
            {
                var existingReview = await _reviewRepository.GetByIdAsync(reviewId);
                if (existingReview != null)
                {
                    throw new Exception("Error: there is already a review with this id");
                }

                var movie = await _movieRepository.GetByIdAsync(movieId);
                if (movie == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }

                var review = new Review(reviewId, rating, comment, movie);
                await _reviewRepository.AddAsync(review);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateReviewAsync(int reviewId, float rating, string comment, int movieId)
        {
            try
            {
                var existingReview = await _reviewRepository.GetByIdAsync(reviewId);
                if (existingReview == null)
                {
                    throw new Exception("Error: there is no review with this id");
                }

                var movie = await _movieRepository.GetByIdAsync(movieId);
                if (movie == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }

                var review = new Review(reviewId, rating, comment, movie);
                await _reviewRepository.UpdateAsync(review);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteReviewAsync(int reviewId)
        {
            try
            {
                var review = await _reviewRepository.GetByIdAsync(reviewId);
                if (review == null)
                {
                    throw new Exception("Error: there is no review with this id");
                }

                await _reviewRepository.RemoveAsync(review);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Review> GetByIdReviewAsync(int reviewId)
        {
            try
            {
                var review = await _reviewRepository.GetByIdAsync(reviewId);
                if (review == null)
                {
                    throw new Exception("Error: there is no review with this id");
                }
                return review;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<Review>> GetAllAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return reviews.ToList();
        }

        public async Task<float> GetTheAverageRatingOfAMovieAsync(int movieId)
        {
            var movie = await _movieRepository.GetByIdAsync(movieId);
            if (movie != null)
            {
                var reviews = (await _reviewRepository.GetAllAsync()).Where(r => r.Movie.MovieId == movieId);
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

        public async Task<List<Movie>> Top10MoviesWithHigherRatingAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            var topMovies = movies.OrderByDescending(m => GetTheAverageRatingOfAMovieAsync(m.MovieId).Result)
                                  .Take(10)
                                  .ToList();

            return topMovies;
        }
    }
}
