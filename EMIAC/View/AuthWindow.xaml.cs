using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EMIAC.ViewModel;

namespace EMIAC.View
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            DataContext = new AuthViewModel();
        }

        private void Auth_For_Sotrudnik(object sender, RoutedEventArgs e)
        {
            AuthSotrWindow authsotr = new AuthSotrWindow();
            authsotr.Show();
            this.Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Svernyt(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void FullEkran(object sender, RoutedEventArgs e)
        {
            //if (this.WindowState == WindowState.Maximized)
            //{
            //    this.WindowState = WindowState.Normal;
            //}
            //else
            //{
            //    this.WindowState = WindowState.Maximized;
            //}
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

        private void Enter_User(object sender, RoutedEventArgs e)
        {
            MainUserWindow mainUserWindow = new MainUserWindow();
            mainUserWindow.Show();
            this.Close();
        }
    }
}