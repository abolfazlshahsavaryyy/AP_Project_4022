using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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
        static Customer()
        {
            allCustomers = new List<Customer>();
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
