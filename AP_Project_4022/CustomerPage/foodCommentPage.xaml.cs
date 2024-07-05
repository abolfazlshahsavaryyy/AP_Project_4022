using AP_Project_4022.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AP_Project_4022.CustomerPage
{
    /// <summary>
    /// Interaction logic for foodCommentPage.xaml
    /// </summary>
    public partial class foodCommentPage : Window
    {
        public int comment_id;
        public bool is_edit;
        public bool is_reply;
        public foodCommentPage()
        {
            InitializeComponent();
        }

        private void addCommentButton_Click(object sender, RoutedEventArgs e)
        {
            if(is_edit)
            {
                
                Comment replyToComment=Comment.GetComment(comment_id);
                replyToComment.title=titleCommentTextBox.Text;
                replyToComment.content=contentCommentTextBox.Text;
                foodPage.CreateFoodPage();
                this.Close();
            }
            else if(is_reply)
            {
                Comment replyToComment = Comment.GetComment(comment_id);
                replyToComment.reply.title = titleCommentTextBox.Text;
                replyToComment.reply.title = contentCommentTextBox.Text;
                foodPage.CreateFoodPage();
                this.Close();

            }
        }
    }
}
