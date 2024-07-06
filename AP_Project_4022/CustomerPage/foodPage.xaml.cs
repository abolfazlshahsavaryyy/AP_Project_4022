using AP_Project_4022.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace AP_Project_4022.CustomerPage
{
    /// <summary>
    /// Interaction logic for foodPage.xaml
    /// </summary>
    public partial class foodPage : Window
    {
        public static Food current_food;
        public foodPage()
        {
            InitializeComponent();
        }
        private void AddClick()
        {

        }
        private void commentButton_Click(object sender, RoutedEventArgs e)
        {
            Customer.currentCustomer.food_comment_page=new foodCommentPage();
            Customer.currentCustomer.food_comment_page.Show();
        }

        private void ratingButton_Click(object sender, RoutedEventArgs e)
        {

        }
        public void replyButton_Click(object sender, RoutedEventArgs e)
        {
            foodCommentPage fcp = new foodCommentPage();
            fcp.comment_id = (int)(sender as Button).Tag;
            fcp.is_reply = true;
            fcp.Show();
            this.Close();

        }
        public void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for(int i=0;i<foodPage.current_food.foodComments.Count;i++)
                {
                    if((int)(sender as Button).Tag == foodPage.current_food.foodComments[i].id)
                    {
                        current_food.foodComments.Remove(foodPage.current_food.foodComments[i]);
                        foodPage.CreateFoodPage();
                        this.Close();
                        return;
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("cant delete comment");
            }
            MessageBox.Show("cant delete comment");


        }
        public void editButton_Click(object sender, RoutedEventArgs e)
        {
            Customer comment_Customer = null;
            for(int i = 0; i < Comment.allcomments.Count; i++)
            {
                if((int)(sender as Button).Tag == Comment.allcomments[i].id)
                {
                    comment_Customer = Comment.allcomments[i].customer_comment;
                    break;
                }
            }
            if(comment_Customer != Customer.currentCustomer)
            {
                MessageBox.Show("only this user can edit comment");
                return;
            }
            foodCommentPage fcp=new foodCommentPage();
            fcp.comment_id = (int)(sender as Button).Tag;
            fcp.is_edit = true;
            fcp.Show();
            this.Close();
        }
        public static void CreateFoodPage()
        {
            Customer.currentCustomer.food_page = new foodPage();
            List<Comment> food_comment = foodPage.current_food.foodComments;
            for (int i = 0; i < foodPage.current_food.foodComments.Count; i++)
            {
                foodCommentUserControl fcuc = new foodCommentUserControl();
                fcuc.titleLabel.Content = food_comment[i].title;
                fcuc.ContentLabel.Content = food_comment[i].content;
                fcuc.Tag = food_comment[i].id;
                fcuc.deleteButton.Tag = food_comment[i].id;
                fcuc.replyButton.Tag = food_comment[i].id;
                fcuc.editButton.Tag = food_comment[i].id;
                fcuc.usernameButton.Content = food_comment[i].customer_comment.username;
                fcuc.dataTimeButton.Content = food_comment[i].dateComment;
                fcuc.replyButton.Click += Customer.currentCustomer.food_page.replyButton_Click;
                fcuc.deleteButton.Click += Customer.currentCustomer.food_page.deleteButton_Click;
                fcuc.editButton.Click += Customer.currentCustomer.food_page.editButton_Click;
                fcuc.usernameButton.Content = food_comment[i].customer_comment.username;
                Customer.currentCustomer.food_page.commentFoodStackPanel.Children.Add(fcuc);
                
            }
            Customer.currentCustomer.food_page.Show();
        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            Customer.currentCustomer.order_page_restaurant = new orderPageRestaurant();
            Customer.currentCustomer.order_page_restaurant.nameFoodLabel.Content="food name: "+foodPage.current_food.name;
            Customer.currentCustomer.order_page_restaurant.priceFoodLabel.Content = "food price: " + foodPage.current_food.price;
            Customer.currentCustomer.order_page_restaurant.numberFoodLabel.Content= "food number: " + foodPage.current_food.numberFood.ToString();
            Customer.currentCustomer.order_page_restaurant.categoryLabel.Content = "food category: " + foodPage.current_food.foodCategory;
            Customer.currentCustomer.order_page_restaurant.Show();



        }
    }
}
