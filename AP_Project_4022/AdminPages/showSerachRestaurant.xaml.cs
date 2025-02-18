﻿using Microsoft.Data.SqlClient;
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
using System.Linq;

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
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
                con.Open();
                string command;
                command = "select * from RestaurantTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                var wanted = (from d in data.AsEnumerable()
                             where d.Field<int>("Complaints") != 0
                             select d).ToList();
                foreach( var d in wanted )
                {
                    lstRestaurant.Items.Add(new { Username = d.Field<string>("UserName"), City = d.Field<string>("City"), Name = d.Field<string>("Name"), AvgPoint = d.Field<double>("AveragePoint"), Tables = d.Field<int>("NumberTable"), Address = d.Field<string>("Adress"), Complaints = d.Field<int>("Complaints") });
                }
                con.Close();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            lstRestaurant.Items.Clear();
            if(search == "City")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
                con.Open();
                string command;
                command = "select * from RestaurantTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                var wanted = (from d in data.AsEnumerable()
                              where d.Field<string>("City").ToLower().Contains(txtSearch.Text.ToLower())
                              select d).ToList();
                foreach (var d in wanted)
                {
                    lstRestaurant.Items.Add(new { Username = d.Field<string>("UserName"), City = d.Field<string>("City"), Name = d.Field<string>("Name"), AvgPoint = d.Field<double>("AveragePoint"), Tables = d.Field<int>("NumberTable"), Address = d.Field<string>("Adress"), Complaints = d.Field<int>("Complaints") });
                }
                con.Close();
            }
            else if (search == "Name")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
                con.Open();
                string command;
                command = "select * from RestaurantTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                var wanted = (from d in data.AsEnumerable()
                              where d.Field<string>("Name").ToLower().Contains(txtSearch.Text.ToLower())
                              select d).ToList();
                foreach (var d in wanted)
                {
                    lstRestaurant.Items.Add(new { Username = d.Field<string>("UserName"), City = d.Field<string>("City"), Name = d.Field<string>("Name"), AvgPoint = d.Field<double>("AveragePoint"), Tables = d.Field<int>("NumberTable"), Address = d.Field<string>("Adress"), Complaints = d.Field<int>("Complaints") });
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
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
                    con.Open();
                    string command;
                    command = "select * from RestaurantTable";
                    SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    SqlCommand com = new SqlCommand(command, con);
                    com.BeginExecuteNonQuery();
                    var wanted = (from d in data.AsEnumerable()
                                  where d.Field<double>("AveragePoint") >= double.Parse(txtSearch.Text)
                                  select d).ToList();
                    foreach (var d in wanted)
                    {
                        lstRestaurant.Items.Add(new { Username = d.Field<string>("UserName"), City = d.Field<string>("City"), Name = d.Field<string>("Name"), AvgPoint = d.Field<double>("AveragePoint"), Tables = d.Field<int>("NumberTable"), Address = d.Field<string>("Adress"), Complaints = d.Field<int>("Complaints") });
                    }
                    con.Close();
                }
            }
        }
    }
}
