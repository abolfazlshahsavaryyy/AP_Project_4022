using AP_Project_4022.classes;
using AP_Project_4022.SigninPage;
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
using AP_Project_4022.CustomerPage;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace AP_Project_4022.CustomerPage
{
    /// <summary>
    /// Interaction logic for orderHistoryPage.xaml
    /// </summary>
    public partial class orderHistoryPage : Window
    {
        public orderHistoryPage()
        {
            InitializeComponent();
        }
        public void commentButton_Click(object sender, RoutedEventArgs e)
        {

            orderHistoryCommentpage ohcp = new orderHistoryCommentpage();
            ohcp.id_comment = (int)(sender as Button).Tag;
            ohcp.ShowDialog();
            
            customerFirstPage.CreateStackPanelOrderHistory();
            this.Close();
        }
        
        public void ratingButton_Click(object sender, RoutedEventArgs e)
        {
            orderhistoryRatingPage ohrp = new orderhistoryRatingPage();
            ohrp.id_comment = (int)(sender as Button).Tag;
            ohrp.ShowDialog();

            customerFirstPage.CreateStackPanelOrderHistory();
            this.Close();
        }
    }
}
