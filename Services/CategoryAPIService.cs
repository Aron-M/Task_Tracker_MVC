// Services/CategoryAPIService.cs
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using TaskTrackerMVC.Models;
using System.Text;

public class CategoryAPIService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseAddress;

    public CategoryAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _baseAddress = "http://localhost:5000/api/categories"; // Replace with your API's base URL
    }

    public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
    {
        var response = await _httpClient.GetAsync(_baseAddress);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<CategoryModel>>(content);
    }

    public async Task<CategoryModel> GetCategoryByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<CategoryModel>(content);
    }

    public async Task CreateCategoryAsync(CategoryModel category)
    {
        var content = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_baseAddress, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateCategoryAsync(CategoryModel category)
    {
        var content = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseAddress}/{category.CategoryId}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseAddress}/{id}");
        response.EnsureSuccessStatusCode();
    }
}