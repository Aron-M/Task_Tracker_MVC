using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using TaskTrackerMVC.Models;
using System.Text;

namespace TaskTrackerMVC.Services
{
    public class TaskAPIService
    {
        private readonly HttpClient _httpClient;

        public TaskAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            var response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var tasks = JsonSerializer.Deserialize<IEnumerable<TaskModel>>(content);
            return tasks ?? new List<TaskModel>(); // Return an empty list if null
        }

        public async Task<TaskModel> GetTaskByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var task = JsonSerializer.Deserialize<TaskModel>(content);
            return task ?? new TaskModel(); // Return a new TaskModel if null
        }

        public async Task CreateTaskAsync(TaskModel task)
        {
            var content = new StringContent(JsonSerializer.Serialize(task), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateTaskAsync(TaskModel task)
        {
            var content = new StringContent(JsonSerializer.Serialize(task), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{task.TaskId}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}