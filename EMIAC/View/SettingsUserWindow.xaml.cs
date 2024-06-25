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
    /// Логика взаимодействия для SettingsUserWindow.xaml
    /// </summary>
    public partial class SettingsUserWindow : Window
    {
        public SettingsUserWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void GoToMainUserWindow(object sender, MouseButtonEventArgs e)
        {
            MainUserWindow mainUserWindow = new MainUserWindow();
            mainUserWindow.Show();
            this.Close();
        }

        private void GoToZapisiWindow(object sender, MouseButtonEventArgs e)
        {
            ZapisiUserWindow zapisiUserWindow = new ZapisiUserWindow();
            zapisiUserWindow.Show();
            this.Close();
        }
    }
}
