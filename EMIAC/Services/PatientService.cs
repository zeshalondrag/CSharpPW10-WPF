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

    public async Task<Patient> GetPatientById(int patientId)
    {
        var response = await _httpClient.GetAsync($"Patients/{patientId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<Patient>();
    }

    public async Task UpdatePatient(int patientId, string patientPhoneNumber, string patientEmail, string patientAdress, string patientLivingAddress)
    {
        var response = await _httpClient.PutAsJsonAsync($"Patients/{patientId}", new { PatientPhoneNumber = patientPhoneNumber, PatientEmail = patientEmail, PatientAddress = patientAdress, PatientLivingAddress = patientLivingAddress });
        response.EnsureSuccessStatusCode();
    }

    public async Task<Patient> GetPatientByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Patient>($"api/Patients/{id}");
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