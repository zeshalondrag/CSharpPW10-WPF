using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace EMIAC.View
{
    /// <summary>
    /// Логика взаимодействия для AdminCRUDPatient.xaml
    /// </summary>
    public partial class AdminCRUDPatient : Window
    {
        List<string> list = new List<string> { "Пользователь", "Врач", "Администратор" };//это окно должно открываться первым (дефолтное)
        public AdminCRUDPatient()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            ComboPerexodAdmin.ItemsSource = list;
        }

        private void PerexodAdmina(object sender, SelectionChangedEventArgs e)
        {
            if (ComboPerexodAdmin.SelectedItem == list[0])
            {
                AdminCRUDPatient patientWindow = new AdminCRUDPatient();
                patientWindow.Show();
                Close();
            }
            if (ComboPerexodAdmin.SelectedItem == list[1])
            {
                AdminCRUDVrach doctorWindow = new AdminCRUDVrach();
                doctorWindow.Show();
                Close();
            }
            if (ComboPerexodAdmin.SelectedItem == list[2])
            {
                AdminCRUDAdmin adminWindow = new AdminCRUDAdmin();
                adminWindow.Show();
                Close();
            }
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void Svernyt(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ExitToAuthWindow(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
