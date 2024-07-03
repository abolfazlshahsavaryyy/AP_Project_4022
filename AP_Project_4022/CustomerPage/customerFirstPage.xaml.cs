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
            profilePage profilePage = new profilePage();profilePage.Show();
        }

        private void searchRestaurantButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void orderhistoryButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void compaintButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
