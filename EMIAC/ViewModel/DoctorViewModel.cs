using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

public class DoctorViewModel : INotifyPropertyChanged
{
    private readonly DoctorService _doctorService;
    private Doctor _selectedDoctor;

    public ObservableCollection<Doctor> Doctors { get; set; }
    public Doctor SelectedDoctor
    {
        get => _selectedDoctor;
        set
        {
            _selectedDoctor = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand DeleteCommand { get; }

    public DoctorViewModel()
    {
        _doctorService = new DoctorService();
        Doctors = new ObservableCollection<Doctor>();
        AddCommand = new RelayCommand(async _ => await AddDoctor());
        UpdateCommand = new RelayCommand(async _ => await UpdateDoctor());
        DeleteCommand = new RelayCommand(async _ => await DeleteDoctor());

        LoadDoctors();
    }

    private async void LoadDoctors()
    {
        var doctors = await _doctorService.GetDoctorsAsync();
        foreach (var doctor in doctors)
        {
            Doctors.Add(doctor);
        }
    }

    private async Task AddDoctor()
    {
        await _doctorService.CreateDoctorAsync(SelectedDoctor);
        LoadDoctors();
    }

    private async Task UpdateDoctor()
    {
        await _doctorService.UpdateDoctorAsync(SelectedDoctor);
        LoadDoctors();
    }

    private async Task DeleteDoctor()
    {
        await _doctorService.DeleteDoctorAsync(SelectedDoctor.ID_Doctor);
        LoadDoctors();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}