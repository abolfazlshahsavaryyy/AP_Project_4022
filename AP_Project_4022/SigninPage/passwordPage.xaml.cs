using AP_Project_4022.classes;
using AP_Project_4022.CustomerPage;
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

namespace AP_Project_4022.SigninPage
{
    /// <summary>
    /// Interaction logic for passwordPage.xaml
    /// </summary>
    public partial class passwordPage : Window
    {
        public passwordPage()
        {
            InitializeComponent();
        }

        private void signinButton_Click(object sender, RoutedEventArgs e)
        {
            if(passwordTextBox.Password==string.Empty || retryPasswordTextBox.Password==string.Empty)
            {
                MessageBox.Show("password cant me empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(passwordTextBox.Password!=retryPasswordTextBox.Password)
            {
                MessageBox.Show("password must be same!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(!RegexValidation.ValidateCustomerPassword(passwordTextBox.Password))
            {
                MessageBox.Show("incorrect password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            singinPage.temporaryCustomer.password= passwordTextBox.Password;
            Customer.allCustomers.Add(singinPage.temporaryCustomer);
            Customer.currentCustomer=singinPage.temporaryCustomer;
            Customer.currentCustomer.customer_first_page=new customerFirstPage();
            singinPage.temporaryCustomer = null;
            Customer.currentCustomer.customer_first_page.Show();

        }
    }
}
