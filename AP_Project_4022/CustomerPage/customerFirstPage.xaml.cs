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
            OrderHistory.allOrderHistory.Add(new OrderHistory(Customer.currentCustomer, Restaurant.allRestaurant[0]));//delete this
            OrderHistory.allOrderHistory.Add(new OrderHistory(Customer.currentCustomer, Restaurant.allRestaurant[0]));//delete this
            OrderHistory.allOrderHistory[0].food = new Food("food1",12,1,2,new List<Comment>(),"",new List<string>());//delete
            OrderHistory.allOrderHistory[1].food = new Food("food2", 12, 1, 2, new List<Comment>(), "", new List<string>());//delete
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
            Customer.currentCustomer.complaint_page=new complaintPage();
            Customer.currentCustomer.complaint_page.Show();
        }
    }
}
