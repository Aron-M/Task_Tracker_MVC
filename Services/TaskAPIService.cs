// Services/TaskAPIService.cs
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

namespace TaskTrackerMVC.Services // Remove the semicolon here
{
    public class TaskAPIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress = "https://example.com/api/tasks"; // Replace with the actual base address

        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            var response = await _httpClient.GetAsync(_baseAddress);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var tasks = JsonSerializer.Deserialize<IEnumerable<TaskModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return tasks ?? Enumerable.Empty<TaskModel>();
        }

        // Add methods for POST, PUT, DELETE, etc.
    }
}
