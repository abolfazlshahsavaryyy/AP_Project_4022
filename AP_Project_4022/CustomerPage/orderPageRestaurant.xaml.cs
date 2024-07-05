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
    /// Interaction logic for orderPageRestaurant.xaml
    /// </summary>
    public partial class orderPageRestaurant : Window
    {
        public static double price;
        public orderPageRestaurant()
        {
            InitializeComponent();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {

            int number_food=0;
            try
            {
                number_food = int.Parse(numberFoodTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                numberFoodTextBox.Text = string.Empty;
                return;
            }
            if (foodPage.current_food.numberFood < number_food)
            {

            }
            price=number_food*foodPage.current_food.price;
            payPage pp=new payPage();
            pp.Show();
            this.Close();
        }
    }
}
