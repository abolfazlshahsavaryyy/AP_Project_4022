﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using AP_Project_4022.classes;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace AP_Project_4022.CustomerPage
{
    /// <summary>
    /// Interaction logic for specialServicePage.xaml
    /// </summary>
    public partial class specialServicePage : Window
    {
        public static int check = 0;
        
        
        public specialServicePage()
        {
            InitializeComponent();
        }

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            if(goldenRadioBox.IsChecked == false && silverRadioBox.IsChecked==false && bronzeRadioBox.IsChecked==false)
            {
                MessageBox.Show("choose one!","warrning",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            
            if (goldenRadioBox.IsChecked == true)
            {
                check = 1;
                onlinePaySimiulate ops= new onlinePaySimiulate();
                ops.titleLabel.Content = "Golden  (300 toman) ";
                ops.Show();
            }
            else if( silverRadioBox.IsChecked == true )
            {
                check = 2;
                onlinePaySimiulate ops = new onlinePaySimiulate();
                ops.titleLabel.Content = "silver  (150 toman) ";
                ops.Show();
            }
            else { check = 3;
                onlinePaySimiulate ops = new onlinePaySimiulate();
                ops.titleLabel.Content = "bronze  (100 toman) ";
                ops.Show();
            }

        }
    }
}
