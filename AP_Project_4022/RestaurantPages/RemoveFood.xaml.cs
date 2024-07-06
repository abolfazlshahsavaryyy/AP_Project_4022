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
    /// Interaction logic for RemoveFood.xaml
    /// </summary>
    public partial class RemoveFood : Window
    {
        public RemoveFood()
        {
            InitializeComponent();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
            con.Open();
            string command;
            command = "select * from FoodTable";
            SqlDataAdapter adapter1 = new SqlDataAdapter(command, con);
            DataTable data1 = new DataTable();
            adapter1.Fill(data1);
            SqlCommand com1 = new SqlCommand(command, con);
            com1.ExecuteNonQuery();
            if (!int.TryParse(txtId.Text, out int m) || m < 0)
            {
                string message = "Please enter valid food ID!";
                string title = "Error";
                System.Windows.MessageBox.Show(message, title);
            }
            else if (int.Parse(txtId.Text) > data1.Rows.Count)
            {
                string message = "This ID is not available!";
                string title = "Error";
                System.Windows.MessageBox.Show(message, title);
            }
            else
            {
                var wanted = (from d in data1.AsEnumerable()
                             where d.Field<int>("Id") == int.Parse(txtId.Text)
                             select d).ToList();
                command = "delete from FoodTable where Id = '" + wanted[0].Field<int>("Id") + "'";
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
                string message = "Deleted Successfully!";
                string title = "Done";
                System.Windows.MessageBox.Show(message, title);
                con.Close();
                this.Close();
            }
            con.Close();
            
        }
    }
}
