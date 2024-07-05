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

namespace AP_Project_4022.CustomerPage
{
    /// <summary>
    /// Interaction logic for reservePage.xaml
    /// </summary>
    public partial class reservePage : Window
    {
        public static int table_want = -1;
        public reservePage()
        {
            InitializeComponent();
        }

        private void reserveButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                table_want = int.Parse(numTabelTextBox.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if(table_want > restaurantMenuPage.Restaurant_Menu.numberTable)
            {
                MessageBox.Show("to much table");
                return;
            }
            if(Customer.currentCustomer.SpecialService!= CustomerSpecialService.Bronze || Customer.currentCustomer.SpecialService != CustomerSpecialService.Silver || Customer.currentCustomer.SpecialService != CustomerSpecialService.Golden)
            {
                MessageBox.Show("only special customre can reserve");//منطق خداس
                return;
            }
            if (restaurantMenuPage.Restaurant_Menu.admissionType == AdmissionType.delivery)
            {
                MessageBox.Show("this restuarant is not able to dine in");
                return;
            }
            
            onlinePaySimiulate ops = new onlinePaySimiulate();
            ops.titleLabel.Content = $"reserve restaurant : {restaurantMenuPage.Restaurant_Menu.name} number table {table_want} ";

            ops.Show();

        }
    }
}
