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
    /// Логика взаимодействия для ZapisiUserWindow.xaml
    /// </summary>
    public partial class ZapisiUserWindow : Window
    {
        public ZapisiUserWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void SettingsClient(object sender, RoutedEventArgs e)
        {
            SettingsUserWindow settingsWindow = new SettingsUserWindow();
            settingsWindow.Show();
            this.Close();
        }

        private void OpenMainUserWindow(object sender, MouseButtonEventArgs e)
        {
            MainUserWindow mainUserWindow = new MainUserWindow();
            mainUserWindow.Show();
            this.Close();
        }
    }
}
