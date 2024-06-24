using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class PatientService
{
    private readonly HttpClient _httpClient;

    public PatientService()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7226/") };
    }

    public async Task<List<Patient>> GetPatientsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Patient>>("api/Patients");
    }

    public async Task<Patient> GetPatientByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Patient>($"api/Patients/{id}");
    }

    public async Task CreatePatientAsync(Patient patient)
    {
        await _httpClient.PostAsJsonAsync("api/Patients", patient);
    }

    public async Task UpdatePatientAsync(Patient patient)
    {
        await _httpClient.PutAsJsonAsync($"api/Patients/{patient.ID_Patient}", patient);
    }

    public async Task DeletePatientAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/Patients/{id}");
    }
}