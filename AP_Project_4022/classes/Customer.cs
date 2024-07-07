using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
 using AP_Project_4022.CustomerPage;

namespace AP_Project_4022.classes
{
    public enum CustomerSpecialService
    {
        Golden,
        Silver,
        Bronze
    }
    public class Customer
    {
        public CustomerSpecialService? SpecialService { get; set; }
        public string username {  get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }//unique
        public string address { get; set; }
        public bool gender { get; set; }//male:true ,female:false
        public static List<Customer> allCustomers { get; set; }
        public static Customer? currentCustomer { get; set; }
        //####################################################################

        public complaintPage complaint_page { get; set; }
        public customerFirstPage customer_first_page { get; set; }
        public foodCommentPage food_comment_page { get; set; }
        public foodPage food_page { get; set; }
        public foodRatingPage food_rating_page { get; set; }
        public orderHistoryCommentpage order_history_comment_page { get; set; }
        public orderHistoryPage order_history_page { get; set; }
        public orderhistoryRatingPage order_history_rating_page { get; set; }
        public orderPageRestaurant order_page_restaurant { get; set; }
        public payPage pay_page { get; set; }
        public profilePage profile_page { get; set; }
        public restaurantMenuPage restaurant_menu_page { get; set; }
        public searchRestaurantPage search_restaurant_page { get; set; }
        public specialServicePage special_service_page { get; set; }

        //####################################################################

        static Customer()
        {
            allCustomers = new List<Customer>();
            allCustomers.Add(new Customer("ali", "reza", "abolfazlshahsavaryy@gmail.com", "password", "09901498364", "address",true,"customer"));
        }

        public Customer(string firstName, string lastName, string email, string password, string phoneNumber, string address, bool gender, string username) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.username = username;
            this.password = password;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.gender = gender;
            this.SpecialService = null;
        }
        public static void AddCustomer(Customer customer)
        {
            Customer.allCustomers.Add(customer);
        }
        public static Customer? GetCustomer(string username)
        {
            return Customer.allCustomers.Where(x=>x.username == username).FirstOrDefault();
        }
        public static bool IsUserExists(string username)
        {
            for (int i = 0; i < allCustomers.Count; i++)
            {
                if (allCustomers[i].username == username)
                {
                    return true;
                }
            }
            return false;
        }
        public static CustomerSpecialService? GetCustomerSpecialService(string specialType)
        {
            if (CustomerSpecialService.Golden.ToString() == specialType)
            {
                return CustomerSpecialService.Golden;
            }
            else if(CustomerSpecialService.Silver.ToString() == specialType)
            {
                return CustomerSpecialService.Silver;
            }
            else if(CustomerSpecialService.Bronze.ToString() == specialType)
            {
                return CustomerSpecialService.Bronze;
            }
            return null;
        }
    } 
}
