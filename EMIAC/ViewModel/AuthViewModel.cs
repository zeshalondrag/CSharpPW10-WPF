using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using EMIAC.Models;

namespace EMIAC.ViewModels
{
    public class AuthViewModel : INotifyPropertyChanged
    {
        private string _employeeNumber;
        private string _password;
        private readonly ApiService _apiService;

        public string EmployeeNumber
        {
            get => _employeeNumber;
            set { _employeeNumber = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public AuthViewModel()
        {
            _apiService = new ApiService();
        }

        public async Task<bool> LoginAsync()
        {
            var admin = await _apiService.GetAdministratorAsync(EmployeeNumber, Password);
            if (admin != null)
            {
                MessageBox.Show("Вход выполнен как Администратор");
                return true;
            }

            var doctor = await _apiService.GetDoctorAsync(EmployeeNumber, Password);
            if (doctor != null)
            {
                MessageBox.Show("Вход выполнен как Врач");
                return true;
            }

            MessageBox.Show("Неверные учетные данные");
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
