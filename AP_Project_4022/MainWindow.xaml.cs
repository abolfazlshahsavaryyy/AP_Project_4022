using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AP_Project_4022.SigninPage;
using AP_Project_4022.CustomerPage;
using AP_Project_4022.classes;
using Microsoft.Data.SqlClient;
using System.Data;


namespace AP_Project_4022
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainWindow()
        {
            SqlConnection con = new SqlConnection(@"D:\AP_PROJECT\AP_PROJECT_4022\DB.MDF");
            con.Open();
            string command;
            command = "SELECT * from CustomerTable";
            SqlDataAdapter adapter = new SqlDataAdapter(command,con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for(int i = 0; i < data.Rows.Count; i++)
            {
                bool gender_customer=true;
                string gender = data.Rows[i][8].ToString();
                if (gender == "True")
                {
                    gender_customer= true;
                }
                else
                {
                    gender_customer= false;
                }
                Customer.allCustomers.Add(new Customer(data.Rows[i][3].ToString(), data.Rows[i][4].ToString(),
                    data.Rows[i][5].ToString(), data.Rows[i][2].ToString(),data.Rows[i][6].ToString(),
                    data.Rows[i][7].ToString(), gender_customer, data.Rows[i][0].ToString()));
            }
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();


            //##############################################################################3


            con = new SqlConnection(@"D:\AP_PROJECT\AP_PROJECT_4022\DB.MDF");
            con.Open();
            command = "SELECT * from RestauranTable";
            adapter = new SqlDataAdapter(command, con);
            data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                AdmissionType? at = AdmissionType.dine_in;
                if (data.Rows[i][3].ToString() == AdmissionType.delivery.ToString())
                {
                    at= AdmissionType.delivery;
                }
                else if(data.Rows[i][3].ToString() == AdmissionType.dine_in.ToString())
                {
                    at=AdmissionType.dine_in;
                }
                else if(data.Rows[i][3].ToString() == "null")
                {
                    at = null;
                }
                Restaurant.allRestaurant.Add(new Restaurant(data.Rows[i][0].ToString(), data.Rows[i][1].ToString(),
                    data.Rows[i][2].ToString(), at, data.Rows[i][4].ToString(), int.Parse(data.Rows[i][6].ToString()),
                    data.Rows[i][8].ToString(), int.Parse(data.Rows[i][7].ToString())));
            }
            com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            

            con.Close();


            //###############################################################################

            con = new SqlConnection(@"D:\AP_PROJECT\AP_PROJECT_4022\DB.MDF");
            con.Open();
            command = "SELECT * from CommentTable";
            adapter = new SqlDataAdapter(command, con);
            data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Comment.allcomments.Add(new Comment(int.Parse(data.Rows[i][0].ToString()), data.Rows[i][1].ToString(),
                    data.Rows[i][2].ToString(), null, DateTime.Parse(data.Rows[i][4].ToString())));
            }
            for(int i = 0; i < Comment.allcomments.Count; i++)
            {
                if (data.Rows[i][3].ToString() != "null")
                {
                    Comment.allcomments[i].reply = Comment.GetComment(int.Parse(data.Rows[i][3].ToString()));
                }
            }
            com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
           

            con.Close();


            //################################################################################################

            con = new SqlConnection(@"D:\AP_PROJECT\AP_PROJECT_4022\DB.MDF");
            con.Open();
            command = "SELECT * from ComplaintTable";
            adapter = new SqlDataAdapter(command, con);
            data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][3].ToString() == "null")
                {
                    Complaint.allComplaints.Add(new Complaint(int.Parse(data.Rows[i][0].ToString()),
                  Restaurant.GetRestaurant(data.Rows[i][1].ToString(), true),
                  Customer.GetCustomer(data.Rows[i][2].ToString()),
                  null, Comment.GetComment(int.Parse(data.Rows[i][4].ToString())),
                  true));
                }
                  Complaint.allComplaints.Add(new Complaint(int.Parse(data.Rows[i][0].ToString()),
                  Restaurant.GetRestaurant(data.Rows[i][1].ToString(),true),
                  Customer.GetCustomer(data.Rows[i][2].ToString()),
                  Comment.GetComment(int.Parse(data.Rows[i][3].ToString())),Comment.GetComment(int.Parse(data.Rows[i][4].ToString())),
                  true));

            }
            com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            

            con.Close();


            //##########################################################


            con = new SqlConnection(@"D:\AP_PROJECT\AP_PROJECT_4022\DB.MDF");
            con.Open();
            command = "SELECT * from OrderHistoryTable";
            adapter = new SqlDataAdapter(command, con);
            data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                OrderHistory.allOrderHistory.Add(new OrderHistory(Customer.GetCustomer(data.Rows[i][2].ToString()),
                    Restaurant.GetRestaurant(data.Rows[i][3].ToString(), true), int.Parse(data.Rows[i][0].ToString()),
                    Comment.GetComment(int.Parse(data.Rows[i][1].ToString())),new Food()));//bug

            }
            com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            

            con.Close();
            //############################################################################################

            con = new SqlConnection(@"D:\AP_PROJECT\AP_PROJECT_4022\DB.MDF");
            con.Open();
            command = "SELECT * from OrderHistoryTable";
            adapter = new SqlDataAdapter(command, con);
            data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                List<string> m = data.Rows[i][8].ToString().Split(',').ToList();
                Food.allFood.Add(new Food(data.Rows[i][0].ToString(),
                    double.Parse(data.Rows[i][1].ToString()),
                    double.Parse(data.Rows[i][2].ToString()), int.Parse(data.Rows[i][4].ToString()),
                    new List<Comment>(), data.Rows[i][7].ToString(),m) );//bug   

            }
            com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();


            con.Close();
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(usernameTextBox.Text==string.Empty || passwordTextBox.Password==string.Empty)
            {
                MessageBox.Show("no argument can be empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            for(int i = 0; i < Customer.allCustomers.Count; i++)
            {
                if (Customer.allCustomers[i].username==usernameTextBox.Text && Customer.allCustomers[i].password == passwordTextBox.Password)
                {
                    Customer.currentCustomer = Customer.allCustomers[i];
                    Customer.currentCustomer.customer_first_page=new customerFirstPage();
                    Customer.currentCustomer.customer_first_page.Show();
                    return;
                }
            }
            for(int i=0;i<Restaurant.allRestaurant.Count;i++)
            {
                if (Restaurant.allRestaurant[i].userName==usernameTextBox.Text && Restaurant.allRestaurant[i].password == passwordTextBox.Password)
                {
                    Restaurant.currentRestaurant = null;//sepehr part
                    return;
                }
            }
            for(int i=0;i<Admin.allAdmin.Count;i++)
            {
                if (Admin.allAdmin[i].UserName == usernameTextBox.Text && Admin.allAdmin[i].Password == passwordTextBox.Password)
                {
                    Admin.CurrentAdmin = null;//sepehr part
                    return;
                }
            }
            MessageBox.Show("user not exists!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;

        }

        private void SigninButton_Click(object sender, RoutedEventArgs e)
        {
            singinPage sp = new singinPage();sp.Show(); 
        }
    }
}