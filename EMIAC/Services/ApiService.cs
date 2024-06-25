using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7226/api/") };
    }

    public async Task<List<Appointment>> GetAppointmentsByDoctorAndDate(int doctorId, DateTime date)
    {
        var response = await _httpClient.GetAsync($"Appointments?doctorId={doctorId}&date={date:yyyy-MM-dd}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<List<Appointment>>();
    }

    public async Task<Patient> GetPatientById(int patientId)
    {
        var response = await _httpClient.GetAsync($"Patients/{patientId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<Patient>();
    }

    public async Task<Doctor> GetDoctorById(int doctorId)
    {
        var response = await _httpClient.GetAsync($"Doctors/{doctorId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<Doctor>();
    }

    public async Task<List<Status>> GetStatuses()
    {
        var response = await _httpClient.GetAsync("Statuses");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<List<Status>>();
    }

    public async Task UpdateAppointmentStatus(int appointmentId, int statusId)
    {
        var response = await _httpClient.PutAsJsonAsync($"Appointments/{appointmentId}", new { Statuses_ID = statusId });
        response.EnsureSuccessStatusCode();
    }

    public async Task AddAppointmentDocument(int appointmentId, string content)
    {
        var response = await _httpClient.PostAsJsonAsync("AppointmentDocuments", new { ID_Appointments = appointmentId, ContentAppointmentRTF = content });
        response.EnsureSuccessStatusCode();
    }
}
