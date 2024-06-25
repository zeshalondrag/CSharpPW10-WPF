using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

public class DoctorViewModel : INotifyPropertyChanged
{
    private readonly ApiService _apiService;
    private DateTime _selectedDate;
    private string _doctorName;
    private int _doctorId;

    public DoctorViewModel(int doctorId)
    {
        _apiService = new ApiService();
        _doctorId = doctorId;
        Appointments = new ObservableCollection<AppointmentViewModel>();
        LoadAppointmentsCommand = new RelayCommand(async () => await LoadAppointments());
        StartAppointmentCommand = new RelayCommandParam<AppointmentViewModel>(async (a) => await StartAppointment(a));
        CancelAppointmentCommand = new RelayCommandParam<AppointmentViewModel>(async (a) => await CancelAppointment(a));
        CompleteAppointmentCommand = new RelayCommandParam<AppointmentViewModel>(async (a) => await CompleteAppointment(a));
        SelectedDate = DateTime.Today;  
        InitializeDoctor(); 
    }

    public ObservableCollection<AppointmentViewModel> Appointments { get; }

    public ICommand LoadAppointmentsCommand { get; }
    public ICommand StartAppointmentCommand { get; }
    public ICommand CancelAppointmentCommand { get; }
    public ICommand CompleteAppointmentCommand { get; }

    public DateTime SelectedDate
    {
        get => _selectedDate;
        set
        {
            if (_selectedDate != value)
            {
                _selectedDate = value;
                OnPropertyChanged();
                LoadAppointmentsCommand.Execute(null);
            }
        }
    }

    public string DoctorName
    {
        get => _doctorName;
        set
        {
            _doctorName = value;
            OnPropertyChanged();
        }
    }

    private async void InitializeDoctor()
    {
        var doctor = await _apiService.GetDoctorById(_doctorId);
        DoctorName = $"{doctor.Surname} {doctor.Name} {doctor.MiddleName}";
    }

    private async Task LoadAppointments()
    {
        var appointments = await _apiService.GetAppointmentsByDoctorAndDate(_doctorId, SelectedDate);
        Appointments.Clear();
        foreach (var appointment in appointments)
        {
            var patient = await _apiService.GetPatientById(appointment.Patient_ID.Value);
            var appointmentViewModel = new AppointmentViewModel
            {
                Appointment = appointment,
                Patient = patient,
                StartAppointmentCommand = StartAppointmentCommand,
                CancelAppointmentCommand = CancelAppointmentCommand,
                CompleteAppointmentCommand = CompleteAppointmentCommand,
                Status = appointment.Statuses_ID == 4 ? "Запись завершена" : string.Empty // Пример статуса
            };
            Appointments.Add(appointmentViewModel);
        }
    }

    private async Task StartAppointment(AppointmentViewModel appointmentViewModel)
    {
        await _apiService.UpdateAppointmentStatus(appointmentViewModel.Appointment.ID_Appointments, 2); // 2 = Прием начат
        appointmentViewModel.Status = "Прием начат";
    }

    private async Task CancelAppointment(AppointmentViewModel appointmentViewModel)
    {
        await _apiService.UpdateAppointmentStatus(appointmentViewModel.Appointment.ID_Appointments, 3); // 3 = Отменено
        appointmentViewModel.Status = "Отменено";
    }

    private async Task CompleteAppointment(AppointmentViewModel appointmentViewModel)
    {
        await _apiService.AddAppointmentDocument(appointmentViewModel.Appointment.ID_Appointments, appointmentViewModel.Content);
        await _apiService.UpdateAppointmentStatus(appointmentViewModel.Appointment.ID_Appointments, 4); // 4 = Завершено
        appointmentViewModel.Status = "Завершено";
        appointmentViewModel.Status = "Запись завершена";
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}