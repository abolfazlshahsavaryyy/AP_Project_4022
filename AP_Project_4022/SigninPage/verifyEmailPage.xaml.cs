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
    /// Interaction logic for verifyEmailPage.xaml
    /// </summary>
    public partial class verifyEmailPage : Window
    {
        public verifyEmailPage()
        {
            InitializeComponent();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            if(verifyCodeTextBox.Text==singinPage.Verify_code_email.ToString())
            {
                passwordPage pp = new passwordPage(); pp.Show();
                return;
            }
            MessageBox.Show("code not correct!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
    }
}
