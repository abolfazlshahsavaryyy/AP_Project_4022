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
    /// Interaction logic for showSerachRestaurant.xaml
    /// </summary>
    public partial class showSerachRestaurant : Window
    {
        public showSerachRestaurant(string searchBy)
        {
            InitializeComponent();
            tbTitle.Text = "Search Restaurants by " + searchBy;
            tbHint.Text = "Enter " + searchBy;
            if(searchBy == "Complaint")
                stcSearchBar.Visibility = Visibility.Hidden;   
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
