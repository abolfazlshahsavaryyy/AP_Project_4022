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
    /// Interaction logic for CheckComplaint.xaml
    /// </summary>
    public partial class CheckComplaint : Window
    {
        public CheckComplaint()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            bool ifDone = true;
            if(!int.TryParse(txtName.Text, out int a))
            {
                string message = "Please Enter valid ID!";
                string title = "Error";
                System.Windows.MessageBox.Show(message, title);
                ifDone = false;
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\U\source\repos\AP_Project_4022\AP_Project_4022\database.mdf;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True");
                con.Open();
                string command;
                command = "select * from ComplaintTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                var wanted = (from d in data.AsEnumerable()
                             where d.Field<int>("Id") == int.Parse(txtName.Text)
                             select d).ToList();
                com.Dispose();
                if(wanted.Count == 0)
                {
                    string message = "This ID is not available!";
                    string title = "Error";
                    System.Windows.MessageBox.Show(message, title);
                    ifDone = false;
                }
                else if(txtAnswer.Text == "")
                {
                    string message = "Please Enter valid answer!";
                    string title = "Error";
                    System.Windows.MessageBox.Show(message, title);
                    ifDone = false;
                }
                else
                {
                    if (wanted[0].Field<bool>("IsCheck"))
                    {
                        string message = "This complaint has already been checked!";
                        string title = "Error";
                        System.Windows.MessageBox.Show(message, title);
                        ifDone = false;
                    }
                    else
                    {
                        string command1;
                        command = "update ComplaintTable set Id = '"+ wanted[0].Field<int>("Id") + "' , Restaurant = '"+ wanted[0].Field<string>("Restaurant") +"' , CustomerUserName = '"+ wanted[0].Field<string>("CustomerUserName") +"' , AdminReply = '"+ txtAnswer.Text +"' , CustomerComment = '"+ wanted[0].Field<string>("CustomerComment") + "' , IsCheck = '"+ true +"' , CustomerName = '"+ wanted[0].Field<string>("CustomerName") +"' , Title = '"+ wanted[0].Field<string>("Title") +"' where Id = '"+ int.Parse(txtName.Text) +"' ";
                        SqlCommand com1 = new SqlCommand(command, con);
                        com1.ExecuteNonQuery();
                        string message = "You replied this complaint successfully!";
                        string title = "Done";
                        System.Windows.MessageBox.Show(message, title);
                        ifDone = true;
                    }
                }
                con.Close();
                if (ifDone)
                    this.Close();
            }
        }
    }
}
