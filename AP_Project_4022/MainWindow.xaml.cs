using AP_Project_4022.AdminPages;
using AP_Project_4022.classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AP_Project_4022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Admin.CurrentAdmin = Admin.allAdmin[0];
            adminMenu adminMenu = new adminMenu();
            adminMenu.Show();
        }

        private void SigninButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}