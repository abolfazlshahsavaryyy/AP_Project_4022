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
    /// Interaction logic for orderHistoryCommentpage.xaml
    /// </summary>
    public partial class orderHistoryCommentpage : Window
    {
        public static string comment="";
        public int id_comment;
        public orderHistoryCommentpage()
        {
            InitializeComponent();
        }

        private void AddCommentButyon_Click(object sender, RoutedEventArgs e)
        {
            if (commentContentTextBox.Text == string.Empty)
            {
                MessageBox.Show("comment can't be empty");
                return;
            }
            comment=commentContentTextBox.Text;
            for(int i = 0; i < OrderHistory.allOrderHistory.Count; i++)
            {
                if (OrderHistory.allOrderHistory[i].id== id_comment)
                {
                    OrderHistory.allOrderHistory[i].comment.content= comment;
                }
            }
            this.Close();
        }
    }
}
