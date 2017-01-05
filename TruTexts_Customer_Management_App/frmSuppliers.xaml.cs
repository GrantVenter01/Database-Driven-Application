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
    /// Interaction logic for frmSuppliers.xaml
    /// </summary>
    public partial class frmSuppliers : Window
    {
        public frmSuppliers()
        {
            InitializeComponent();
            Reset();
        }

        #region Custom method

        private void Reset()
        {
            txtAddress.Clear();
            txtName.Clear();
            txtNumber.Clear();
            txtSuppID.Clear();
            lblError.Content = "";
        }

        TruTexts_CustomersEntities1 _data;
        Supplier model;
        #endregion

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            _data = new TruTexts_CustomersEntities1();
            model = new Supplier();

            if (string.IsNullOrEmpty(txtSuppID.Text))
            {
                lblError.Content = "Error: Missing Supplier ID.";
            }
            else
            {
                try
                {
                    string SQLCommandstring = " Select * from [Suppliers] where [SuppID] = " + txtSuppID.Text;

                    foreach (var item in _data.Suppliers.SqlQuery(SQLCommandstring))
                    {
                        model.SuppID = item.SuppID;
                        model.SuppliersName = item.SuppliersName;
                        model.CellNumber = item.CellNumber;
                        model.Address = item.Address;
                    }
                    txtAddress.Text = model.Address;
                    txtName.Text = model.SuppliersName;
                    txtNumber.Text = model.CellNumber;
                    txtSuppID.Text = Convert.ToString(model.SuppID);
                }
                catch (Exception)
                {
                    Reset();
                    lblError.Content = "An error has occured";
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frmManagement manage = new frmManagement();
            manage.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _data = new TruTexts_CustomersEntities1();
            model = new Supplier();
            Reset();

            if (model == null)
            {
                txtAddress.Text = model.Address;
                txtName.Text = model.SuppliersName;
                txtNumber.Text = model.CellNumber;
                txtSuppID.Text = Convert.ToString(model.SuppID);
            }
            model.Address = txtAddress.Text;
            model.SuppliersName = txtName.Text;
            model.CellNumber = txtNumber.Text;
            model.SuppID = Convert.ToInt32(txtSuppID.Text);

            _data.Entry(model).State = EntityState.Deleted;
            _data.SaveChanges();
            MessageBox.Show("Data has been deleted.");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            _data = new TruTexts_CustomersEntities1();
            model = new Supplier();

            if (string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtNumber.Text) ||
                string.IsNullOrEmpty(txtSuppID.Text))
            {
                Reset();
                lblError.Content = "Missing Values.";
            }
            else if (model == null)
            {
                txtAddress.Text = model.Address;
                txtName.Text = model.SuppliersName;
                txtNumber.Text = model.CellNumber;
                txtSuppID.Text = Convert.ToString(model.SuppID);
            }
            model.Address = txtAddress.Text;
            model.SuppliersName = txtName.Text;
            model.CellNumber = txtNumber.Text;
            model.SuppID = Convert.ToInt32(txtSuppID.Text);

            _data.Entry(model).State = EntityState.Modified;
            _data.SaveChanges();
            MessageBox.Show("Data has been updated.");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _data = new TruTexts_CustomersEntities1();
            model = new Supplier();

            try
            {
                string SQLCommandstring = "Insert * into [Suppliers] values ('" + txtName.Text +
                    "','" + txtNumber.Text +
                    "','" + txtAddress.Text + "')";

                if (model == null)
                {
                    txtAddress.Text = model.Address;
                    txtName.Text = model.SuppliersName;
                    txtNumber.Text = model.CellNumber;
                    txtSuppID.Text = Convert.ToString(model.SuppID);
                }
                model.Address = txtAddress.Text;
                model.SuppliersName = txtName.Text;
                model.CellNumber = txtNumber.Text;
                model.SuppID = Convert.ToInt32(txtSuppID.Text);

                _data.Entry(model).State = EntityState.Added;
                _data.SaveChanges();
                MessageBox.Show("Data has been added.");
            }
            catch (Exception)
            {
                Reset();
                lblError.Content = "An error has occured";
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
    }
}
