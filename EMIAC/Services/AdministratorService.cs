// Services/AdministratorService.cs
using EMIAC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class AdministratorService
{
    private readonly HttpClient _httpClient;

    public AdministratorService()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7226/") };
    }

    public async Task<List<Administrator>> GetAdministratorsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Administrator>>("api/Administrators");
    }

    public async Task<Administrator> GetAdministratorByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Administrator>($"api/Administrators/{id}");
    }

    public async Task CreateAdministratorAsync(Administrator administrator)
    {
        await _httpClient.PostAsJsonAsync("api/Administrators", administrator);
    }

    public async Task UpdateAdministratorAsync(Administrator administrator)
    {
        await _httpClient.PutAsJsonAsync($"api/Administrators/{administrator.ID_Administrator}", administrator);
    }

    public async Task DeleteAdministratorAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/Administrators/{id}");
    }
}
