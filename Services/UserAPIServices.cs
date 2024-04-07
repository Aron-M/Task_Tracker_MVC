// Services/UserAPIService.cs
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using TaskTrackerMVC.Models;
using System.Text;

public class UserAPIService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseAddress;

    public UserAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _baseAddress = "http://localhost:5000/api/users"; // Replace with your API's base URL
    }

    public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
    {
        var response = await _httpClient.GetAsync(_baseAddress);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<UserModel>>(content);
    }

    public async Task<UserModel> GetUserByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<UserModel>(content);
    }

    public async Task CreateUserAsync(UserModel user)
    {
        var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_baseAddress, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateUserAsync(UserModel user)
    {
        var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseAddress}/{user.UserId}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteUserAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseAddress}/{id}");
        response.EnsureSuccessStatusCode();
    }
}