using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using calculator.ViewModel.Helpers;
using EMIAC.ViewModel.Helpers;
using EMIAC.View;
using System.Windows;
using EMIAC.Models;

namespace EMIAC.ViewModel
{
    internal class PatientViewModelSettings : BindingHelper
    {
        private readonly ApiService _apiService;
        private string _patientName;
        private string _patientEmail;
        private string _patientphonenumber;
        private int _patientId;
        private string _patientadress;
        private string _patientlivingadress;
        private long _patientoms;
        private DateTime _patientdateofbirth;

        public PatientViewModelSettings(int patientId)
        {
            _apiService = new ApiService();
            _patientId = patientId;
            InitializePatient();
        }


        public string PatientName
        {
            get => _patientName;
            set
            {
                _patientEmail = value;
                OnPropertyChanged();
            }
        }

        public string PatientEmail
        {
            get => _patientEmail;
            set
            {
                _patientEmail = value;
                OnPropertyChanged();
            }
        }

        public string PatientPhoneNumber
        {
            get => _patientphonenumber;
            set
            {
                _patientphonenumber = value;
                OnPropertyChanged();
            }
        }

        public string PatientAdress
        {
            get => _patientadress;
            set
            {
                _patientphonenumber = value;
                OnPropertyChanged();
            }
        }

        public string PatientLivingAdress
        {
            get => _patientlivingadress;
            set
            {
                _patientlivingadress = value;
                OnPropertyChanged();
            }
        }

        public long PatientOms
        {
            get => _patientoms;
            set
            {
                _patientoms = value;
                OnPropertyChanged();
            }
        }

        public DateTime PatientDateOfBirth
        {
            get => _patientdateofbirth;
            set
            {
                _patientdateofbirth = value;
                OnPropertyChanged();
            }
        }

        public BindableCommand AddCommand { get; set; }


        private async void InitializePatient()
        {
            var patient = await _apiService.GetPatientById(_patientId);

            PatientName = $" {patient.PatientName} {patient.PatientSurname} {patient.PatientNickName}";
            PatientOms = patient.OMS;
            PatientDateOfBirth = patient.PatientBirthDate;
        }

        private async Task SaveChanges()
        {
            await _apiService.UpdatePatient(_patientId, PatientPhoneNumber, PatientEmail, PatientAdress, PatientLivingAdress);

        }

        private void ExitfromAccount()
        {
            AuthWindow authclient = new AuthWindow();
            Application.Current.MainWindow.Close();
            authclient.Show();

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}