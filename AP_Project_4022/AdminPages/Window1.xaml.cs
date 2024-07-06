using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace AP_Project_4022.AdminPages
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string data;
        public Window1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isDone = true;
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                string message = "Username and password field can not be empty!";
                string title = "Error";
                System.Windows.MessageBox.Show(message, title);
                isDone = false;
            }
            else if(!int.TryParse(txtTable.Text, out var a))
            {
                string message = "Please Enter valid number for tables!";
                string title = "Error";
                System.Windows.MessageBox.Show(message, title);
                isDone = false;
            }
            else if(txtAdmission.Text != "dine_in" && txtAdmission.Text != "delivery" && txtAdmission.Text != "")
            {
                string message = "Admission type should be dine_in or delivery!";
                string title = "Error";
                System.Windows.MessageBox.Show(message, title);
                isDone = false;
            }
            else
            {
                try
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
                        if (txtUsername.Text == data.Rows[i][0])
                        {
                            string message = "This username is not available";
                            string title = "Error";
                            System.Windows.MessageBox.Show(message, title);
                            isDone = false;
                        }
                    }
                    con.Close();
                    SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30");
                    con1.Open();
                    if (isDone)
                    {
                        command = "insert into RestaurantTable values('" + txtUsername.Text + "' , '" + txtPassword.Text + "' , '" + txtCity.Text + "' , '" + txtAdmission.Text + "' , '" + txtName.Text + "' , '" + null + "' , '" + 0 + "', '" + int.Parse(txtTable.Text) + "' , '" + txtAddress.Text + "' , '" + null + "' , '" + 0 + "' , '" + false +"')";
                        SqlCommand com1 = new SqlCommand(command, con1);
                        com1.BeginExecuteNonQuery();
                        string message1 = "Restaurant added successfully!";
                        string title1 = "Added";
                        System.Windows.MessageBox.Show(message1, title1);
                        con1.Close();
                        this.Close();
                    }
                }
                catch(Exception ex)
                {
                    string message1 = ex.ToString();
                    string title1 = "Error";
                    System.Windows.MessageBox.Show(message1, title1);
                }
                
            }
        }
    }
}
