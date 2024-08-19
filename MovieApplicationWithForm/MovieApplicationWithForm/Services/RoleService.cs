using MovieApplicationWithForm.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MovieApplicationWithForm.Services
{
    public class RoleService
    {
        private readonly HttpClient httpClient;

        public RoleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<Role> GetAllRoles()
        {
            var response = httpClient.GetAsync("api/roles").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<Role>>(jsonResponse);
        }

        public List<Role> GetRoles(string column, string criteria)
        {
            var roles = GetAllRoles();
            if (column == "Name")
            {
                roles = roles.Where(m => m.name.Contains(criteria)).ToList();
            }
            else if (column == "Description")
            {
                roles = roles.Where(m => m.description.Contains(criteria)).ToList();
            }
            return roles.ToList();
        }

        public Role GetRole(int roleId)
        {
            var response = httpClient.GetAsync($"api/roles/{roleId}").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Role>(jsonResponse);
        }

        public void AddRole(RoleMapper role)
        {
            var roleJson = JsonSerializer.Serialize(role);
            var content = new StringContent(roleJson, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("api/roles", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void UpdateRole(RoleMapper role)
        {
            var roleJson = JsonSerializer.Serialize(role);
            var content = new StringContent(roleJson, Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync($"api/roles/{role.ID}", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void DeleteRole(int roleId)
        {
            var response = httpClient.DeleteAsync($"api/roles/{roleId}").Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
