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

namespace EMIAC.View
{
    /// <summary>
    /// Логика взаимодействия для AdminCRUDVrach.xaml
    /// </summary>
    public partial class AdminCRUDVrach : Window
    {
        List<string> list = new List<string> { "Пользователь", "Врач", "Администратор" };
        public AdminCRUDVrach()
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
    }
}
