using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Class_Enum
{
    public class Comment
    {
        public string content { get; set; }
        public string title { get; set; }
        public string reply {  get; set; }
        public DateTime dateComment { get; set; }//date of commenting
        public static List<Comment> comments = new List<Comment>();
        public Comment(string content, string title, string reply, DateTime dateComment)
        {
            this.content = content;
            this.title = title;
            this.reply = reply;
            this.dateComment = dateComment;
        }
    }
}
