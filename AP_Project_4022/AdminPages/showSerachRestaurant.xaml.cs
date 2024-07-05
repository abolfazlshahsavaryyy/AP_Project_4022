using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AP_Project_4022.AdminPages
{
    /// <summary>
    /// Interaction logic for showSerachRestaurant.xaml
    /// </summary>
    public partial class showSerachRestaurant : Window
    {
        string search;
        public showSerachRestaurant(string searchBy)
        {
            InitializeComponent();
            search = searchBy;
            tbTitle.Text = "Search Restaurants by " + searchBy;
            tbHint.Text = "Enter " + searchBy;
            if (searchBy == "Complaint")
            {
                stcSearchBar.Visibility = Visibility.Hidden;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command = "select * from RestaurantTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (int.Parse(data.Rows[i][10].ToString()) != 0)
                    {
                        lstRestaurant.Items.Add(new { Username = data.Rows[i][0], City = data.Rows[i][2], Name = data.Rows[i][4], AvgPoint = data.Rows[i][6], Tables = data.Rows[i][7], Address = data.Rows[i][8], Complaints = data.Rows[i][10] });
                    }
                }
                con.Close();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(search == "City")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command = "select * from RestaurantTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if ((data.Rows[i][2].ToString().ToLower()).Contains(txtSearch.Text.ToLower()))
                    {
                        lstRestaurant.Items.Add(new { Username = data.Rows[i][0], City = data.Rows[i][2], Name = data.Rows[i][4], AvgPoint = data.Rows[i][6], Tables = data.Rows[i][7], Address = data.Rows[i][8], Complaints = data.Rows[i][10] });
                    }
                }
                con.Close();
            }
            else if (search == "Name")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command = "select * from RestaurantTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if ((data.Rows[i][4].ToString().ToLower()).Contains(txtSearch.Text.ToLower()))
                    {
                        lstRestaurant.Items.Add(new { Username = data.Rows[i][0], City = data.Rows[i][2], Name = data.Rows[i][4], AvgPoint = data.Rows[i][6], Tables = data.Rows[i][7], Address = data.Rows[i][8], Complaints = data.Rows[i][10] });
                    }
                }
                con.Close();
            }
            else if(search == "MinScore")
            {
                if(!int.TryParse(txtSearch.Text, out int m) || m > 5 || m < 0)
                {
                    string message1 = "Please Enter valid numebr between 0 and 5!";
                    string title1 = "Error";
                    System.Windows.MessageBox.Show(message1, title1);
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30");
                    con.Open();
                    string command;
                    command = "select * from RestaurantTable";
                    SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    SqlCommand com = new SqlCommand(command, con);
                    com.BeginExecuteNonQuery();
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (double.Parse(data.Rows[i][6].ToString()) >= double.Parse(txtSearch.Text.ToString()))
                        {
                            lstRestaurant.Items.Add(new { Username = data.Rows[i][0], City = data.Rows[i][2], Name = data.Rows[i][4], AvgPoint = data.Rows[i][6], Tables = data.Rows[i][7], Address = data.Rows[i][8], Complaints = data.Rows[i][10] });
                        }
                    }
                    con.Close();
                }
            }
        }
    }
}
