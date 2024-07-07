using AP_Project_4022.AdminPages;
using AP_Project_4022.classes;
using AP_Project_4022.RestaurantPages;
using Microsoft.Data.SqlClient;
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
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command = "SELECT * from CustomerTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    bool gender_customer = true;
                    string gender = data.Rows[i][8].ToString();
                    if (gender == "True")
                    {
                        gender_customer = true;
                    }
                    else
                    {
                        gender_customer = false;
                    }
                    Customer.allCustomers.Add(new Customer(data.Rows[i][3].ToString(),
                        data.Rows[i][4].ToString(),
                        data.Rows[i][5].ToString(),
                        data.Rows[i][2].ToString(),
                        data.Rows[i][6].ToString(),
                        data.Rows[i][7].ToString(),
                        bool.Parse(data.Rows[i][8].ToString()), data.Rows[i][0].ToString()));
                    
                    int index = Customer.allCustomers.Count - 1;
                    Customer.allCustomers[index].SpecialService = Customer.GetCustomerSpecialService(data.Rows[i][1].ToString());
                    List<Customer> customer = Customer.allCustomers;
                }
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warrning");
            }


            //##############################################################################3

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                string command = "SELECT * from CommentTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Comment.allcomments.Add(new Comment(int.Parse(data.Rows[i][0].ToString()),
                        data.Rows[i][1].ToString(), data.Rows[i][2].ToString(),
                        new Comment(),
                        DateTime.Parse(data.Rows[i][4].ToString())));
                    List<Comment> comments=Comment.allcomments;

                    int index=Comment.allcomments.Count-1;
                    Comment.allcomments[index].customer_comment = Customer.GetCustomer(data.Rows[i][5].ToString());
                   
                }
                for (int i = 0; i < Comment.allcomments.Count; i++)
                {
                    if (data.Rows[i][3].ToString() != "")
                    {
                        Comment.allcomments[i].reply = Comment.GetComment(int.Parse(data.Rows[i][3].ToString()));
                    }
                }
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warrning");
            }



            //#########################################################################################################
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                string command = "SELECT * from FoodTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    List<string> food_material = data.Rows[i][9].ToString().Split(',').ToList();
                    List<Comment> food_Comment= new List<Comment>();
                    string[] all_rating_stirng = data.Rows[i][4].ToString().Split(',');
                    List<int> all_rating = new List<int>();
                    for(int j=0;j<all_rating_stirng.Length;j++)
                    {
                        if (all_rating_stirng[j] == "")
                        {
                            break;
                        }
                        all_rating.Add(int.Parse(all_rating_stirng[j]));
                    }
                    string[] comment = data.Rows[i][6].ToString().Split(',');
                    for(int j=0;j< comment.Length; j++)
                    {
                        if (comment[j] == "")
                        {
                            break;
                        }
                        food_Comment.Add(Comment.GetComment(int.Parse(comment[j])));
                    }

                   Food.allFood.Add(new Food(int.Parse(data.Rows[i][0].ToString()),
                       data.Rows[i][1].ToString(),
                       double.Parse(data.Rows[i][2].ToString()),
                       double.Parse(data.Rows[i][3].ToString()),
                       int.Parse(data.Rows[i][5].ToString()),
                       food_Comment,
                       data.Rows[i][8].ToString(),
                       food_material));

                    int index = Food.allFood.Count - 1;
                    Food.allFood[index].allrating = all_rating;
                    Food.allFood[index].foodCategory = data.Rows[i][7].ToString();
                    List<Food> foods = Food.allFood;
                    
                }
                
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warrning");
            }



            //##################################################################
            
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                string command = "SELECT * from RestaurantTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    AdmissionType? at = AdmissionType.delivery;
                    string delivery_string = data.Rows[i][3].ToString();
                    if (data.Rows[i][3].ToString() == AdmissionType.delivery.ToString())
                    {
                        at=AdmissionType.delivery;
                    }
                    if (data.Rows[i][3].ToString() == AdmissionType.dine_in.ToString())
                    {
                        at=AdmissionType.dine_in;
                    }
                    else
                    {
                        at=null;
                    }
                    List<int> allrating = new List<int>();
                    string[] allrating_string = data.Rows[i][5].ToString().Split(',');
                    for(int j=0;j<allrating_string.Length;j++)
                    {
                        allrating.Add(int.Parse(allrating_string[j]));
                    }
                    Restaurant.allRestaurant.Add(new Restaurant(data.Rows[i][0].ToString(),
                        data.Rows[i][1].ToString(),
                        data.Rows[i][2].ToString(),
                        at,
                        data.Rows[i][4].ToString(),
                        allrating.Average(),
                        data.Rows[i][8].ToString(),
                        int.Parse(data.Rows[i][7].ToString())
                        ));

                    int index = Restaurant.allRestaurant.Count - 1;
                    Restaurant.allRestaurant[index].allrating=allrating;
                    List<Food> foods=new List<Food>();
                    string[] food_id = data.Rows[i][9].ToString().Split(',');
                    for(int j = 0; j < food_id.Length; j++)
                    {
                        if (food_id[j] == "")
                        {
                            break;
                        }
                        foods.Add(GetFood(int.Parse(food_id[j])));
                    }
                    Restaurant.allRestaurant[i].foods=foods;
                    Restaurant.allRestaurant[i].reserve = bool.Parse(data.Rows[i][11].ToString());
                    List<Restaurant> restaurants = Restaurant.allRestaurant;
                }

                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warrning");
            }

            //######################################################################
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                string command = "SELECT * from ComplaintTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Comment? admin_reply = null;
                    if (data.Rows[i][3].ToString() != "")
                    {
                        admin_reply = GetComment(int.Parse(data.Rows[i][3].ToString()));
                    }

                    Comment? customer_reply = null;
                    if (data.Rows[i][4].ToString() != "")
                    {
                        customer_reply = GetComment(int.Parse(data.Rows[i][4].ToString()));
                    }

                    Complaint.allComplaints.Add(new Complaint(int.Parse(data.Rows[i][0].ToString()),
                        data.Rows[i][7].ToString(),
                        Restaurant.GetRestaurant(data.Rows[i][1].ToString()),
                        Customer.GetCustomer(data.Rows[i][2].ToString()),admin_reply,
                        customer_reply, bool.Parse(data.Rows[i][5].ToString())
                        ));

                    int index = Complaint.allComplaints.Count - 1;
                    Complaint.allComplaints[index].CustomerComment.title = data.Rows[i][7].ToString();
                    //data.rows[i][6] not use

                }

                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warrning");
            }

            

            //#########################################################

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                string command = "SELECT * from RestaurantTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (data.Rows[i][10].ToString() == "")
                    {
                        continue;
                    }
                    Restaurant.allRestaurant[i].complaintNumber = int.Parse(data.Rows[i][10].ToString());
                }

                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warrning");
            }


            //###############################################################

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP_Project\AP_Project_4022\AP_Project_4022\db.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                string command = "SELECT * from OrderHistoryTable";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    OrderHistory.allOrderHistory.Add(new OrderHistory(Customer.GetCustomer(data.Rows[i][2].ToString()),
                        Restaurant.GetRestaurant(data.Rows[i][3].ToString()),
                        int.Parse(data.Rows[i][0].ToString()), GetComment(int.Parse(data.Rows[i][1].ToString())),
                        GetFood(int.Parse(data.Rows[i][7].ToString()))));
                    int index = OrderHistory.allOrderHistory.Count - 1;
                    OrderHistory.allOrderHistory[index].point = int.Parse(data.Rows[i][5].ToString());
                }

                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warrning");
            }



        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (usernameTextBox.Text == string.Empty || passwordTextBox.Password == string.Empty)
            {
                MessageBox.Show("no argument can be empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            for (int i = 0; i < Customer.allCustomers.Count; i++)
            {
                if (Customer.allCustomers[i].username == usernameTextBox.Text && Customer.allCustomers[i].password == passwordTextBox.Password)
                {
                    Customer.currentCustomer = Customer.allCustomers[i];
                    Customer.currentCustomer.customer_first_page = new customerFirstPage();
                    Customer.currentCustomer.customer_first_page.Show();
                    return;
                }
            }
            for (int i = 0; i < Restaurant.allRestaurant.Count; i++)
            {
                if (Restaurant.allRestaurant[i].userName == usernameTextBox.Text && Restaurant.allRestaurant[i].password == passwordTextBox.Password)
                {
                    Restaurant.currentRestaurant = Restaurant.allRestaurant[i];
                    return;
                }
            }
            for (int i = 0; i < Admin.allAdmin.Count; i++)
            {
                if (Admin.allAdmin[i].UserName == usernameTextBox.Text && Admin.allAdmin[i].Password == passwordTextBox.Password)
                {
                    Admin.CurrentAdmin = Admin.allAdmin[i];
                    Admin.CurrentAdmin.admin_Menu = new adminMenu();
                    Admin.CurrentAdmin.admin_Menu.Show();
                    return;
                }
            }
            MessageBox.Show("user not exists!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        private void SigninButton_Click(object sender, RoutedEventArgs e)
        {
            singinPage sp = new singinPage(); sp.Show();

        }

        
        public static Food? GetFood(int id)
        {
            for(int i = 0; i < Food.allFood.Count; i++)
            {
                if (Food.allFood[i].Id == id)
                {
                    return Food.allFood[i];
                }
            }
            return null;    
        }
        static Admin? GetAdmin(string username)
        {
            return Admin.allAdmin.Where(x=>x.UserName == username).FirstOrDefault();
        }
        public static Comment? GetComment(int id)
        {
            return Comment.allcomments.Where(x=>x.id == id).FirstOrDefault();
        }

        
    }
}