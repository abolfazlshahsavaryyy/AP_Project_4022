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
using AP_Project_4022.classes;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace AP_Project_4022.CustomerPage
{
    
    /// <summary>
    /// Interaction logic for customerFirstPage.xaml
    /// </summary>
    public partial class customerFirstPage : Window
    {
        public customerFirstPage()
        {
            InitializeComponent();
        }

        private void profileButton_Click(object sender, RoutedEventArgs e)
        {
            Customer.currentCustomer.profile_page=new profilePage();
            Customer.currentCustomer.profile_page.Show();
        }

        private void searchRestaurantButton_Click(object sender, RoutedEventArgs e)
        {
            Customer.currentCustomer.search_restaurant_page=new searchRestaurantPage();
            Customer.currentCustomer.search_restaurant_page.filter();
            Customer.currentCustomer.search_restaurant_page.AddButtonsToStackPanel();
            Customer.currentCustomer.search_restaurant_page.Show();
        }

        private void orderhistoryButton_Click(object sender, RoutedEventArgs e)
        {
            
            Customer.currentCustomer.order_history_page=new orderHistoryPage();
            for(int i=0;i<OrderHistory.allOrderHistory.Count;i++)
            {
                if (OrderHistory.allOrderHistory[i].customer == Customer.currentCustomer)
                {
                    orderHistoryUserControl ohuc = new orderHistoryUserControl();
                    ohuc.commentButton.Click += Customer.currentCustomer.order_history_page.commentButton_Click;
                    ohuc.ratingButton.Click += Customer.currentCustomer.order_history_page.ratingButton_Click;
                    ohuc.foodNameLabel.Content = OrderHistory.allOrderHistory[i].food.name;
                    ohuc.restaurantLabel.Content = OrderHistory.allOrderHistory[i].restaurant.name;
                    ohuc.Tag = OrderHistory.allOrderHistory[i].id;
                    ohuc.ratingButton.Tag = OrderHistory.allOrderHistory[i].id;
                    ohuc.commentButton.Tag = OrderHistory.allOrderHistory[i].id;
                    Customer.currentCustomer.order_history_page.orderHistoryStackPanel.Children.Add(ohuc);
                }


            }
            Customer.currentCustomer.order_history_page.Show();
            
        }
        public static void CreateStackPanelOrderHistory()
        {
            Customer.currentCustomer.order_history_page = new orderHistoryPage();
            for (int i = 0; i < OrderHistory.allOrderHistory.Count; i++)
            {
                if (OrderHistory.allOrderHistory[i].customer == Customer.currentCustomer)
                {
                    orderHistoryUserControl ohuc = new orderHistoryUserControl();
                    ohuc.commentButton.Click += Customer.currentCustomer.order_history_page.commentButton_Click;
                    ohuc.ratingButton.Click += Customer.currentCustomer.order_history_page.ratingButton_Click;
                    ohuc.foodNameLabel.Content = OrderHistory.allOrderHistory[i].food.name;
                    ohuc.restaurantLabel.Content = OrderHistory.allOrderHistory[i].restaurant.name;
                    ohuc.Tag = OrderHistory.allOrderHistory[i].id;
                    ohuc.ratingButton.Tag = OrderHistory.allOrderHistory[i].id;
                    ohuc.commentButton.Tag = OrderHistory.allOrderHistory[i].id;
                    ohuc.commentOrderHistoryLabel.Content = OrderHistory.allOrderHistory[i].comment.content;
                    ohuc.ratingButton.Content = OrderHistory.allOrderHistory[i].point;
                    Customer.currentCustomer.order_history_page.orderHistoryStackPanel.Children.Add(ohuc);
                }


            }
            Customer.currentCustomer.order_history_page.Show();

        }

        private void compaintButton_Click(object sender, RoutedEventArgs e)
        {
            

            CreateComplaintPage();
            Customer.currentCustomer.complaint_page.Show();
        }
        public static void CreateComplaintPage()
        {
            Customer.currentCustomer.complaint_page= new complaintPage();
            for(int i=0;i<Complaint.allComplaints.Count;i++)
            {
                complaintUserControl cuc=new complaintUserControl();
                cuc.restaurantNameLabel.Content = Complaint.allComplaints[i].Restaurant.name;
                if (Complaint.allComplaints[i].IsCheck == false)
                {
                    cuc.verifyButton.Content = "no verify";
                }
                else
                {
                    cuc.verifyButton.Content = "verify";
                }
                cuc.contentCommentLabel.Content = Complaint.allComplaints[i].CustomerComment.content;
                cuc.titleCommentLabel.Content = Complaint.allComplaints[i].CustomerComment.title;
                cuc.verifyButton.Click += Customer.currentCustomer.complaint_page.VerifyButton_Click;
                cuc.verifyButton.Tag = Complaint.allComplaints[i].Id;
                
                Customer.currentCustomer.complaint_page.complaintStackPanel.Children.Add(cuc);
            }
        }
    }
}
