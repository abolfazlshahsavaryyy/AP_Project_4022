﻿using AP_Project_4022.classes;
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
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace AP_Project_4022.CustomerPage
{
    /// <summary>
    /// Interaction logic for orderPageRestaurant.xaml
    /// </summary>
    public partial class orderPageRestaurant : Window
    {
        public static double price;
        public orderPageRestaurant()
        {
            InitializeComponent();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {

            int number_food=0;
            try
            {
                number_food = int.Parse(numberFoodTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                numberFoodTextBox.Text = string.Empty;
                return;
            }
            if (foodPage.current_food.numberFood < number_food)
            {
                MessageBox.Show("to much food");
                return;
            }
            price=number_food*foodPage.current_food.price;
            foodPage.current_food.numberFood -= number_food;
            payPage pp=new payPage();
            OrderHistory oh = new OrderHistory(Customer.currentCustomer, restaurantMenuPage.Restaurant_Menu,foodPage.current_food);
            oh.food = foodPage.current_food;
            OrderHistory.allOrderHistory.Add(oh);
            pp.Show();
            this.Close();
        }
    }
}
