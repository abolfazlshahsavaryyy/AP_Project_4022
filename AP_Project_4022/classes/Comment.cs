using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project_4022.classes
{
    public class Comment
    {
        public int id {  get; set; }//id for comment id 0
        public string content { get; set; }
        public string title { get; set; }
        public Comment reply { get; set; }
 //       public Customer customer_comment {  get; set; }
        public DateTime dateComment { get; set; }//date of commenting
        public static List<Comment> allcomments = new List<Comment>();
        public Comment()
        {

        }
        public Comment(int id,string content, string title, Comment reply, DateTime dateComment)
        {
            this.id = id;
            this.content = content;
            this.title = title;
            this.reply = reply;
            this.dateComment = dateComment;
        }
        public static Comment? GetComment(int id)
        {
            return allcomments.Where(x=>x.id == id).FirstOrDefault();
        }
        public static void Reply(int id_comment,string reply_content,string reply_title)
        {
            Comment.GetComment(id_comment).reply=new Comment(0,reply_content,reply_title,new Comment(),DateTime.Now);
        }
        public bool isCommentExists(int id)
        {
            for(int i=0;i<allcomments.Count;i++)
            {
                if (allcomments[i].id == id) return true;
            }
            return false;
        }
    }
}
