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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace EMIAC.View
{
    /// <summary>
    /// Логика взаимодействия для MainUserWindow.xaml
    /// </summary>
    public partial class MainUserWindow : Window
    {
        public MainUserWindow()
        {
            InitializeComponent();
            MainDobavCard card = new MainDobavCard();
            MainDobavCard card1 = new MainDobavCard();
            MainDobavCard card2 = new MainDobavCard();
            MainDobavCard card3 = new MainDobavCard();
            MainDobavCard card4 = new MainDobavCard();
            MainDobavCard card5 = new MainDobavCard();
            DobavAktiv.Items.Add(card);
            DobavAktiv.Items.Add(card1);
            DobavAktiv1.Items.Add(card2);
            DobavArxiv.Items.Add(card3);
            DobavArxiv.Items.Add(card4);
            DobavArxiv1.Items.Add(card5);
            this.WindowState = WindowState.Maximized;
        }

        private void SettingsClient(object sender, RoutedEventArgs e)
        {
            SettingsUserWindow settingsWindow = new SettingsUserWindow();
            settingsWindow.Show();
            this.Close();
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

        private void ZapisiOpen(object sender, MouseButtonEventArgs e)
        {
            ZapisiUserWindow zapisiUserWindow = new ZapisiUserWindow();
            zapisiUserWindow.Show();
            this.Close();
        }

        private void TreeViewPerexod(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeViewItem selectedItem)
            {
                string header = selectedItem.Header.ToString();

                if (header == "Записи и направления")
                {
                    ZapisiUserWindow zapisiUserWindow = new ZapisiUserWindow();
                    zapisiUserWindow.Show();
                    this.Close();
                }
                else if (header == "Файл 2")
                {
                }
            }
        }

        private void Zapisi(object sender, RoutedEventArgs e)
        {
            ZapisiUserWindow zapisiUserWindow = new ZapisiUserWindow();
            zapisiUserWindow.Show();
            this.Close();
        }
    }
}
