using AP_Project_4022.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
    /// Interaction logic for onlinePaySimiulate.xaml
    /// </summary>
    public partial class onlinePaySimiulate : Window
    {
        public int code = 0;
        public onlinePaySimiulate()
        {
            InitializeComponent();
            try
            {

                string senderEmail = "approject4022@gmail.com";
                string appPassword = "rkzjrwjcraogcivz"; // 16-digit app password
                string receiverEmail = Customer.currentCustomer.email;
                string subject = "Online Pay ";
                Random r = new Random();
                code = r.Next() % 90000 + 10000;
                string body = code.ToString();

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
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            
           
            if (bankTextBox.Text.Length != 16)
            {
                MessageBox.Show("bank probelm!", "warrning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(emailCodeTextBox.Text !=code.ToString())
            {
                MessageBox.Show("code incorrect!", "warrning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (specialServicePage.check == 1)
            {
                Customer.currentCustomer.SpecialService = CustomerSpecialService.Golden;
                specialServicePage.check = 0;
                MessageBox.Show("Golden Customer");
                this.Close(); return;
            }
            if (specialServicePage.check == 2)
            {
                Customer.currentCustomer.SpecialService = CustomerSpecialService.Silver;
                specialServicePage.check = 0;
                MessageBox.Show("silver Customer"); this.Close(); return;
            }
            if (specialServicePage.check == 3)
            {
                Customer.currentCustomer.SpecialService = CustomerSpecialService.Bronze;
                specialServicePage.check = 0;
                MessageBox.Show("bronze Customer"); this.Close();
                return;
            }
            if (orderPageRestaurant.price > 0)
            {
                
                MessageBox.Show("your food price is: "+orderPageRestaurant.price.ToString());
                orderPageRestaurant.price = -1;
                return;
            }
            if (reservePage.table_want > 0)
            {
                MessageBox.Show($"reserve {reservePage.table_want} ");
                reservePage.table_want = -1;
                return;
            }

        }
    }
}
