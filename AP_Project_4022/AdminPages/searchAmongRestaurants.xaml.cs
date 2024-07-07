using AP_Project_4022.classes;
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

namespace AP_Project_4022.AdminPages
{
    /// <summary>
    /// Interaction logic for searchAmongRestaurants.xaml
    /// </summary>
    public partial class searchAmongRestaurants : Window
    {
        public searchAmongRestaurants()
        {
            InitializeComponent();
            rdbCity.IsChecked = true;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(rdbCity.IsChecked == true)
            {
                Admin.CurrentAdmin.show_Serach_Restaurant = new showSerachRestaurant("City");
                Admin.CurrentAdmin.show_Serach_Restaurant.Show();
            }
            else if (rdbName.IsChecked == true)
            {
                Admin.CurrentAdmin.show_Serach_Restaurant = new showSerachRestaurant("Name");
                Admin.CurrentAdmin.show_Serach_Restaurant.Show();
            }
            else if (rdbComplaint.IsChecked == true)
            {
                Admin.CurrentAdmin.show_Serach_Restaurant = new showSerachRestaurant("Complaint");
                Admin.CurrentAdmin.show_Serach_Restaurant.Show();
            }
            else if (rdbMinScore.IsChecked == true)
            {
                Admin.CurrentAdmin.show_Serach_Restaurant = new showSerachRestaurant("MinScore");
                Admin.CurrentAdmin.show_Serach_Restaurant.Show();
            }
            else
            {
                string message = "Please choose one option!";
                string title = "Error";
                System.Windows.MessageBox.Show(message, title);
            }
        }
    }
}
