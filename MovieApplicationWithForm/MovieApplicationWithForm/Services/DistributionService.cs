using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MovieApplicationWithForm.Services
{
    public class DistributionService
    {
        private readonly HttpClient httpClient;

        public DistributionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<MovieStudioDistribution> GetAllDistributions()
        {
            var response = httpClient.GetAsync("api/distributions").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<MovieStudioDistribution>>(jsonResponse);
        }

        public MovieStudioDistribution GetDistribution(int distributionId)
        {
            var response = httpClient.GetAsync($"api/distributions/{distributionId}").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<MovieStudioDistribution>(jsonResponse);
        }

        public void AddDistribution(MovieStudioDistribution distribution)
        {
            var distributionJson = JsonSerializer.Serialize(distribution);
            var content = new StringContent(distributionJson, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("api/distributions", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void UpdateDistribution(MovieStudioDistribution distribution)
        {
            var distributionJson = JsonSerializer.Serialize(distribution);
            var content = new StringContent(distributionJson, Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync($"api/distributions/{distribution.id}", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void DeleteDistribution(int distributionId)
        {
            var response = httpClient.DeleteAsync($"api/distributions/{distributionId}").Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
