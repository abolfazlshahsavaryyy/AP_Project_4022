using AP_Project_4022.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Mail;
using System.Net;

namespace AP_Project_4022.SigninPage
{
    /// <summary>
    /// Interaction logic for singinPage.xaml
    /// </summary>
    public partial class singinPage : Window
    {
        public static Customer? temporaryCustomer = null;
        public static int Verify_code_email = -1;
        public singinPage()
        {
            InitializeComponent();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            if(usernameTextBox.Text==string.Empty || emailTextBox.Text==string.Empty ||
                firstNameTextBox.Text==string.Empty || lastNameTextBox.Text==string.Empty||
                usernameTextBox.Text==string.Empty || phoneNumberTextBox.Text==string.Empty)
            {
                MessageBox.Show("no argument can be empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(!RegexValidation.ValidateName(usernameTextBox.Text))
            {
                MessageBox.Show("username format is incorrect!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(!RegexValidation.ValidateEmail(emailTextBox.Text))
            {
                MessageBox.Show("email format is incorrect!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(!RegexValidation.ValidateName(firstNameTextBox.Text) && !RegexValidation.ValidateName(lastNameTextBox.Text))
            {
                MessageBox.Show("name format is not correct!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!RegexValidation.ValidateMobileNumber(phoneNumberTextBox.Text))
            {
                MessageBox.Show("phone number format is not correct!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(Customer.IsUserExists(usernameTextBox.Text))
            {
                MessageBox.Show("customer is exists!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(IsCustomerPhoneNumberExists(phoneNumberTextBox.Text))
            {
                MessageBox.Show("phone number is exists!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            temporaryCustomer=new Customer(firstNameTextBox.Text, lastNameTextBox.Text,emailTextBox.Text,
                string.Empty,phoneNumberTextBox.Text,"",true,usernameTextBox.Text);
            try
            {
                string senderEmail = "approject4022@gmail.com";
                string appPassword = "rkzjrwjcraogcivz"; // 16-digit app password
                string receiverEmail = emailTextBox.Text;
                string subject = "Varify Email";
                Random r=new Random();
                Verify_code_email=r.Next()%90000+10000;
                string body =Verify_code_email.ToString();

                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(senderEmail);
                mail.To.Add(receiverEmail);
                mail.Subject = subject;
                mail.Body = body;

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential(senderEmail, appPassword);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }
            verifyEmailPage vep = new verifyEmailPage();
            vep.Show();
        }
        static bool IsCustomerPhoneNumberExists(string phoneNumber)
        {
            for(int i=0;i<Customer.allCustomers.Count;i++)
            {
                if (Customer.allCustomers[i].phoneNumber == phoneNumber) return true;
            }
            return false;
        }
    }
}
