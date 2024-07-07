using AP_Project_4022.classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
            con.Open();
            string command;
            command = "delete from FoodTable where FoodCategory = '" + txtCategory.Text + "'";
            SqlCommand com = new SqlCommand(command, con);
            com.ExecuteNonQuery();
            string message = "Deleted Successfully!";
            string title = "Done";
            System.Windows.MessageBox.Show(message, title);
            con.Close();
            this.Close();
        }
    }
}
