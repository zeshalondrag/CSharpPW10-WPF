using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

public class PatientViewModel : INotifyPropertyChanged
{
    private readonly PatientService _patientService;
    private Patient _selectedPatient;

    public ObservableCollection<Patient> Patients { get; set; }
    public Patient SelectedPatient
    {
        get => _selectedPatient;
        set
        {
            _selectedPatient = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand DeleteCommand { get; }

    public PatientViewModel()
    {
        _patientService = new PatientService();
        Patients = new ObservableCollection<Patient>();
        AddCommand = new RelayCommand(async _ => await AddPatient());
        UpdateCommand = new RelayCommand(async _ => await UpdatePatient());
        DeleteCommand = new RelayCommand(async _ => await DeletePatient());

        LoadPatients();
    }

    private async void LoadPatients()
    {
        var patients = await _patientService.GetPatientsAsync();
        foreach (var patient in patients)
        {
            Patients.Add(patient);
        }
    }

    private async Task AddPatient()
    {
        await _patientService.CreatePatientAsync(SelectedPatient);
        LoadPatients();
    }

    private async Task UpdatePatient()
    {
        await _patientService.UpdatePatientAsync(SelectedPatient);
        LoadPatients();
    }

    private async Task DeletePatient()
    {
        await _patientService.DeletePatientAsync(SelectedPatient.ID_Patient);
        LoadPatients();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
