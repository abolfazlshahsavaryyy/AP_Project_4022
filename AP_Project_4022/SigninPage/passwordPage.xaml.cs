using AP_Project_4022.classes;
using AP_Project_4022.CustomerPage;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
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
using Microsoft.Data.SqlClient;

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
                MessageBox.Show("incorrect format password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            singinPage.temporaryCustomer.password= passwordTextBox.Password;
            Customer.allCustomers.Add(singinPage.temporaryCustomer);
            //SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\AP_Project\\AP_Project_4022\\AP_Project_4022\\db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
            //con.Open();

            //string command="insert into CustomerTable values('"+singinPage.temporaryCustomer.username+"'," +
            //    "'"+ ""+ "'," +
            //    "'"+ ""+ "'," +
            //    "'"+ singinPage.temporaryCustomer .firstName+ "'," +
            //    "'"+ singinPage.temporaryCustomer .lastName+ "'," +
            //    "'"+ singinPage.temporaryCustomer .email+ "'," +
            //    "'"+ singinPage.temporaryCustomer .phoneNumber+ "'," +
            //    "'"+ ""+ "'" +
            //    "'"+ true+ "')";

            //SqlCommand com=new SqlCommand(command, con);
            //com.ExecuteNonQuery();
            //con.Close();
            Customer.currentCustomer=singinPage.temporaryCustomer;
            Customer.currentCustomer.customer_first_page=new customerFirstPage();
            singinPage.temporaryCustomer = null;
            Customer.currentCustomer.customer_first_page.Show();

        }
    }
}
