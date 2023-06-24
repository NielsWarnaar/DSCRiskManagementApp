using System.Net.Http.Json;
using RiskManagementAppSharedUI.Models;

namespace RiskManagementAppSharedUI.Services;

public class RiskHistoryService
{
    private readonly HttpClient _httpClient;

    public RiskHistoryService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<IEnumerable<RiskHistory>> GetRiskHistories()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/RiskHistories");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<RiskHistory>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<RiskHistory>>();
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

    public async Task<RiskHistory> GetRiskHistory(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/RiskHistories/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<RiskHistory>();
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

    public async Task<IEnumerable<RiskHistory>> GetRiskHistoryByRiskId(int riskId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/RiskHistories/Risks/{riskId}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<RiskHistory>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<RiskHistory>>();
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
