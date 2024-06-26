using EMIAC.View.UserInteface;
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
            DoctorsCard first = new DoctorsCard();
            first.TextDesc.Text = "Дежурный врач по ОРВИ";
            first.ImageIcon.Source = new BitmapImage(new Uri("Ychastkovii.png", UriKind.RelativeOrAbsolute));

            DoctorsCard second = new DoctorsCard();
            second.TextDesc.Text = "Вакцинация от COVID 19";
            second.ImageIcon.Source = new BitmapImage(new Uri("Virus.png", UriKind.RelativeOrAbsolute));

            List<DoctorsCard> doctorsCards = new List<DoctorsCard>() { first, second };
            ListboxFirst.ItemsSource = doctorsCards;


            DoctorsCard spes1 = new DoctorsCard();
            spes1.TextDesc.Text = "Участковый";
            spes1.ImageIcon.Source = new BitmapImage(new Uri("Ychastkovii.png", UriKind.RelativeOrAbsolute));

            DoctorsCard spes2 = new DoctorsCard();
            spes2.TextDesc.Text = "Зубной врач";
            spes2.ImageIcon.Source = new BitmapImage(new Uri("Zybnoi.png", UriKind.RelativeOrAbsolute));

            DoctorsCard spes3 = new DoctorsCard();
            spes3.TextDesc.Text = "Стоматолог";
            spes3.ImageIcon.Source = new BitmapImage(new Uri("Ychastkovii.png", UriKind.RelativeOrAbsolute));

            DoctorsCard spes4 = new DoctorsCard();
            spes4.TextDesc.Text = "Офтальмолог";
            spes4.ImageIcon.Source = new BitmapImage(new Uri("Oftal.png", UriKind.RelativeOrAbsolute));

            DoctorsCard spes5 = new DoctorsCard();
            spes5.TextDesc.Text = "Оториноларинголог";
            spes5.ImageIcon.Source = new BitmapImage(new Uri("Otor.png", UriKind.RelativeOrAbsolute));

            DoctorsCard spes6 = new DoctorsCard();
            spes6.TextDesc.Text = "Детский хирург";
            spes6.ImageIcon.Source = new BitmapImage(new Uri("DetXir.png", UriKind.RelativeOrAbsolute));

            DoctorsCard spes7 = new DoctorsCard();
            spes7.TextDesc.Text = "Направления";
            spes7.ImageIcon.Source = new BitmapImage(new Uri("Spravki.png", UriKind.RelativeOrAbsolute));

            DoctorsCard spes8 = new DoctorsCard();
            spes8.TextDesc.Text = "педиатр";
            spes8.ImageIcon.Source = new BitmapImage(new Uri("Pediatr.png", UriKind.RelativeOrAbsolute));

            List<DoctorsCard> specialities = new List<DoctorsCard>() { spes1, spes2, spes3, spes4, spes5, spes6, spes7, spes8 };
            Specialities.ItemsSource = specialities;

            DoctorsCard ap1 = new DoctorsCard();
            spes1.TextDesc.Text = "Вакцинация от гриппа ";
            spes1.ImageIcon.Source = new BitmapImage(new Uri("Ykol.png", UriKind.RelativeOrAbsolute));

            DoctorsCard ap2 = new DoctorsCard();
            spes2.TextDesc.Text = "Острое заболевание";
            spes2.ImageIcon.Source = new BitmapImage(new Uri("Molniya.png", UriKind.RelativeOrAbsolute));

            DoctorsCard ap3 = new DoctorsCard();
            spes3.TextDesc.Text = "Дежурный врач ОРВИ";
            spes3.ImageIcon.Source = new BitmapImage(new Uri("Ychastkovii.png", UriKind.RelativeOrAbsolute));

            DoctorsCard ap4 = new DoctorsCard();
            spes4.TextDesc.Text = "Осмотр по хронике";
            spes4.ImageIcon.Source = new BitmapImage(new Uri("Hronik.png", UriKind.RelativeOrAbsolute));

            DoctorsCard ap5 = new DoctorsCard();
            spes5.TextDesc.Text = "Оформить документы";
            spes5.ImageIcon.Source = new BitmapImage(new Uri("Naprav.png", UriKind.RelativeOrAbsolute));

            DoctorsCard ap6 = new DoctorsCard();
            spes6.TextDesc.Text = " Женская консультация";
            spes6.ImageIcon.Source = new BitmapImage(new Uri("Konsylt.png", UriKind.RelativeOrAbsolute));

            DoctorsCard ap7 = new DoctorsCard();
            spes7.TextDesc.Text = "Запись к стоматологу";
            spes7.ImageIcon.Source = new BitmapImage(new Uri("Zybnoi.png", UriKind.RelativeOrAbsolute));

            DoctorsCard ap8 = new DoctorsCard();
            spes8.TextDesc.Text = "Профилактика";
            spes8.ImageIcon.Source = new BitmapImage(new Uri("ShtykaVrach.png", UriKind.RelativeOrAbsolute));

            List<DoctorsCard> appointments = new List<DoctorsCard>() { ap1, ap2, ap3, ap4, ap5, ap6, ap7, ap8 };
            Appointments.ItemsSource = appointments;


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

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
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
            }
        }
    }
}
