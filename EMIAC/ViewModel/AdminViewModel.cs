using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

public class AdminViewModel : INotifyPropertyChanged
{
    private readonly AdministratorService _administratorService;
    private Administrator _selectedAdministrator;

    public ObservableCollection<Administrator> Administrators { get; set; }
    public Administrator SelectedAdministrator
    {
        get => _selectedAdministrator;
        set
        {
            _selectedAdministrator = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand DeleteCommand { get; }

    public AdminViewModel()
    {
        _administratorService = new AdministratorService();
        Administrators = new ObservableCollection<Administrator>();
        AddCommand = new RelayCommand(async _ => await AddAdministrator());
        UpdateCommand = new RelayCommand(async _ => await UpdateAdministrator());
        DeleteCommand = new RelayCommand(async _ => await DeleteAdministrator());

        LoadAdministrators();
    }

    private async void LoadAdministrators()
    {
        var admins = await _administratorService.GetAdministratorsAsync();
        foreach (var admin in admins)
        {
            Administrators.Add(admin);
        }
    }

    private async Task AddAdministrator()
    {
        await _administratorService.CreateAdministratorAsync(SelectedAdministrator);
        LoadAdministrators();
    }

    private async Task UpdateAdministrator()
    {
        await _administratorService.UpdateAdministratorAsync(SelectedAdministrator);
        LoadAdministrators();
    }

    private async Task DeleteAdministrator()
    {
        await _administratorService.DeleteAdministratorAsync(SelectedAdministrator.ID_Administrator);
        LoadAdministrators();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}