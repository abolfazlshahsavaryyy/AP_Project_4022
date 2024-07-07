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
    /// Interaction logic for adminMenu.xaml
    /// </summary>
    public partial class adminMenu : Window
    {
        public adminMenu()
        {
            InitializeComponent();
        }

        private void btnAddRestaurant_Click(object sender, RoutedEventArgs e)
        {
            AdminPages.adminMenu adminMenu = new AdminPages.adminMenu();
            classes.Admin.CurrentAdmin.admin_Menu = adminMenu;
            classes.Admin.CurrentAdmin.AddRestaurant = new Window1();
            classes.Admin.CurrentAdmin.AddRestaurant.Show();
        }

        private void btnSearchRestaurant_Click(object sender, RoutedEventArgs e)
        {
            classes.Admin.CurrentAdmin.search_Among_Restaurants = new searchAmongRestaurants();
            classes.Admin.CurrentAdmin.search_Among_Restaurants.Show();
        }

        private void btnSearchComplaint_Click(object sender, RoutedEventArgs e)
        {
            classes.Admin.CurrentAdmin.search_Ammong_Complaints = new searchAmmongComplaints();
            classes.Admin.CurrentAdmin.search_Ammong_Complaints.Show();
        }

        private void btnShowUncheckedComplaints_Click(object sender, RoutedEventArgs e)
        {
            classes.Admin.CurrentAdmin.show_Un_checked_Complaints = new showUncheckedComplaints();
            classes.Admin.CurrentAdmin.show_Un_checked_Complaints.Show();
        }

        private void btnAnswerComplaints_Click(object sender, RoutedEventArgs e)
        {
            classes.Admin.CurrentAdmin.Check_Complaint = new CheckComplaint();
            classes.Admin.CurrentAdmin.Check_Complaint.Show();
        }

        private void btnShowAllComplaints_Click(object sender, RoutedEventArgs e)
        {
            classes.Admin.CurrentAdmin.show_All_Complaints = new showAllComplaints();
            classes.Admin.CurrentAdmin.show_All_Complaints.Show();
        }
    }
}
