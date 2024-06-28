using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Class_Enum
{
    public class OrderHistory
    {
        public Comment Comment { get; set; }
        public int point {  get; set; }
        public static List<OrderHistory>? List { get; set;}
        public OrderHistory(Comment comment, int point)
        {
            Comment = comment;
            this.point = point;
        }
    }
}
