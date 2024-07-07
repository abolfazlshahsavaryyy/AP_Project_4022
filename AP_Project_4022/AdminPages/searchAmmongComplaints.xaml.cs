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
    /// Interaction logic for searchAmmongComplaints.xaml
    /// </summary>
    public partial class searchAmmongComplaints : Window
    {
        public searchAmmongComplaints()
        {
            InitializeComponent();
            rdbUsername.IsChecked = true;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(rdbUsername.IsChecked == true)
            {
                Admin.CurrentAdmin.show_Search_Complaints = new showSearchComplaints("Username");
                Admin.CurrentAdmin.show_Search_Complaints.Show();
            }
            else if (rdbTitle.IsChecked == true)
            {
                Admin.CurrentAdmin.show_Search_Complaints = new showSearchComplaints("Title");
                Admin.CurrentAdmin.show_Search_Complaints.Show();
            }
            else if (rdbName.IsChecked == true)
            {
                Admin.CurrentAdmin.show_Search_Complaints = new showSearchComplaints("Name");
                Admin.CurrentAdmin.show_Search_Complaints.Show();
            }
            else if (rdbRestaurantName.IsChecked == true)
            {
                Admin.CurrentAdmin.show_Search_Complaints = new showSearchComplaints("Restaurant");
                Admin.CurrentAdmin.show_Search_Complaints.Show();
            }
            else if (rdbStatus.IsChecked == true)
            {
                Admin.CurrentAdmin.show_Search_Complaints = new showSearchComplaints("Status");
                Admin.CurrentAdmin.show_Search_Complaints.Show();
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
