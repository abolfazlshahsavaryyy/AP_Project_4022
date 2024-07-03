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

namespace AP_Project_4022.RestaurantPages
{
    /// <summary>
    /// Interaction logic for RestaurantPanel.xaml
    /// </summary>
    public partial class RestaurantPanel : Window
    {
        public RestaurantPanel()
        {
            InitializeComponent();
        }

        private void btnChangeMenu_Click(object sender, RoutedEventArgs e)
        {
            btnActiveService.Visibility = Visibility.Hidden;
            btnChangeMenu.Visibility = Visibility.Hidden;
            btnChangeStock.Visibility = Visibility.Hidden; 
            btnHistory.Visibility = Visibility.Hidden;
            stcChoose.Visibility = Visibility.Visible;
        }

        private void btnChangeStock_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActiveService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
