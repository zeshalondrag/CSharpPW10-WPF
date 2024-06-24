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
        private Point _mouseDownPosition;
        private bool _isMouseDown;

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.ChangedButton == MouseButton.Left)
            {
                _isMouseDown = true;
                _mouseDownPosition = e.GetPosition(this);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_isMouseDown)
            {
                Point currentPosition = e.GetPosition(this);
                this.Left += currentPosition.X - _mouseDownPosition.X;
                this.Top += currentPosition.Y - _mouseDownPosition.Y;
            }
        }

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
    }
}
