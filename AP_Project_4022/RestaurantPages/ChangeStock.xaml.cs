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
    /// Interaction logic for ChangeStock.xaml
    /// </summary>
    public partial class ChangeStock : Window
    {
        int Id;
        public ChangeStock()
        {
            InitializeComponent();
        }

        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
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
                Id = int.Parse(txtId.Text);
                txtId.Visibility = Visibility.Hidden;
                tbId.Visibility = Visibility.Hidden;
                btnId.Visibility = Visibility.Hidden;
                tbStock.Visibility = Visibility.Visible;
                txtStock.Visibility = Visibility.Visible;
                btnDone.Visibility = Visibility.Visible;
            }
            con.Close();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            if(!int.TryParse(txtStock.Text, out int m) || m < 0)
            {
                string message = "Please Enter valid stock!";
                string title = "Error";
                System.Windows.MessageBox.Show(message, title);
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
                con.Open();
                string command;
                command = "select * from FoodTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com1 = new SqlCommand(command, con);
                com1.ExecuteNonQuery();
                var wanted = (from d in data.AsEnumerable()
                              where d.Field<int>("Id") == Id
                              select d).ToList();
                command = "update FoodTable set Id = '" + wanted[0].Field<int>("Id") + "' , Name = '" + wanted[0].Field<string>("Name") + "' , Price = '" + wanted[0].Field<double>("Price") + "' , AveragePoint = '" + wanted[0].Field<double>("AveragePoint") + "' , AllRating = '" + wanted[0].Field<string>("AllRating") + "' , NumberFood = '" + int.Parse(txtStock.Text) + "' , FoodComments = '" + wanted[0].Field<string>("FoodComments") + "' , FoodCategory = '" + wanted[0].Field<string>("FoodCategory") + "' , PicturePath = '" + wanted[0].Field<string>("PicturePath") + "' , FoodRawMaterial = '" + wanted[0].Field<string>("FoodRawMaterial") + "'  where Id = '" + wanted[0].Field<int>("Id") + "' ";
                SqlCommand com2 = new SqlCommand(command, con);
                com2.ExecuteNonQuery();
                con.Close();
                string message = "This food edited successfully!";
                string title = "Done";
                System.Windows.MessageBox.Show(message, title);
                this.Close();
            }
        }
    }
}
