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
    /// Interaction logic for payPage.xaml
    /// </summary>
    public partial class payPage : Window
    {
        public payPage()
        {
            InitializeComponent();
        }

        private void bayButton_Click(object sender, RoutedEventArgs e)
        {
            if(onlineCheckBox.IsChecked == true)
            {
                onlinePaySimiulate ops=new onlinePaySimiulate();
                ops.titleLabel.Content ="price of buy: "+ orderPageRestaurant.price.ToString();
                ops.Show();
                this.Close();
            }
            if(cashCheckBox.IsChecked == true)
            {
                MessageBox.Show("your order record");
                this.Close();
            }
        }
    }
}
