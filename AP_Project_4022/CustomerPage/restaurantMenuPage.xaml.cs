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
                            Name= restaurantMenuPage.Restaurant_Menu.foods[j].name
                            ,Height=18
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

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void foodButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
