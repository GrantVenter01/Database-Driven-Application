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
    /// Interaction logic for frmstaff.xaml
    /// </summary>
    public partial class frmstaff : Window
    {
        public frmstaff()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            frmEmpCustomer cust = new frmEmpCustomer();
            cust.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frmSplashScreen splash = new frmSplashScreen();
            splash.Show();
            this.Close();
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            frmEmpOrder order = new frmEmpOrder();
            order.Show();
            this.Close();
        }
    }
}
