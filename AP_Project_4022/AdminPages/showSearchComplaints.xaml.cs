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

namespace AP_Project_4022.AdminPages
{
    /// <summary>
    /// Interaction logic for showSearchComplaints.xaml
    /// </summary>
    public partial class showSearchComplaints : Window
    {
        string search;
        public showSearchComplaints(string searchBy)
        {
            InitializeComponent();
            search = searchBy;
            tbTitle.Text = "Search Restaurants by " + searchBy;
            tbHint.Text = "Enter " + searchBy;
            if(searchBy == "Status")
            {
                stcSearchBar.Visibility = Visibility.Hidden;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command = "select * from ComplaintTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                var wanted = (from d in data.AsEnumerable()
                              where !d.Field<bool>("IsCheck")
                              select d).ToList();
                foreach (var d in wanted)
                {
                    lstComplaints.Items.Add(new { ID = d.Field<int>("Id"), Restaurant = d.Field<string>("Restaurant"), CUsername = d.Field<string>("CustomerUserName"), Checked = d.Field<bool>("IsCheck"), CName = d.Field<string>("CustomerName") });
                }
                con.Close();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < lstComplaints.Items.Count; i++)
            {
                lstComplaints.Items.RemoveAt(i);
            }
            if (search == "Username")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command = "select * from ComplaintTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                var wanted = (from d in data.AsEnumerable()
                              where d.Field<string>("CustomerUserName").ToLower().Contains(txtSearch.Text.ToLower())
                              select d).ToList();
                foreach (var d in wanted)
                {
                    lstComplaints.Items.Add(new { ID = d.Field<int>("Id"), Title = d.Field<string>("Title"), Restaurant = d.Field<string>("Restaurant"), CUsername = d.Field<string>("CustomerUserName"), Checked = d.Field<bool>("IsCheck"), CName = d.Field<string>("CustomerName") });
                }
                con.Close();
            }
            else if (search == "Title")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command = "select * from ComplaintTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                var wanted = (from d in data.AsEnumerable()
                              where d.Field<string>("Title").ToLower().Contains(txtSearch.Text.ToLower())
                              select d).ToList();
                foreach (var d in wanted)
                {
                    lstComplaints.Items.Add(new { ID = d.Field<int>("Id"), Title = d.Field<string>("Title"), Restaurant = d.Field<string>("Restaurant"), CUsername = d.Field<string>("CustomerUserName"), Checked = d.Field<bool>("IsCheck"), CName = d.Field<string>("CustomerName") });
                }
                con.Close();
            }
            else if (search == "Name")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command = "select * from ComplaintTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                var wanted = (from d in data.AsEnumerable()
                              where d.Field<string>("CustomerName").ToLower().Contains(txtSearch.Text.ToLower())
                              select d).ToList();
                foreach (var d in wanted)
                {
                    lstComplaints.Items.Add(new { ID = d.Field<int>("Id"), Title = d.Field<string>("Title"), Restaurant = d.Field<string>("Restaurant"), CUsername = d.Field<string>("CustomerUserName"), Checked = d.Field<bool>("IsCheck"), CName = d.Field<string>("CustomerName") });
                }
                con.Close();
            }
            else if (search == "Restaurant")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command = "select * from ComplaintTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                var wanted = (from d in data.AsEnumerable()
                              where d.Field<string>("Restaurant").ToLower().Contains(txtSearch.Text.ToLower())
                              select d).ToList();
                foreach (var d in wanted)
                {
                    lstComplaints.Items.Add(new { ID = d.Field<int>("Id"), Title = d.Field<string>("Title"), Restaurant = d.Field<string>("Restaurant"), CUsername = d.Field<string>("CustomerUserName"), Checked = d.Field<bool>("IsCheck"), CName = d.Field<string>("CustomerName") });
                }
                con.Close();
            }
        }
    }
}
