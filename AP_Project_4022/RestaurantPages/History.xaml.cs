using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
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
            string directoryPath = "C:\\project\\";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            if (dataTable != null)
                dataTable.ToCSV("C:\\project\\data.csv");
            string message = "CSV File has been created in C:\\project!";
            string title = "Done";
            System.Windows.MessageBox.Show(message, title);
        }
    }

    public static class CSVUtlity 
    {
        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }

}


