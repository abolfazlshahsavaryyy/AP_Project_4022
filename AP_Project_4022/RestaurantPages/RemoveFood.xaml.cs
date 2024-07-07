using AP_Project_4022.classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using System.Windows.Media.Media3D;
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
                var wanted = (from d in data1.AsEnumerable()
                             where d.Field<int>("Id") == int.Parse(txtId.Text)
                             select d).ToList();
                command = "delete from FoodTable where Id = '" + wanted[0].Field<int>("Id") + "'";
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
                command = "select * from RestaurantTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com2 = new SqlCommand(command, con);
                com2.ExecuteNonQuery();
                var resWanted = (from d in data.AsEnumerable()
                                 where d.Field<string>("UserName") == Restaurant.currentRestaurant.userName
                                 select d).ToList();
                List<string> str = resWanted[0].Field<string>("Foods").Split(',').ToList();
                str.Remove(wanted[0].Field<int>("Id") + "");
                string s = String.Join(",", str);
                command = "update RestaurantTable set UserName = '" + resWanted[0].Field<string>("UserName") + "' , Password = '" + resWanted[0].Field<string>("Password") + "' , City = '" + resWanted[0].Field<string>("City") + "' , AdmissionType = '" + resWanted[0].Field<string>("AdmissionType") + "' , Name = '" + resWanted[0].Field<string>("Name") + "' , AllRating = '" + resWanted[0].Field<string>("AllRating") + "' , AveragePoint = '" + resWanted[0].Field<double>("AveragePoint") + "' , NumberTable = '" + resWanted[0].Field<int>("NumberTable") + "' , Adress = '" + resWanted[0].Field<string>("Adress") + "' , Foods = '" + s + "' , Complaints = '"+ resWanted[0].Field<int>("Complaints") +"' , Reserve = '"+ resWanted[0].Field<bool>("Reserve") +"'  where UserName = '" + resWanted[0].Field<string>("UserName") + "' ";
                SqlCommand com3 = new SqlCommand(command, con);
                com3.ExecuteNonQuery();
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
