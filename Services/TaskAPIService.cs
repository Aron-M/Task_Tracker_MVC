// Services/TaskAPIService.cs
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

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
        return JsonConvert.DeserializeObject<IEnumerable<TaskModel>>(content);
    }

    // Add methods for POST, PUT, DELETE, etc.
}