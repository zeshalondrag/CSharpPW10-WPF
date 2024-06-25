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
        private readonly PatientService _patientService;
        private string _patientName;
        private string _patientEmail;
        private string _patientphonenumber;
        private int _patientId;
        private string _patientadress;
        private string _patientlivingadress;
        private string _patientpolicenumber;
        private DateTime _patientdateofbirth;



        public PatientViewModelSettings()
        {
            _patientService = new PatientService();
            InitializePatient();
            savechanges = new BindableCommand(_ => SaveChanges());
            exitfromAccount = new BindableCommand(_ => ExitfromAccount());
        }

        public BindableCommand savechanges { get; set; }
        public BindableCommand exitfromAccount { get; set; }


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

        public string PatientPolicyNumber
        {
            get => _patientpolicenumber;
            set
            {
                _patientpolicenumber = value;
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



        private async void InitializePatient()
        {
            var patient = await _patientService.GetPatientByIdAsync(_patientId);

            PatientName = $" {patient.Name} {patient.Surname} {patient.MiddleName}";
            PatientPolicyNumber = patient.PolicyNumber;
            PatientDateOfBirth = patient.BirthDate;
        }

        private async Task SaveChanges()
        {
            await _patientService.UpdatePatient(_patientId, PatientPhoneNumber, PatientEmail, PatientAdress, PatientLivingAdress);

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