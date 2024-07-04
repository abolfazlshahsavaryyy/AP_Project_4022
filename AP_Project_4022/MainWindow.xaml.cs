using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AP_Project_4022.SigninPage;
using AP_Project_4022.CustomerPage;
using AP_Project_4022.classes;


namespace AP_Project_4022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(usernameTextBox.Text==string.Empty || passwordTextBox.Password==string.Empty)
            {
                MessageBox.Show("no argument can be empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            for(int i = 0; i < Customer.allCustomers.Count; i++)
            {
                if (Customer.allCustomers[i].username==usernameTextBox.Text && Customer.allCustomers[i].password == passwordTextBox.Password)
                {
                    Customer.currentCustomer = Customer.allCustomers[i];
                    Customer.currentCustomer.customer_first_page=new customerFirstPage();
                    Customer.currentCustomer.customer_first_page.Show();
                    return;
                }
            }
            for(int i=0;i<Restaurant.allRestaurant.Count;i++)
            {
                if (Restaurant.allRestaurant[i].userName==usernameTextBox.Text && Restaurant.allRestaurant[i].password == passwordTextBox.Password)
                {
                    Restaurant.currentRestaurant = null;//sepehr part
                    return;
                }
            }
            for(int i=0;i<Admin.allAdmin.Count;i++)
            {
                if (Admin.allAdmin[i].UserName == usernameTextBox.Text && Admin.allAdmin[i].Password == passwordTextBox.Password)
                {
                    Admin.CurrentAdmin = null;//sepehr part
                    return;
                }
            }
            MessageBox.Show("user not exists!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;

        }

        private void SigninButton_Click(object sender, RoutedEventArgs e)
        {
            singinPage sp = new singinPage();sp.Show(); 
        }
    }
}