using System.Net.Http.Json;
using RiskManagementShared.Models;

namespace RiskManagementShared.Services;

public class CategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/Categories");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<Category>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<Category> GetCategory(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/Categories/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Category>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteCategory(int id)
    {
        await _httpClient.DeleteAsync($"api/Categories/{id}");
    }
}
