﻿using System;
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
    /// Логика взаимодействия для AuthSotrWindow.xaml
    /// </summary>
    public partial class AuthSotrWindow : Window
    {
        public AuthSotrWindow()
        {
            InitializeComponent();
        }

        private void Auth_Client(object sender, RoutedEventArgs e)
        {
            AuthWindow authclient = new AuthWindow();
            authclient.Show();
            this.Close();
        }
    }
}
