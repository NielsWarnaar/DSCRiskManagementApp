using System.Net.Http.Json;
using RiskManagementShared.Models;

namespace RiskManagementShared.Services;

public class ControlService
{
    private readonly HttpClient _httpClient;

    public ControlService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<IEnumerable<Control>> GetControls()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/Controls");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<Control>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<Control>>();
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

    public async Task<Control> GetControl(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/Controls/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Control>();
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

    public async Task DeleteControl(int id) 
    {
        await _httpClient.DeleteAsync($"api/Controls/{id}");
    }
}
