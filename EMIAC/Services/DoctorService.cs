using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class DoctorService
{
    private readonly HttpClient _httpClient;

    public DoctorService()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7226/") };
    }

    public async Task<List<Doctor>> GetDoctorsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Doctor>>("api/Doctors");
    }

    public async Task<Doctor> GetDoctorByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Doctor>($"api/Doctors/{id}");
    }

    public async Task CreateDoctorAsync(Doctor doctor)
    {
        await _httpClient.PostAsJsonAsync("api/Doctors", doctor);
    }

    public async Task UpdateDoctorAsync(Doctor doctor)
    {
        await _httpClient.PutAsJsonAsync($"api/Doctors/{doctor.ID_Doctor}", doctor);
    }

    public async Task DeleteDoctorAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/Doctors/{id}");
    }
}