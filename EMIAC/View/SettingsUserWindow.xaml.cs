using EMIAC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using EMIAC.ViewModel;
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
            DataContext = new PatientViewModelSettings();
            this.WindowState = WindowState.Maximized;
        }

        

        private void PerexodTreeView(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeViewItem selectedItem)
            {
                string header = selectedItem.Header.ToString();

                if (header == "Главная")
                {
                    MainUserWindow mainUserWindow = new MainUserWindow();
                    mainUserWindow.Show();
                    this.Close();
                }
                else if (header == "Записи и направления")
                {
                    ZapisiUserWindow userWindow = new ZapisiUserWindow();
                    userWindow.Show();
                    this.Close();
                }
                // ... и так далее для других элементов TreeView
            }
        }
    }
}
