using AP_Project_4022.AdminPages;
using AP_Project_4022.classes;
using AP_Project_4022.RestaurantPages;
using Microsoft.Data.SqlClient;
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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command;
            command = "insert into AdminTable values('"+ "abolfazl" +"', '"+ 1383 +"')";
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Restaurant.currentRestaurant = new Restaurant("Sepehr", "555", "Isfahan", AdmissionType.dine_in, "Sepehr", 0, "Isf", 20);
            Restaurant.currentRestaurant.restaurant_panel = new RestaurantPanel();
            Restaurant.currentRestaurant.restaurant_panel.Show();
        }

        private void SigninButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}