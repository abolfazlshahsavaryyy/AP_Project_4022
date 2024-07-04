using AP_Project_4022.classes;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection.Emit;
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
    /// Interaction logic for profilePage.xaml
    /// </summary>
    public partial class profilePage : Window
    {
        public profilePage()
        {
            InitializeComponent();
            AddInfoToStackPanel();
        }
        public void AddInfoToStackPanel()
        {
            //for (int i = 1; i <= 10; i++)
            //{
            //    Label label = new Label
            //    {
            //        Content = $"Label {i}",
            //        Margin = new Thickness(5)
            //    };
            //    customerInformationStackPanel.Children.Add(label);
            //}
            Label l1 = new Label
            {
                Content = $"first name: {Customer.currentCustomer.firstName}",
                Margin = new Thickness(7)

            };
            Label l2 = new Label
            {
                Content = $"last name: {Customer.currentCustomer.lastName}",
                Margin = new Thickness(7)
            };
            Label l3 = new Label
            {
                Content = $"username: {Customer.currentCustomer.username}",
                Margin = new Thickness(7)
            };
            Label l4 = new Label
            {
                Content = $"phone number: {Customer.currentCustomer.phoneNumber}",
                Margin = new Thickness(7)
            };
            Label l5 = new Label
            {
                Content = $"address: {Customer.currentCustomer.address}",
                Margin = new Thickness(7)
            };
            string gender;
            if (Customer.currentCustomer.gender == true)
            {
                gender = "mail";
            }
            else
            {
                gender = "femail";
            }
            Label l6 = new Label
            {
                Content = $"gender: {gender}",
                Margin = new Thickness(7)
            };
            Label l7 = new Label
            {
                Content = $"email: {Customer.currentCustomer.email}",
                Margin = new Thickness(7)
            };
            customerInformationStackPanel.Children.Add(l1);
            customerInformationStackPanel.Children.Add(l2);
            customerInformationStackPanel.Children.Add(l3);
            customerInformationStackPanel.Children.Add(l4);
            customerInformationStackPanel.Children.Add(l5);
            
            customerInformationStackPanel.Children.Add(l6);
            customerInformationStackPanel.Children.Add(l7);



        }
        

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            emailLabel.Visibility = Visibility.Visible;
            addressLabel.Visibility = Visibility.Visible;
            emailTextBox.Visibility = Visibility.Visible;
            addrressTextBox.Visibility = Visibility.Visible;
            changeButton.Visibility = Visibility.Visible;
        }

        private void specialServiceButton_Click(object sender, RoutedEventArgs e)
        {
            Customer.currentCustomer.special_service_page=new specialServicePage();
            Customer.currentCustomer.special_service_page.Show();
        }
        
        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            string change_email=emailTextBox.Text.Trim();
            if(RegexValidation.ValidateEmail(emailTextBox.Text))
            {
                Customer.currentCustomer.email=emailTextBox.Text;
            }
            else
            {
                MessageBox.Show("no good format for email","Warrning",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            Customer.currentCustomer.address=addrressTextBox.Text;
            profilePage pp=new profilePage();
            this.Close();
            pp.Show();
        }
    }
}
