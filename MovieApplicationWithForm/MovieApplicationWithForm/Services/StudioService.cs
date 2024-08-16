using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MovieApplicationWithForm.Services
{
    public class StudioService
    {
        private readonly HttpClient httpClient;

        public StudioService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<Studio> GetAllStudios()
        {
            var response = httpClient.GetAsync("api/studios").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<Studio>>(jsonResponse);
        }

        public Studio GetStudio(int studioId)
        {
            var response = httpClient.GetAsync($"api/studios/{studioId}").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Studio>(jsonResponse);
        }

        public void AddStudio(Studio studio)
        {
            var studioJson = JsonSerializer.Serialize(studio);
            var content = new StringContent(studioJson, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("api/studios", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void UpdateStudio(Studio studio)
        {
            var studioJson = JsonSerializer.Serialize(studio);
            var content = new StringContent(studioJson, Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync($"api/studios/{studio.id}", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void DeleteStudio(int studioId)
        {
            var response = httpClient.DeleteAsync($"api/studios/{studioId}").Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
