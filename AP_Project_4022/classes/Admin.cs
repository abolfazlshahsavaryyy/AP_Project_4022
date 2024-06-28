using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Class_Enum
{
    public class Admin
    {
        public string userName {  get; set; }
        public string password { get; set; }
        public Admin(string username,string password)
        {
            this.userName = username;
            this.password = password;
        }
    }
}
