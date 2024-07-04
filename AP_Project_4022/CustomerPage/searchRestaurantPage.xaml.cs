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

namespace AP_Project_4022.CustomerPage
{
    /// <summary>
    /// Interaction logic for searchRestaurantPage.xaml
    /// </summary>
    public partial class searchRestaurantPage : Window
    {
        public searchRestaurantPage()
        {
            InitializeComponent();
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void restaurantButton_Click(object sender, RoutedEventArgs e)
        {
            restaurantMenuPage rmp =new restaurantMenuPage();
            rmp.Show();
        }
    }
}
