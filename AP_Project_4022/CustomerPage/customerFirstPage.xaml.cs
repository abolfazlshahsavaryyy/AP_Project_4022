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
using AP_Project_4022.CustomerPage;
using AP_Project_4022.classes;

namespace AP_Project_4022.CustomerPage
{
    /// <summary>
    /// Interaction logic for customerFirstPage.xaml
    /// </summary>
    public partial class customerFirstPage : Window
    {
        public customerFirstPage()
        {
            InitializeComponent();
        }

        private void profileButton_Click(object sender, RoutedEventArgs e)
        {
            Customer.currentCustomer.profile_page=new profilePage();
            Customer.currentCustomer.profile_page.Show();
        }

        private void searchRestaurantButton_Click(object sender, RoutedEventArgs e)
        {
            Customer.currentCustomer.search_restaurant_page=new searchRestaurantPage();
            Customer.currentCustomer.search_restaurant_page.Show();
        }

        private void orderhistoryButton_Click(object sender, RoutedEventArgs e)
        {
            Customer.currentCustomer.order_history_page=new orderHistoryPage();
            Customer.currentCustomer.order_history_page.Show();
        }

        private void compaintButton_Click(object sender, RoutedEventArgs e)
        {
            Customer.currentCustomer.complaint_page=new complaintPage();
            Customer.currentCustomer.complaint_page.Show();
        }
    }
}
