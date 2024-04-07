// Services/TaskAPIService.cs
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
        private readonly string _baseAddress;

        public TaskAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseAddress = "http://localhost:5000/api/tasks"; // Replace with your API's base URL
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            var response = await _httpClient.GetAsync(_baseAddress);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TaskModel>>(content);
        }

        public async Task<TaskModel> GetTaskByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseAddress}/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TaskModel>(content);
        }

        public async Task CreateTaskAsync(TaskModel task)
        {
            var content = new StringContent(JsonSerializer.Serialize(task), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_baseAddress, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateTaskAsync(TaskModel task)
        {
            var content = new StringContent(JsonSerializer.Serialize(task), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseAddress}/{task.TaskId}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseAddress}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
public class TaskAPIService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseAddress;

    public TaskAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _baseAddress = "http://localhost:5000/api/tasks"; // Replace with your API's base URL
    }

    public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
    {
        var response = await _httpClient.GetAsync(_baseAddress);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<TaskModel>>(content);
    }

    public async Task<TaskModel> GetTaskByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TaskModel>(content);
    }

    public async Task CreateTaskAsync(TaskModel task)
    {
        var content = new StringContent(JsonSerializer.Serialize(task), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_baseAddress, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateTaskAsync(TaskModel task)
    {
        var content = new StringContent(JsonSerializer.Serialize(task), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseAddress}/{task.TaskId}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteTaskAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseAddress}/{id}");
        response.EnsureSuccessStatusCode();
    }
}