using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Class_Enum
{
    public class User
    {
        public string firstName {  get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNumber {  get; set; }//unique
        public string address {  get; set; }
        public bool gender {  get; set; }//male:true ,female:false
        public string username {  get; set; }//unique
        public User(string firstName, string lastName, string email, string password, string phoneNumber, string address, bool gender, string username)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.gender = gender;
            this.username = username;
        }
    }
}
