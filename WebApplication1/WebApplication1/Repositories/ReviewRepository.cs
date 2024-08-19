using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ReviewRepository: IReviewRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ReviewRepository> _logger;

        public ReviewRepository(DataContext dataContext, IMapper mapper, ILogger<ReviewRepository> logger)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddReview(ReviewDTO reviewDTO, string movieName)
        {
            _logger.LogInformation("DeleteReview method was called! ");
            var movie = await _dataContext.Movies.FirstOrDefaultAsync(m => m.Name == movieName);
            if (movie != null)
            {
                var review = _mapper.Map<Review>(reviewDTO);
                review.MovieId = movie.Id;
                review.ReviewCreated = DateTime.Now;
                _dataContext.Reviews.Add(review);
                await _dataContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Movie not found");
            }
        }

        public async Task<double> AverageRating(string movieName)
        {
            var rating = await _dataContext.Reviews.Where(r => r.Movie.Name == movieName).AverageAsync(r => r.Rating);
            return rating;
        }

        public async Task DeleteReview(int id)
        {
            _logger.LogInformation("DeleteReview method was called! ");
            var review = await _dataContext.Reviews.FindAsync(id);
            if (review != null)
            {
                _dataContext.Reviews.Remove(review);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<PagedList<ReviewDTO>> GetAllRevies(Parameters parameters)
        {
            _logger.LogInformation("Get all reviews method was called! ");
            var reviews = _dataContext.Reviews.AsQueryable();
            var pagedReviews = await PagedList<Review>.ToPagedList(reviews, parameters.PageNumber, parameters.PageSize);
            var mappedReviews = _mapper.Map<List<ReviewDTO>>(pagedReviews);
            var pagedReviewsDto = new PagedList<ReviewDTO>(mappedReviews, pagedReviews.TotalCount, pagedReviews.CurrentPage, pagedReviews.PageSize);
            return pagedReviewsDto;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllReviewsByKeywords(string keywords)
        {
            var reviews = await _dataContext.Reviews.Include(r=> r.Movie).Where( r=>r.Comment.Contains(keywords)).ToListAsync();
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllReviewsByRating(int rating)
        {
            var reviews = await _dataContext.Reviews.Include(r =>r.Movie).Where(r =>r.Rating==rating).ToListAsync();
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task<ReviewDTO> GetReviewById(int id)
        {
            var review = await _dataContext.Reviews.Include(r => r.Movie).FirstOrDefaultAsync(r => r.Id == id);
            return _mapper.Map<ReviewDTO>(review); 
        }

        public async Task<IEnumerable<ReviewDTO>> GetReviewByMovie(string movieName)
        {
            var review = await _dataContext.Reviews.Include(r => r.Movie).Where(r => r.Movie.Name == movieName).ToListAsync();
            return _mapper.Map<IEnumerable<ReviewDTO>>(review);
        }

        public async Task UpdateReview(int id, ReviewDTO reviewDTO, string movieName)
        {
            _logger.LogInformation("Update Review method was called! ");
            var movie = await _dataContext.Movies.FirstOrDefaultAsync(m => m.Name == movieName);
            if (movie == null)
            {
                throw new KeyNotFoundException("Movie not found");
            }
            var review = await _dataContext.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            if (review == null)
            {
                throw new KeyNotFoundException("Review not found");
            }
            _mapper.Map(reviewDTO, review);
            review.MovieId = movie.Id;
            await _dataContext.SaveChangesAsync();
        }
    }
}
