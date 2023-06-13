using System.Net.Http.Json;
using RiskManagementShared.Models;

namespace RiskManagementShared.Services;

public class NormService
{
    private readonly HttpClient _httpClient;

    public NormService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<IEnumerable<Norm>> GetNorms()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/Norms");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<Norm>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<Norm>>();
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

    public async Task<Norm> GetNorm(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/Norms/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Norm>();
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
    public async Task DeleteNorm(int id)
    {
        await _httpClient.DeleteAsync($"api/Norms/{id}");
    }
}
