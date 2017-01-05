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
    /// Interaction logic for frmCustomers.xaml
    /// </summary>
    public partial class frmCustomers : Window
    {
        public frmCustomers()
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
            frmManagement manage = new frmManagement();
            manage.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            TruTexts_CustomersEntities1 _data = new TruTexts_CustomersEntities1();
            Customer model = new Customer();

            if (model == null)
            {
                txtAddress.Text = model.PhysicalAddress;
                txtCellNumber.Text = model.CellNumber;
                txtCustID.Text = Convert.ToString(model.CustID);
                txtFirstName.Text = model.FirstName;
                txtSurname.Text = model.Surname;
            }
            model.PhysicalAddress = txtAddress.Text;
            model.CellNumber = txtCellNumber.Text;
            model.CustID = Convert.ToInt32(txtCustID.Text);
            model.FirstName = txtFirstName.Text;
            model.Surname = txtSurname.Text;

            _data.Entry(model).State = EntityState.Deleted;
            _data.SaveChanges();

            Reset();
            MessageBox.Show("Data has been deleted.");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            TruTexts_CustomersEntities1 _data = new TruTexts_CustomersEntities1();
            Customer model = new Customer();

            if (string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(txtCellNumber.Text) ||
                string.IsNullOrEmpty(txtCustID.Text) ||
                string.IsNullOrEmpty(txtFirstName.Text) ||
                string.IsNullOrEmpty(txtSurname.Text))
            {
                lblError.Content = "Missing Values";
            }
            if (model == null)
            {
                txtAddress.Text = model.PhysicalAddress;
                txtCellNumber.Text = model.CellNumber;
                txtCustID.Text = Convert.ToString(model.CustID);
                txtFirstName.Text = model.FirstName;
                txtSurname.Text = model.Surname;
            }
            model.PhysicalAddress = txtAddress.Text;
            model.CellNumber = txtCellNumber.Text;
            model.CustID = Convert.ToInt32(txtCustID.Text);
            model.FirstName = txtFirstName.Text;
            model.Surname = txtSurname.Text;

            _data.Entry(model).State = EntityState.Modified;
            _data.SaveChanges();

            MessageBox.Show("data has been updated.");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TruTexts_CustomersEntities1 _data = new TruTexts_CustomersEntities1();
            Customer model = new Customer();

            try
            {
                string SQLCommandstring = "Insert into [Customers] values ( '" + txtFirstName.Text +
                    "', '" + txtSurname.Text + "', '" + txtAddress.Text + "', '"  + txtCellNumber.Text + "')";

                if (model == null)
                {
                    txtAddress.Text = model.PhysicalAddress;
                    txtCellNumber.Text = model.CellNumber;
                    txtCustID.Text = Convert.ToString(model.CustID);
                    txtFirstName.Text = model.FirstName;
                    txtSurname.Text = model.Surname;
                }
                model.PhysicalAddress = txtAddress.Text;
                model.CellNumber = txtCellNumber.Text;
                model.CustID = Convert.ToInt32(txtCustID.Text);
                model.FirstName = txtFirstName.Text;
                model.Surname = txtSurname.Text;

                _data.Entry(model).State = EntityState.Added;
                _data.SaveChanges();

                MessageBox.Show("Data has been added.");
            }
            catch (Exception)
            {
                Reset();
                lblError.Content = "An error has occured.";
            }
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
