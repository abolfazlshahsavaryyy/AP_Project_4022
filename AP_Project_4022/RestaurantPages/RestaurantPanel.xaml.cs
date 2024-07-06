using AP_Project_4022.classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AP_Project_4022.RestaurantPages
{
    /// <summary>
    /// Interaction logic for RestaurantPanel.xaml
    /// </summary>
    public partial class RestaurantPanel : Window
    {
        public RestaurantPanel()
        {
            InitializeComponent();
        }

        private void btnChangeMenu_Click(object sender, RoutedEventArgs e)
        {
            btnActiveService.Visibility = Visibility.Hidden;
            btnChangeMenu.Visibility = Visibility.Hidden;
            btnChangeStock.Visibility = Visibility.Hidden; 
            btnHistory.Visibility = Visibility.Hidden;
            stcChoose.Visibility = Visibility.Visible;
        }

        private void btnChangeStock_Click(object sender, RoutedEventArgs e)
        {
            Restaurant.currentRestaurant.change_stock = new ChangeStock();
            Restaurant.currentRestaurant.change_stock.Show();
        }

        private void btnActiveService_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
            con.Open();
            string command;
            command = "select * from RestaurantTable";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            SqlCommand com1 = new SqlCommand(command, con);
            com1.ExecuteNonQuery();
            var wanted = (from d in data.AsEnumerable()
                          where d.Field<string>("UserName") == Restaurant.currentRestaurant.userName
                          select d).ToList();
            if (wanted[0].Field<double>("AveragePoint") >= 2 && !wanted[0].Field<bool>("Reserve") )
            {
                command = "update RestaurantTable set UserName = '" + wanted[0].Field<string>("UserName") + "' , Password = '" + wanted[0].Field<string>("Password") + "' , City = '" + wanted[0].Field<string>("City") + "' , AdmissionType = '" + wanted[0].Field<string>("AdmissionType") + "' , Name = '" + wanted[0].Field<string>("Name") + "' , AllRating = '" + wanted[0].Field<string>("AllRating") + "' , AveragePoint = '" + wanted[0].Field<double>("AveragePoint") + "' , NumberTable = '" + wanted[0].Field<int>("NumberTable") + "' , Adress = '" + wanted[0].Field<string>("Adress") + "' , Foods = '" + wanted[0].Field<string>("Foods") + "' , Complaints = '" + wanted[0].Field<int>("Complaints") + "' , Reserve = '" + true + "'  where UserName = '" + wanted[0].Field<string>("UserName") + "' ";
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
                string message = "Service has been activated for your restaurant!";
                string title = "Done";
                System.Windows.MessageBox.Show(message, title);
            }
            else if(wanted[0].Field<double>("AveragePoint") < 2 && !wanted[0].Field<bool>("Reserve"))
            {
                string message = "Minimum average point for activating service is 2!";
                string title = "Failed";
                System.Windows.MessageBox.Show(message, title);
            }
            else if(wanted[0].Field<bool>("Reserve"))
            {
                command = "update RestaurantTable set UserName = '" + wanted[0].Field<string>("UserName") + "' , Password = '" + wanted[0].Field<string>("Password") + "' , City = '" + wanted[0].Field<string>("City") + "' , AdmissionType = '" + wanted[0].Field<string>("AdmissionType") + "' , Name = '" + wanted[0].Field<string>("Name") + "' , AllRating = '" + wanted[0].Field<string>("AllRating") + "' , AveragePoint = '" + wanted[0].Field<double>("AveragePoint") + "' , NumberTable = '" + wanted[0].Field<int>("NumberTable") + "' , Adress = '" + wanted[0].Field<string>("Adress") + "' , Foods = '" + wanted[0].Field<string>("Foods") + "' , Complaints = '" + wanted[0].Field<int>("Complaints") + "' , Reserve = '" + false + "'  where UserName = '" + wanted[0].Field<string>("UserName") + "' ";
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
                string message = "Service has been disabled for your restaurant!";
                string title = "Done";
                System.Windows.MessageBox.Show(message, title);
            }
            con.Close();
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            Restaurant.currentRestaurant.history = new History();
            Restaurant.currentRestaurant.history.Show();
        }

        private void btnEditFood_Click(object sender, RoutedEventArgs e)
        {
            Restaurant.currentRestaurant.edit_food = new EditFood();
            btnActiveService.Visibility = Visibility.Visible;
            btnChangeMenu.Visibility = Visibility.Visible;
            btnChangeStock.Visibility = Visibility.Visible;
            btnHistory.Visibility = Visibility.Visible;
            stcChoose.Visibility = Visibility.Hidden;
            Restaurant.currentRestaurant.edit_food.Show();
        }

        private void btnAddFood_Click(object sender, RoutedEventArgs e)
        {
            Restaurant.currentRestaurant.add_food = new AddFood();
            btnActiveService.Visibility = Visibility.Visible;
            btnChangeMenu.Visibility = Visibility.Visible;
            btnChangeStock.Visibility = Visibility.Visible;
            btnHistory.Visibility = Visibility.Visible;
            stcChoose.Visibility = Visibility.Hidden;
            Restaurant.currentRestaurant.add_food.Show();
        }

        private void btnRemoveFood_Click(object sender, RoutedEventArgs e)
        {
            Restaurant.currentRestaurant.remove_food = new RemoveFood();
            btnActiveService.Visibility = Visibility.Visible;
            btnChangeMenu.Visibility = Visibility.Visible;
            btnChangeStock.Visibility = Visibility.Visible;
            btnHistory.Visibility = Visibility.Visible;
            stcChoose.Visibility = Visibility.Hidden;
            Restaurant.currentRestaurant.remove_food.Show();
        }
    }
}
