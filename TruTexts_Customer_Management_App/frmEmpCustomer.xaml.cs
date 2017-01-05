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
using TruTexts_Customer_Management_App.Data;
using System.Data.Entity;

namespace TruTexts_Customer_Management_App
{
    /// <summary>
    /// Interaction logic for frmEmpCustomer.xaml
    /// </summary>
    public partial class frmEmpCustomer : Window
    {
        public frmEmpCustomer()
        {
            InitializeComponent();
            Reset();
        }

        #region Custom method

        private void Reset()
        {
            txtAddress.Clear();
            txtCellNumber.Clear();
            txtCustID.Clear();
            txtFirstName.Clear();
            txtSurname.Clear();
            lblError.Content = " ";
        }
        #endregion

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frmstaff staff = new frmstaff();
            staff.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            TruTexts_CustomersEntities1 _data = new TruTexts_CustomersEntities1();
            Customer model = new Customer();

            if (string.IsNullOrEmpty(txtCustID.Text))
            {
                lblError.Content = "Missing CustomerID";
            }
            else
            {
                try
                {
                    string SQLCommandstring = "Select * from [Customers] where [CustID] = '" + txtCustID.Text;

                    foreach (var item in _data.Customers.SqlQuery(SQLCommandstring))
                    {
                        model.PhysicalAddress = txtAddress.Text;
                        model.CellNumber = txtCellNumber.Text;
                        model.CustID = Convert.ToInt32(txtCustID.Text);
                        model.FirstName = txtFirstName.Text;
                        model.Surname = txtSurname.Text;
                    }
                    txtAddress.Text = model.PhysicalAddress;
                    txtCellNumber.Text = model.CellNumber;
                    txtCustID.Text = Convert.ToString(model.CustID);
                    txtFirstName.Text = model.FirstName;
                    txtSurname.Text = model.Surname;

                }
                catch (Exception)
                {
                    lblError.Content = "An error has occured";
                }
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
    }
}
