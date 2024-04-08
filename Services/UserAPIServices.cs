using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using TaskTrackerMVC.Models;
using System.Text;

namespace TaskTrackerMVC.Services
{
    public class UserAPIService
    {
        private readonly HttpClient _httpClient;

        public UserAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<IEnumerable<UserModel>>(content);
            return users ?? new List<UserModel>(); // Handle potential null value
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<UserModel>(content);
            return user ?? throw new InvalidOperationException("User not found."); // Handle potential null value
        }

        public async Task CreateUserAsync(UserModel user)
        {
            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateUserAsync(UserModel user)
        {
            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{user.UserId}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}