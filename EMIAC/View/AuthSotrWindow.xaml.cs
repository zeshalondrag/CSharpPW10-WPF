using System.Windows;
using System.Windows.Controls;
using EMIAC.ViewModels;

namespace EMIAC.View
{
    public partial class AuthSotrWindow : Window
    {
        public AuthSotrWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is AuthViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AuthViewModel viewModel)
            {
                await viewModel.LoginAsync();
            }
        }
<<<<<<< HEAD

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.ChangedButton == MouseButton.Left)
            {
                _isMouseDown = false;
            }
        }

        private void VxodDlyaVrach(object sender, RoutedEventArgs e)
        {
            DoctorWindow authvrach = new DoctorWindow();
            authvrach.Show();
            this.Close();
        }
=======
>>>>>>> Admin
    }
}
