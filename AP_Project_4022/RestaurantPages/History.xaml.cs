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
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        DataTable? dataTable = null;
        public History()
        {
            InitializeComponent();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            lstHistory.Items.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
            con.Open();
            string command;
            if (rdbUsername.IsChecked == true)
            {
                command = "select * from OrderHistoryTable";
                SqlDataAdapter adapter1 = new SqlDataAdapter(command, con);
                DataTable data1 = new DataTable();
                adapter1.Fill(data1);
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();

                var wanted = (from d in data1.AsEnumerable()
                              where d.Field<string>("Customer").Contains(txtFilter.Text)
                              select d
                              ).ToList();
                dataTable = (from d in data1.AsEnumerable()
                            where d.Field<string>("Customer").Contains(txtFilter.Text)
                            select d).CopyToDataTable();
                foreach (var d in wanted)
                {
                    lstHistory.Items.Add(new {Id = d.Field<int>("Id") , CName = d.Field<string>("Customer") , Restaurant = d.Field<string>("Restaurant") , CPhone = d.Field<string>("CustomerPhone") , Food = d.Field<int>("Food") , Price = d.Field<double>("Price") , Type = d.Field<string>("OrderReserve") });
                }
            }
            else if (rdbPhoneNumber.IsChecked == true)
            {
                if (!int.TryParse(txtFilter.Text, out int phoneNumber) || phoneNumber < 0)
                {
                    string message = "Please enter valid phone number!";
                    string title = "Error";
                    System.Windows.MessageBox.Show(message, title);
                }
                else
                {
                    command = "select * from OrderHistoryTable";
                    SqlDataAdapter adapter1 = new SqlDataAdapter(command, con);
                    DataTable data1 = new DataTable();
                    adapter1.Fill(data1);
                    SqlCommand com = new SqlCommand(command, con);
                    com.ExecuteNonQuery();

                    var wanted = (from d in data1.AsEnumerable()
                                  where d.Field<string>("PhoneNumber").Contains(txtFilter.Text)
                                  select d
                                  ).ToList();
                    dataTable = (from d in data1.AsEnumerable()
                                 where d.Field<string>("PhoneNumber").Contains(txtFilter.Text)
                                 select d
                                  ).CopyToDataTable();
                    foreach (var d in wanted)
                    {
                        lstHistory.Items.Add(new { Id = d.Field<int>("Id"), CName = d.Field<string>("Customer"), Restaurant = d.Field<string>("Restaurant"), CPhone = d.Field<string>("CustomerPhone"), Food = d.Field<int>("Food"), Price = d.Field<double>("Price"), Type = d.Field<string>("OrderReserve") });
                    }
                }
            }
            else if (rdbType.IsChecked == true)
            {
                command = "select * from OrderHistoryTable";
                SqlDataAdapter adapter1 = new SqlDataAdapter(command, con);
                DataTable data1 = new DataTable();
                adapter1.Fill(data1);
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();

                var wanted = (from d in data1.AsEnumerable()
                              where d.Field<string>("OrderReserve").Contains(txtFilter.Text)
                              select d
                              ).ToList();
                dataTable = (from d in data1.AsEnumerable()
                             where d.Field<string>("OrderReserve").Contains(txtFilter.Text)
                             select d
                              ).CopyToDataTable();
                foreach (var d in wanted)
                {
                    lstHistory.Items.Add(new { Id = d.Field<int>("Id"), CName = d.Field<string>("Customer"), Restaurant = d.Field<string>("Restaurant"), CPhone = d.Field<string>("CustomerPhone"), Food = d.Field<int>("Food"), Price = d.Field<double>("Price"), Type = d.Field<string>("OrderReserve") });
                }
            }
            else if (rdbminPrice.IsChecked == true)
            {
                if (!int.TryParse(txtFilter.Text, out int min) || min < 0)
                {
                    string message = "Please enter valid price!";
                    string title = "Error";
                    System.Windows.MessageBox.Show(message, title);
                }
                else
                {
                    command = "select * from OrderHistoryTable";
                    SqlDataAdapter adapter1 = new SqlDataAdapter(command, con);
                    DataTable data1 = new DataTable();
                    adapter1.Fill(data1);
                    SqlCommand com = new SqlCommand(command, con);
                    com.ExecuteNonQuery();

                    var wanted = (from d in data1.AsEnumerable()
                                  where d.Field<double>("Price") >= int.Parse(txtFilter.Text)
                                  select d
                                  ).ToList();
                    dataTable = (from d in data1.AsEnumerable()
                                 where d.Field<double>("Price") >= int.Parse(txtFilter.Text)
                                 select d
                                  ).CopyToDataTable();
                    foreach (var d in wanted)
                    {
                        lstHistory.Items.Add(new { Id = d.Field<int>("Id"), CName = d.Field<string>("Customer"), Restaurant = d.Field<string>("Restaurant"), CPhone = d.Field<string>("CustomerPhone"), Food = d.Field<int>("Food"), Price = d.Field<double>("Price"), Type = d.Field<string>("OrderReserve") });
                    }
                }
            }
            else if (rdbMaxPrice.IsChecked == true)
            {
                if (!int.TryParse(txtFilter.Text, out int max) || max < 0)
                {
                    string message = "Please enter valid price!";
                    string title = "Error";
                    System.Windows.MessageBox.Show(message, title);
                }
                else
                {
                    command = "select * from OrderHistoryTable";
                    SqlDataAdapter adapter1 = new SqlDataAdapter(command, con);
                    DataTable data1 = new DataTable();
                    adapter1.Fill(data1);
                    SqlCommand com = new SqlCommand(command, con);
                    com.ExecuteNonQuery();

                    var wanted = (from d in data1.AsEnumerable()
                                  where d.Field<double>("Price") <= int.Parse(txtFilter.Text)
                                  select d
                                  ).ToList();
                    dataTable = (from d in data1.AsEnumerable()
                                 where d.Field<double>("Price") <= int.Parse(txtFilter.Text)
                                 select d
                                  ).CopyToDataTable();
                    foreach (var d in wanted)
                    {
                        lstHistory.Items.Add(new { Id = d.Field<int>("Id"), CName = d.Field<string>("Customer"), Restaurant = d.Field<string>("Restaurant"), CPhone = d.Field<string>("CustomerPhone"), Food = d.Field<int>("Food"), Price = d.Field<double>("Price"), Type = d.Field<string>("OrderReserve") });
                    }
                }
            }
            else if (rdbFood.IsChecked == true)
            {
                if (!int.TryParse(txtFilter.Text, out int id) || id < 0)
                {
                    string message = "Please enter valid price!";
                    string title = "Error";
                    System.Windows.MessageBox.Show(message, title);
                }
                else
                {
                    command = "select * from OrderHistoryTable";
                    SqlDataAdapter adapter1 = new SqlDataAdapter(command, con);
                    DataTable data1 = new DataTable();
                    adapter1.Fill(data1);
                    SqlCommand com = new SqlCommand(command, con);
                    com.ExecuteNonQuery();

                    var wanted = (from d in data1.AsEnumerable()
                                  where d.Field<int>("Food") == int.Parse(txtFilter.Text)
                                  select d
                                  ).ToList();
                    dataTable = (from d in data1.AsEnumerable()
                                 where d.Field<int>("Food") == int.Parse(txtFilter.Text)
                                 select d
                                  ).CopyToDataTable();
                    foreach (var d in wanted)
                    {
                        lstHistory.Items.Add(new { Id = d.Field<int>("Id"), CName = d.Field<string>("Customer"), Restaurant = d.Field<string>("Restaurant"), CPhone = d.Field<string>("CustomerPhone"), Food = d.Field<int>("Food"), Price = d.Field<double>("Price"), Type = d.Field<string>("OrderReserve") });
                    }
                }
            }
            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    
}


