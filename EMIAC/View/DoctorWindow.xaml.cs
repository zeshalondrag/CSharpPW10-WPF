﻿using EMIAC.View.UserInteface.Doctor;
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
    /// Логика взаимодействия для DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public DoctorWindow()
        {
            InitializeComponent();
            ZavershenieZapisi zavershenieZapisi = new ZavershenieZapisi();
            VrenyaZapisiProshlo vrenyaZapisiProshlo = new VrenyaZapisiProshlo();
            VrenyaZapisiProshlo vrenyaZapisiProshlo1 = new VrenyaZapisiProshlo();
            VrenyaZapisiProshlo vrenyaZapisiProshlo2 = new VrenyaZapisiProshlo();
            VrenyaZapisiProshlo vrenyaZapisiProshlo3 = new VrenyaZapisiProshlo();
            AktivnayaZapis aktivnayaZapis = new AktivnayaZapis();
            AktivnayaZapis aktivnayaZapis1 = new AktivnayaZapis();
            AktivnayaZapis aktivnayaZapis2 = new AktivnayaZapis();
            AktivnayaZapis aktivnayaZapis3 = new AktivnayaZapis();
            Zapisi.Items.Add(zavershenieZapisi);
            Zapisi.Items.Add(vrenyaZapisiProshlo);
            Zapisi.Items.Add(vrenyaZapisiProshlo1);
            Zapisi.Items.Add(vrenyaZapisiProshlo2);
            Zapisi.Items.Add(vrenyaZapisiProshlo3);
            Zapisi.Items.Add(aktivnayaZapis);
            Zapisi.Items.Add(aktivnayaZapis1);
            Zapisi.Items.Add(aktivnayaZapis2);
            Zapisi.Items.Add(aktivnayaZapis3);
            this.WindowState = WindowState.Maximized;
            Napravlenie napravlenie = new Napravlenie();
            NapravlenieList.Items.Add(napravlenie);
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

        private void GoAuth(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
