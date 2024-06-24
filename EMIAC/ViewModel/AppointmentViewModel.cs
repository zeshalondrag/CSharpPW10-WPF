using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public class AppointmentViewModel : INotifyPropertyChanged
{
    private string _status;
    private string _appointmentStatus;
    private string _content;

    public Appointment Appointment { get; set; }
    public Patient Patient { get; set; }
    public string Status
    {
        get => _status;
        set
        {
            _status = value;
            OnPropertyChanged();
        }
    }
    public string AppointmentStatus
    {
        get => _appointmentStatus;
        set
        {
            _appointmentStatus = value;
            OnPropertyChanged();
        }
    }
    public string Content
    {
        get => _content;
        set
        {
            _content = value;
            OnPropertyChanged();
        }
    }

    public ICommand StartAppointmentCommand { get; set; }
    public ICommand CancelAppointmentCommand { get; set; }
    public ICommand CompleteAppointmentCommand { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}