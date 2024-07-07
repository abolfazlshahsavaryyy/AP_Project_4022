using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project_4022.classes
{
    class OrderHistory
    {
        public int id;
        public Comment comment { get; set; }
        public Customer customer { get; set; }
        public Food food { get; set; }
        public Restaurant restaurant { get; set; }
        static int number_orderHistory=0;
        public int point { get; set; }
        public static List<OrderHistory> allOrderHistory { get; set; }
        static OrderHistory()
        {
            allOrderHistory = new List<OrderHistory>();
        }
        public OrderHistory(Customer customer, Restaurant restaurant,Food food)
        {
            this.customer = customer;
            this.restaurant = restaurant;
            this.point = 0;
            this.comment = new Comment();
            number_orderHistory++;
            this.id = number_orderHistory;
        }
        public OrderHistory(Customer customer, Restaurant restaurant,int id,Comment comment,Food food)
        {
            this.customer = customer;
            this.restaurant= restaurant;
            this.id = id;
            this.comment = comment;

        }
        public static OrderHistory? GetOrderHistory(int id)
        {
            return allOrderHistory.Where(x=>x.id == id).FirstOrDefault();
        }
        public bool isOrderHistoryExists(int id)
        {
            if (id > number_orderHistory)
            {
                return false;
            }
            return true;
        }
    }
    
}
