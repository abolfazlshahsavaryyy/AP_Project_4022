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
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace AP_Project_4022.CustomerPage
{
    /// <summary>
    /// Interaction logic for complaintPage.xaml
    /// </summary>
    public partial class complaintPage : Window
    {
        public complaintPage()
        {
            InitializeComponent();
        }

        private void addComplaintButton_Click(object sender, RoutedEventArgs e)
        {
            titleTextBox.Visibility=Visibility.Visible;
            titleLabel.Visibility=Visibility.Visible;
            descriptionLabel.Visibility=Visibility.Visible;
            discriptionTextBox.Visibility=Visibility.Visible;
            restaurantLebel.Visibility=Visibility.Visible;
            restayrantNameTextBox.Visibility=Visibility.Visible;
            submitButton.Visibility=Visibility.Visible;
            

        }
        static Restaurant? GetRestaurantByName(string name)
        {
            for (int i = 0; i < Restaurant.allRestaurant.Count; i++)
            {
                if (Restaurant.allRestaurant[i].name == name)
                {
                    return Restaurant.allRestaurant[i];
                }
            }
            return null;

        }
        static bool IsResturantExists(string name)
        {
            for(int i=0;i<Restaurant.allRestaurant.Count;i++)
            {
                if (Restaurant.allRestaurant[i].name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            if((sender as Button).Content == "verify")
            {
                for(int i=0;i<Complaint.allComplaints.Count;i++)
                {
                    if((int)(sender as Button).Tag == Complaint.allComplaints[i].Id)
                    {
                        MessageBox.Show(Complaint.allComplaints[i].AdminReply.content, "Admin reply");
                        return;
                    }
                }
            }
            return;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (titleTextBox.Text == string.Empty || discriptionTextBox.Text == string.Empty || restayrantNameTextBox.Text == string.Empty)
            {
                MessageBox.Show("error", "Warrning", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            if (!IsResturantExists(restayrantNameTextBox.Text))
            {
                MessageBox.Show("restaurant is not exists", "Warrning", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            if(Comment.allcomments.Count == 0)
            {
                Complaint.allComplaints.Add(new Complaint(Complaint.allComplaints[Complaint.allComplaints.Count - 1].Id + 1,titleTextBox.Text, GetRestaurantByName(restayrantNameTextBox.Text)
                , Customer.currentCustomer, new Comment(), new Comment(1, discriptionTextBox.Text,
                titleTextBox.Text, new Comment(), DateTime.Now), false));
                customerFirstPage.CreateComplaintPage();
                this.Close();
                MessageBox.Show("your complaint add");
                return;
            }
            if(Complaint.allComplaints.Count == 0)
            {
                Complaint.allComplaints.Add(new Complaint(1,titleTextBox.Text, GetRestaurantByName(restayrantNameTextBox.Text)
                , Customer.currentCustomer, new Comment(), new Comment(Comment.allcomments[Comment.allcomments.Count - 1].id + 1, discriptionTextBox.Text,
                titleTextBox.Text, new Comment(), DateTime.Now), false));
                customerFirstPage.CreateComplaintPage();
                this.Close();
                MessageBox.Show("your complaint add");return;
            }
            Complaint.allComplaints.Add(new Complaint(Complaint.allComplaints[Complaint.allComplaints.Count - 1].Id + 1,titleTextBox.Text, GetRestaurantByName(restayrantNameTextBox.Text)
                , Customer.currentCustomer, new Comment(), new Comment(Comment.allcomments[Comment.allcomments.Count - 1].id + 1, discriptionTextBox.Text,
                titleTextBox.Text, new Comment(), DateTime.Now), false));
            customerFirstPage.CreateComplaintPage();
            this.Close();
            MessageBox.Show("your complaint add");
        }
    }
}
