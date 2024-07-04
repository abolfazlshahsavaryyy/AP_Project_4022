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
                // Create a new MailMessage object
                MailMessage mail = new MailMessage();

                // Set the sender's address (your email)
                mail.From = new MailAddress("abolfazlshahsavaryy@gmail.com");

                // Set the recipient's address
                mail.To.Add(emailTextBox.Text);

                // Set the subject
                mail.Subject = "verify code";

                // Set the body of the email
                Random random = new Random();
                Verify_code_email= random.Next()%9000+1000;
                mail.Body = Verify_code_email.ToString();

                // Specify the SMTP server (this example uses Gmail's SMTP server)
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                smtpServer.Port = 587; // Gmail uses port 587 for SMTP
                smtpServer.Credentials = new NetworkCredential("approject4022@gmail.com", "402approject#$#ABC");
                smtpServer.EnableSsl = true; // Enable SSL for security

                // Send the email
                //smtpServer.Send(mail);
                MessageBox.Show(Verify_code_email.ToString());

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("unknown error!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
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
