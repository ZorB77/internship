using MovieApplicationWithForm.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MovieApplicationWithForm.Services
{
    public class ReviewService
    {
        private readonly HttpClient httpClient;

        public ReviewService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<Review> GetAllReviews()
        {
            var response = httpClient.GetAsync("api/reviews").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<Review>>(jsonResponse);
        }

        public List<Review> GetReviews(string column, string criteria)
        {
            var review = GetAllReviews();
            if (column == "Movie name")
            {
                review = review.Where(m => m.movie.name.Contains(criteria)).ToList();
            }
            else if (column == "Comment")
            {
                review = review.Where(m => m.comment.Contains(criteria)).ToList();
            }
            return review.ToList();
        }

        public Review GetReview(int reviewId)
        {
            var response = httpClient.GetAsync($"api/reviews/{reviewId}").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Review>(jsonResponse);
        }

        /*public void AddReview(Review review)
        {
            var reviewJson = JsonSerializer.Serialize(review);
            var content = new StringContent(reviewJson, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("api/reviews", content).Result;
            response.EnsureSuccessStatusCode();
        }*/

        public void AddReview(ReviewMapper review)
        {
            var reviewJson = JsonSerializer.Serialize(review);
            var content = new StringContent(reviewJson, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("api/reviews", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void UpdateReview(Review review)
        {
            var reviewJson = JsonSerializer.Serialize(review);
            var content = new StringContent(reviewJson, Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync($"api/reviews/{review.id}", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void DeleteReview(int reviewId)
        {
            var response = httpClient.DeleteAsync($"api/reviews/{reviewId}").Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
