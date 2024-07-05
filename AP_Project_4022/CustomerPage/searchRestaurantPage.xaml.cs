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
    /// Interaction logic for searchRestaurantPage.xaml
    /// </summary>
    public partial class searchRestaurantPage : Window
    {
        List<Restaurant> restaurants;
        public searchRestaurantPage()
        {
            InitializeComponent();
           
            
        }
        public void filter()
        {
            if (minAvgRatingCheckBox.IsChecked == false)
            {
                if (cityTextBox.Text == string.Empty && restauranttextBox.Text == string.Empty && dineinCheckBoc.IsChecked == false && deliveryChechBox.IsChecked == false)
                {
                    this.restaurants = Restaurant.allRestaurant;
                }
                if (cityTextBox.Text != string.Empty && restauranttextBox.Text == string.Empty && dineinCheckBoc.IsChecked == false && deliveryChechBox.IsChecked == false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.city == cityTextBox.Text).ToList();
                }
                if (cityTextBox.Text == string.Empty && restauranttextBox.Text != string.Empty && dineinCheckBoc.IsChecked == false && deliveryChechBox.IsChecked == false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.name == restauranttextBox.Text).ToList();
                }
                if (cityTextBox.Text == string.Empty && restauranttextBox.Text == string.Empty && dineinCheckBoc.IsChecked != false && deliveryChechBox.IsChecked == false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.admissionType == AdmissionType.dine_in).ToList();
                }
                if (cityTextBox.Text == string.Empty && restauranttextBox.Text == string.Empty && dineinCheckBoc.IsChecked == false && deliveryChechBox.IsChecked != false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.admissionType == AdmissionType.delivery).ToList();
                }
                if (cityTextBox.Text != string.Empty && restauranttextBox.Text != string.Empty && dineinCheckBoc.IsChecked == false && deliveryChechBox.IsChecked == false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.name == restauranttextBox.Text).ToList().Where(x => x.city == cityTextBox.Text).ToList();
                }
                if (cityTextBox.Text != string.Empty && restauranttextBox.Text == string.Empty && dineinCheckBoc.IsChecked != false && deliveryChechBox.IsChecked == false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.city == cityTextBox.Text).Where(x => x.admissionType == AdmissionType.dine_in).ToList();
                }
                if (cityTextBox.Text != string.Empty && restauranttextBox.Text == string.Empty && dineinCheckBoc.IsChecked == false && deliveryChechBox.IsChecked != false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.city == cityTextBox.Text).Where(x => x.admissionType == AdmissionType.delivery).ToList();
                }
                if (cityTextBox.Text == string.Empty && restauranttextBox.Text != string.Empty && dineinCheckBoc.IsChecked != false && deliveryChechBox.IsChecked == false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.name == restauranttextBox.Text).Where(x => x.admissionType == AdmissionType.dine_in).ToList();
                }
                if (cityTextBox.Text == string.Empty && restauranttextBox.Text != string.Empty && dineinCheckBoc.IsChecked == false && deliveryChechBox.IsChecked != false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.name == restauranttextBox.Text).Where(x => x.admissionType == AdmissionType.delivery).ToList();
                }
                if (cityTextBox.Text == string.Empty && restauranttextBox.Text == string.Empty && dineinCheckBoc.IsChecked != false && deliveryChechBox.IsChecked != false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.admissionType == null).ToList();
                }
                if (cityTextBox.Text != string.Empty && restauranttextBox.Text != string.Empty && dineinCheckBoc.IsChecked != false && deliveryChechBox.IsChecked == false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.name == restauranttextBox.Text).Where(x => x.city == cityTextBox.Text).Where(x => x.admissionType == AdmissionType.dine_in).ToList();
                }
                if (cityTextBox.Text != string.Empty && restauranttextBox.Text != string.Empty && dineinCheckBoc.IsChecked == false && deliveryChechBox.IsChecked != false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.name == restauranttextBox.Text).Where(x => x.city == cityTextBox.Text).Where(x => x.admissionType == AdmissionType.delivery).ToList();
                }
                if (cityTextBox.Text != string.Empty && restauranttextBox.Text == string.Empty && dineinCheckBoc.IsChecked != false && deliveryChechBox.IsChecked != false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.city == cityTextBox.Text).Where(x => x.admissionType == null).ToList();
                }
                if (cityTextBox.Text == string.Empty && restauranttextBox.Text != string.Empty && dineinCheckBoc.IsChecked != false && deliveryChechBox.IsChecked != false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.admissionType == null).Where(x => x.name == restauranttextBox.Text).ToList();
                }
                if (cityTextBox.Text != string.Empty && restauranttextBox.Text != string.Empty && dineinCheckBoc.IsChecked != false && deliveryChechBox.IsChecked != false)
                {
                    this.restaurants = Restaurant.allRestaurant.Where(x => x.name == restauranttextBox.Text).Where(x => x.city == cityTextBox.Text).Where(x => x.admissionType == null).ToList();
                }
            }
            else
            {
                List<double> point = Restaurant.allRestaurant.Select(x => x.averagePoint).ToList();
                point.Sort();
                this.restaurants = Restaurant.allRestaurant.Where(x => x.averagePoint == point[0]).ToList();
            }
        }
        public void AddButtonsToStackPanel()
        {

            int numberOfButtons = -1;
            
           

            for (int i = 0; i < this.restaurants.Count; i++)
            {
                Button button = new Button
                {
                    Content = $"{this.restaurants[i].name} | {this.restaurants[i].city} | {this.restaurants[i].adress} ",
                    Margin = new Thickness(5),
                    Name = this.restaurants[i].userName
                    
                };
                button.Click += restaurantButton_Click;

                restaurantListStackPanel.Children.Add(button);
            }

        }
        


        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            restaurantListStackPanel.Children.Clear();
            searchRestaurantPage srp = new searchRestaurantPage();
            srp.cityTextBox.Text = cityTextBox.Text;
            srp.restauranttextBox.Text= restauranttextBox.Text;
            srp.dineinCheckBoc.IsChecked=dineinCheckBoc.IsChecked;
            srp.deliveryChechBox.IsChecked = deliveryChechBox.IsChecked;
            srp.minAvgRatingCheckBox.IsChecked = minAvgRatingCheckBox.IsChecked;
            srp.filter();
            srp.AddButtonsToStackPanel();
            srp.Show();
            this.Close();
           
        }

        private void restaurantButton_Click(object sender, RoutedEventArgs e)
        {
            restaurantMenuPage rmp =new restaurantMenuPage();
            restaurantMenuPage.Restaurant_Menu = Restaurant.GetRestaurant((sender as Button).Name);
            rmp.AddFoodMenu();
            rmp.Show();
        }
    }
}
