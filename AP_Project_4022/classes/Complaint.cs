using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project_4022.classes
{
    public class Complaint
    {
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public Customer Customer { get; set; }
        public string AdminReply { get; set; }
        public Comment CustomerComment { get; set; }
        public string title {  get; set; }
        public bool IsCheck { get; set; }
        public string Title { get; set; }
        public static List<Complaint> allComplaints { get; set; }
        static Complaint()
        {
            allComplaints = new List<Complaint>();
        }
        public Complaint(int id, string title, Restaurant restaurant,  Customer customer,  string adminReply, Comment userMessage, bool isCheck)
        {
            Id = id;
            Title = title;
            Restaurant = restaurant;
            Customer = customer;
            AdminReply = adminReply;
            CustomerComment = userMessage;
            IsCheck = isCheck;
        }
        public bool IsComplaintExists(int id)
        {
            for(int i=0;i<allComplaints.Count;i++)
            {
                if (allComplaints[i].Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        public Complaint? GetComplaint(int id)
        {
            return allComplaints.Where(x=>x.Id == id).FirstOrDefault();
        }
    }
}
