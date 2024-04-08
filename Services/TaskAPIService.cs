using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using TaskTrackerMVC.Models;
using System.Text;


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
            return JsonSerializer.Deserialize<IEnumerable<TaskModel>>(content);
        }

        public async Task<TaskModel> GetTaskByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TaskModel>(content);
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
