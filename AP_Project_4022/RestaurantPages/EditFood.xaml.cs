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
    /// Interaction logic for EditFood.xaml
    /// </summary>
    public partial class EditFood : Window
    {
        int Id;
        public EditFood()
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
            if (!int.TryParse(txtId.Text, out int m) || m < 0)
            {
                string message = "Please enter valid food ID!";
                string title = "Error";
                System.Windows.MessageBox.Show(message, title);
            }
            else if(int.Parse(txtId.Text) > data1.Rows.Count)
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
                tbPrice.Visibility = Visibility.Visible;
                txtPrice.Visibility = Visibility.Visible;
                tbMaterials.Visibility = Visibility.Visible;
                txtMatrials.Visibility = Visibility.Visible;
                tbCategory.Visibility = Visibility.Visible;
                txtCategory.Visibility = Visibility.Visible;
                btnDone.Visibility = Visibility.Visible;
            }
            con.Close();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            bool changePrice = false, changeMatrials = false, changeCategory = false;
            if(txtCategory.Text != "")
                changeCategory = true;
            if (txtMatrials.Text != "")
                changeMatrials = true;
            if(txtPrice.Text != "")
                changePrice = true;

            if((!double.TryParse(txtPrice.Text, out double m) || m < 0) && changePrice)
            {
                string message = "Please enter valid price!";
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
                double price = wanted[0].Field<double>("Price");
                if (changePrice)
                    price = double.Parse(txtPrice.Text);
                string category = wanted[0].Field<string>("FoodCategory");
                if (changeCategory)
                    category = txtCategory.Text;
                string Material = wanted[0].Field<string>("FoodRawMaterial");
                if (changeMatrials)
                    Material = txtMatrials.Text;
                command = "update FoodTable set Id = '" + wanted[0].Field<int>("Id") + "' , Name = '" + wanted[0].Field<string>("Name") + "' , Price = '" + price + "' , AveragePoint = '" + wanted[0].Field<double>("AveragePoint") + "' , AllRating = '" + wanted[0].Field<string>("AllRating") + "' , NumberFood = '" + wanted[0].Field<int>("NumberFood") + "' , FoodComments = '" + wanted[0].Field<string>("FoodComments") + "' , FoodCategory = '" + category + "' , PicturePath = '" + wanted[0].Field<string>("PicturePath") + "' , FoodRawMaterial = '" + Material + "'  where Id = '" + wanted[0].Field<int>("Id") + "' ";
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
