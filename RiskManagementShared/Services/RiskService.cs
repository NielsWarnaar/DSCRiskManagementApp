﻿using System.Net.Http.Json;
using RiskManagementAppSharedUI.Models;

namespace RiskManagementAppSharedUI.Services;

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
            var response = await _httpClient.GetAsync($"api/Risks/{id}");

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

    public async Task<IEnumerable<Risk>> GetRiskByCategoryId(int categoryId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/Risks/Categories/{categoryId}");

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

    public async Task DeleteRisk(int id)
    {
        await _httpClient.DeleteAsync($"api/Risks/{id}");
    }
}