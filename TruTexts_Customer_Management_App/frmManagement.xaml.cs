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

namespace TruTexts_Customer_Management_App
{
    /// <summary>
    /// Interaction logic for frmManagement.xaml
    /// </summary>
    public partial class frmManagement : Window
    {
        public frmManagement()
        {
            InitializeComponent();
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            frmOrders order = new frmOrders();
            order.Show();
            this.Close();
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            frmEmployees employ = new frmEmployees();
            employ.Show();
            this.Close();
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            frmCustomers cust = new frmCustomers();
            cust.Show();
            this.Close();
        }

        private void btnBooks_Click(object sender, RoutedEventArgs e)
        {
            frmBooks book = new frmBooks();
            book.Show();
            this.Close();
        }

        private void btnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            frmSuppliers supp = new frmSuppliers();
            supp.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frmSplashScreen splash = new frmSplashScreen();
            splash.Show();
            this.Close();
        }
    }
}
