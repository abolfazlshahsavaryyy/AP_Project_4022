using Microsoft.Data.SqlClient;
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
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace AP_Project_4022.RestaurantPages
{
    /// <summary>
    /// Interaction logic for AddFood.xaml
    /// </summary>
    public partial class AddFood : Window
    {
        public AddFood()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtPrice.Text == "")
            {
                string message = "Name and price field can not be empty!";
                string title = "Error";
                System.Windows.MessageBox.Show(message, title);
            }
            else if (!double.TryParse(txtPrice.Text, out double price) || price < 0)
            {
                string message = "Please enter valid price!";
                string title = "Error";
                System.Windows.MessageBox.Show(message, title);
            }
            else if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                string message = "Please enter valid stock!";
                string title = "Error";
                System.Windows.MessageBox.Show(message, title);
            }
            else
            {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
                    con.Open();
                    string command;
                    command = "insert into FoodTable values('" + txtName.Text + "' , '" + double.Parse(txtPrice.Text) + "' , '" + 0 + "' , '" + null + "' , '" + int.Parse(txtStock.Text) + "' , '" + null + "' , '" + txtCategory.Text + "' , '" + null + "' , '" + txtMaterials.Text + "')";
                    SqlCommand com = new SqlCommand(command, con);
                    com.ExecuteNonQuery();
                    con.Close();
                    string message = "This food added successfully!";
                    string title = "Done";
                    System.Windows.MessageBox.Show(message, title);
                    this.Close();
            }
        }
    }
}
