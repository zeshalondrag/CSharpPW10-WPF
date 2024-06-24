using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMIAC.Models
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7226") };
        }

        public async Task<Administrator> GetAdministratorAsync(string id, string password)
        {
            var response = await _httpClient.GetAsync($"/api/Administrators/{id}");
            if (response.IsSuccessStatusCode)
            {
                var admin = await response.Content.ReadAsAsync<Administrator>();
                if (admin != null && admin.adminEnterPassword == password)
                {
                    return admin;
                }
            }
            return null;
        }

        public async Task<Doctor> GetDoctorAsync(string id, string password)
        {
            var response = await _httpClient.GetAsync($"/api/Doctors/{id}");
            if (response.IsSuccessStatusCode)
            {
                var doctor = await response.Content.ReadAsAsync<Doctor>();
                if (doctor != null && doctor.doctorEnterPassword == password)
                {
                    return doctor;
                }
            }
            return null;
        }
    }

    public class Administrator
    {
        public int idAdministrator { get; set; }
        public string adminSurname { get; set; }
        public string adminName { get; set; }
        public string adminMiddleName { get; set; }
        public string adminEnterPassword { get; set; }
    }

    public class Doctor
    {
        public int idDoctor { get; set; }
        public string doctorSurname { get; set; }
        public string doctorName { get; set; }
        public string doctorMiddleName { get; set; }
        public int specialityId { get; set; }
        public string doctorEnterPassword { get; set; }
        public string workAddress { get; set; }
    }
}
