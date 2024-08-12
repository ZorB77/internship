using Exercise1.Models;
using Exercise1.Repository;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Services
{
    public class ReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieRepository _movieRepository;

        public ReviewService(IReviewRepository reviewRepository, IMovieRepository movieRepository)
        {
            _reviewRepository = reviewRepository;
            _movieRepository = movieRepository;
        }

        public void AddNewReview()
        {
            string movieName = Validation("Enter the movie name you want to leave a review: ");

            var movie = _movieRepository.GetMovie(movieName);

            if (movie != null)
            {
                var review = new Review
                {
                    Rating = ValidationInt("Enter the rating between 1 and 10: ", 1, 10),
                    Comment = Validation("Enter the comment ypu want to leave: "),
                    MovieId = movie.MovieID
                };
                _reviewRepository.AddReview(review);
                Console.WriteLine("Your review was added");


            }
        }

        public void GetReviews()
        {
            var reviews = _reviewRepository.GetAllReviews();
            foreach (var review in reviews)
            {
                Console.WriteLine($"Id: {review.ReviewID}, rating:{review.Rating}, comment: {review.Comment}, movie: {review.Movie.Name}");
            }
        }

        public void DeleteReview()
        {
            GetReviews();
            int id = ValidationInt("Enter the id of the reiew you want to delete: ");
            _reviewRepository.DeleteReview(id);
            Console.WriteLine("The review was deleted!");

        }

        public void UpdateReview()
        {
            GetReviews();
            int id = ValidationInt("Please enter the id of the review you want to update: ");
            var review = _reviewRepository.GetReviewById(id);

            if(review != null)
            {
                Console.WriteLine("Enter new rating or leave empty to keep the current rating: ");
                string newRating = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newRating) && int.TryParse(newRating, out int rating))
                {
                    review.Rating = rating;
                }

                Console.WriteLine("Enter new comment or leave empty to keep the current comment: ");
                string newComment = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newComment))
                {
                    review.Comment = newComment;
                }
                Console.WriteLine("Enter new name of the movie or leave empty to keep the current movie: ");
                string newMovieName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newMovieName))
                {
                    var movie = _movieRepository.GetMovie(newMovieName);
                    if (movie != null)
                    {
                        review.MovieId = movie.MovieID;
                    }
                    else
                    {
                        Console.WriteLine("Movie not found. The movie will not be updated.");
                    }
                }
                _reviewRepository.UpdateReview(review);
                Console.WriteLine("The review was updated!");


            }

        }
        //get reviews by movie name
        public void GetReviewsByMovieName()
        {
            string movieName = Validation("Enter the movie name to get the reviews: ");
            var reviews = _reviewRepository.GetReviewByMovie(movieName);

            foreach (var review in reviews)
            {
                Console.WriteLine($"Id: {review.ReviewID}, rating:{review.Rating}, comment: {review.Comment}, movie: {review.Movie.Name}");
            }
        }
        //filter reviews by rating
        public void GetReviewsByRating()
        {
            int rating = ValidationInt("Enter the rating you want to filter the movies by: ", 1, 10);
            var reviews = _reviewRepository.GetAllReviewsByRating(rating);

            if(reviews != null)
            {
                Console.WriteLine("The movies are: ");
                foreach(var review in reviews)
                {
                    Console.WriteLine($" Movie: {review.Movie.Name}, Year:{review.Movie.Year}, Description: {review.Movie.Description}, Rating: {review.Rating}");
                }
            }
        }
        //filter reviews by some keywords that will be found in the comment section
        public void GetReviewsByKeywords()
        {
            string keyword = Validation("Enter the keyword to filter the review: ");
            var reviews =  _reviewRepository.GetAllReviewsByKeywords(keyword);

            if(reviews != null)
            {
                Console.WriteLine("The movies are: ");
                foreach(var review in reviews)
                {
                    Console.WriteLine($"Name : {review.Movie.Name}, Year: {review.Movie.Year}, Description: {review.Movie.Description}, Rating: {review.Rating}, Comment: {review.Comment}");
                }
            }
            else
            {
                Console.WriteLine("The keywords wasn't found in the review(comment)!");
            }
        }

        //average rating by movie name
        public void DisplyAverageRating()
        {
            string movie = Validation("Enter the movie name you want to find out the average rating for: ");
            var avg = _reviewRepository.AverageRating(movie);

            if(avg > 0)
            {
                Console.WriteLine($"The average rating for the movie {movie} is {avg}");
            }
        }
        //method for validating string inputs
        public string Validation(string message)
        {
            Console.Write(message);
            string inputUser = Console.ReadLine();
            while (inputUser == null)
            {
                Console.Write("Please introduce the required information!");
                Console.Write(message);
                inputUser = Console.ReadLine();
            }
            return inputUser;
        }
        //method for validating int inputs
        public int ValidationInt(string message, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            Console.WriteLine(message);
            string inputUser = Console.ReadLine();
            int intValue;
            while (!int.TryParse(inputUser, out intValue) || intValue < minValue || intValue > maxValue)
            {
                Console.WriteLine($"The entry must be between {minValue} and {maxValue}");
                Console.Write(message);
                inputUser = Console.ReadLine();
            }
            return intValue;
        }
    }

}
