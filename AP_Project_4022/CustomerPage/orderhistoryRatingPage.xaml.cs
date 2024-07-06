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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace AP_Project_4022.CustomerPage
{
    /// <summary>
    /// Interaction logic for orderhistoryRatingPage.xaml
    /// </summary>
    public partial class orderhistoryRatingPage : Window
    {
        public int id_comment;
        public orderhistoryRatingPage()
        {
            InitializeComponent();
        }

        private void AddCommentButyon_Click(object sender, RoutedEventArgs e)
        {
            if (commentContentTextBox.Text == string.Empty)
            {
                MessageBox.Show("rating can't be empty");
                return;
            }
            try
            {
                int.Parse(commentContentTextBox.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("rating cant be alphabet char");
                return;
            }
            for(int i = 0; i < OrderHistory.allOrderHistory.Count; i++)
            {
                if (OrderHistory.allOrderHistory[i].id == id_comment)
                {
                    OrderHistory.allOrderHistory[i].point = int.Parse(commentContentTextBox.Text);
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("unknown problem !");
            this.Close();
        }
    }
}
