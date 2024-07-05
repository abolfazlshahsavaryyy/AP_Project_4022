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
using AP_Project_4022.classes;
using AP_Project_4022.CustomerPage;

namespace AP_Project_4022.CustomerPage
{
    /// <summary>
    /// Interaction logic for restaurantMenuPage.xaml
    /// </summary>
    public partial class restaurantMenuPage : Window
    {
        public static Restaurant Restaurant_Menu { get; set; }
        public restaurantMenuPage()
        {
            InitializeComponent();

            
        }
        public void AddFoodMenu()
        {
            List<string> category = new List<string>();
            for(int i = 0; i < restaurantMenuPage.Restaurant_Menu.foods.Count; i++)
            {
                category.Add(restaurantMenuPage.Restaurant_Menu.foods[i].foodCategory);
            }
            category = category.Distinct().ToList();
            int categoryListNumber=category.Count;
            for (int i = 0; i < categoryListNumber; i++)
            {
                foodCategoryUserControl fcuc = new foodCategoryUserControl();
                for (int j = 0; j < restaurantMenuPage.Restaurant_Menu.foods.Count; j++)
                {
                    if (category[i] == restaurantMenuPage.Restaurant_Menu.foods[j].foodCategory)
                    {
                        Button btn = new Button
                        {
                            Content = restaurantMenuPage.Restaurant_Menu.foods[j].name+" "+ restaurantMenuPage.Restaurant_Menu.foods[j].numberFood,
                            Name= restaurantMenuPage.Restaurant_Menu.foods[j].name,
                            Height=18
                        };
                        btn.Click += foodButton_Click;
                        fcuc.foodListStackPanel.Children.Add(btn);
                        fcuc.foodCategoryLabel.Content = category[i];
                        fcuc.HorizontalAlignment = HorizontalAlignment.Center;
                    }


                }
                fcuc.Margin=new Thickness(categoryListNumber);
                menuStackPanel.Children.Add(fcuc);
            }
        }

        private void reserveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        
        private void foodButton_Click(object sender, RoutedEventArgs e)
        {
            Customer.currentCustomer.food_page = new foodPage();
            string name = (sender as Button).Name;
            Food click_food = Food.GetFood(name);
            click_food.foodComments = new List<Comment>
            {
                new Comment(1,"food comment content","title food comment",new Comment(),DateTime.Now),
                new Comment(2,"greate food amazing","good food",new Comment(),DateTime.Now),
                new Comment(3,"this wasney grear food for me","normal food",new Comment(),DateTime.Now),
                new Comment(4,"no to bad it was deluses but not good restaurant","good",new Comment(),DateTime.Now),
                new Comment(5,"amaginz food for me I remember my chieldhood time while I eat it","old food",new Comment(),DateTime.Now),
                new Comment(6,"I love it its amazing","amazing",new Comment(),DateTime.Now)


            };
            for(int i = 0; i < click_food.foodComments.Count; i++)
            {
                Comment.allcomments.Add(new Comment(click_food.foodComments[i].id, click_food.foodComments[i].content,
                    click_food.foodComments[i].title, new Comment(), click_food.foodComments[i].dateComment));
            }
            for(int i = 0; i < click_food.foodComments.Count; i++)
            {
                click_food.foodComments[i].customer_comment = Customer.currentCustomer;
            }
            List<Comment> food_comment = click_food.foodComments;
            for(int i=0;i<food_comment.Count;i++)
            {
                foodCommentUserControl fcuc = new foodCommentUserControl();
                fcuc.titleLabel.Content= food_comment[i].title;
                fcuc.ContentLabel.Content = food_comment[i].content;
                fcuc.Tag = food_comment[i].id;
                fcuc.replyButton.Click+= Customer.currentCustomer.food_page.replyButton_Click;
                fcuc.deleteButton.Click += Customer.currentCustomer.food_page.deleteButton_Click;
                fcuc.editButton.Click += Customer.currentCustomer.food_page.editButton_Click;
                fcuc.deleteButton.Tag = food_comment[i].id;
                fcuc.replyButton.Tag = food_comment[i].id;
                fcuc.dataTimeButton.Content = food_comment[i].dateComment;
                fcuc.usernameButton.Content = food_comment[i].customer_comment.username;

                fcuc.editButton.Tag = food_comment[i].id;
                fcuc.usernameButton.Content = food_comment[i].customer_comment.username;
                Customer.currentCustomer.food_page.commentFoodStackPanel.Children.Add(fcuc);
            }
            foodPage.current_food = click_food;
            Customer.currentCustomer.food_page.Show();
            
            
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
