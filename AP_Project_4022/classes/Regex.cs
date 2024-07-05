using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AP_Project_4022.classes
{
    public class RegexValidation
    {
        public static bool ValidateCustomerPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,32}$";
;
            return Regex.IsMatch(password, pattern);
        }
        public static bool ValidateName(string name)
        {
            if (name.Length < 3 || name.Length > 32)
                return false;
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }
        public static bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z]{3,32}@[a-zA-Z]{3,32}\.[a-zA-Z]{2,3}$";
            return Regex.IsMatch(email, pattern);
        }
        public static bool ValidateMobileNumber(string mobileNumber)
        {
            return Regex.IsMatch(mobileNumber, @"^09\d{9}$");
        }
        public static string RandomPaswordRestaurant()
        {
            string temp = "";
            for (int i = 0; i < 8; i++)
            {
                Random r = new Random();
                int num=r.Next()%9+1;
                temp+=num.ToString();
            }
            return temp;
            
        }
    }
}
