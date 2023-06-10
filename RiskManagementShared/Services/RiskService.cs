using System.Net.Http.Json;
using RiskManagementShared.Models;

namespace RiskManagementShared.Services;

public class RiskService
{
    private readonly HttpClient _httpClient;

    public RiskService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<IEnumerable<Risk>> GetRisks()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/Risks");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<Risk>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<Risk>>();
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
    public async Task<Risk> GetRisk(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/risk/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Risk>();
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
}