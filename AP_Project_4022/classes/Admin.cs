using AP_Project_4022.AdminPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project_4022.classes
{
    public class Admin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public static List<Admin> allAdmin=new List<Admin>();
        public static Admin? CurrentAdmin { get; set; }
        //########################################################################

        public adminMenu admin_Menu { get; set; }
        public CheckComplaint Check_Complaint { get; set; }
        public searchAmmongComplaints search_Ammong_Complaints { get; set; }
        public searchAmongRestaurants search_Among_Restaurants { get; set; }
        public showAllComplaints show_All_Complaints { get; set; }
        public showSearchComplaints show_Search_Complaints { get; set; }
        public showSerachRestaurant show_Serach_Restaurant { get; set; }
        public showUncheckedComplaints show_Un_checked_Complaints { get; set; }

        //########################################################################
        public Admin(string userName, string password)
        {
            UserName = userName;
            Password = password;
            
        }
        static Admin()
        {
            allAdmin=new List<Admin>();
            allAdmin.Add(new Admin("abolfazl", "1383"));
            allAdmin.Add(new Admin("sepehr", "1384"));
        }
        public Admin? GetAdmin(string username)
        {
            return allAdmin.Where(x=>x.UserName==username).FirstOrDefault();
        }
        public static bool IsAdminExists(string username)
        {
            for(int i=0;i<allAdmin.Count;i++)
            {
                if (allAdmin[i].UserName==username) return true;
            }
            return false;
        }
    }
}
