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
using System.Windows.Shapes;

namespace AP_Project_4022.SigninPage
{
    /// <summary>
    /// Interaction logic for singinPage.xaml
    /// </summary>
    public partial class singinPage : Window
    {
        public singinPage()
        {
            InitializeComponent();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            verifyEmailPage verifyEmailPage = new verifyEmailPage();verifyEmailPage.Show();
        }
    }
}
