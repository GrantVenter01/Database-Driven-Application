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
    /// Interaction logic for frmEmployees.xaml
    /// </summary>
    public partial class frmEmployees : Window
    {
        public frmEmployees()
        {
            InitializeComponent();
            Reset();
        }

        #region Custom method
        private void Reset()
        {
            txtCustID.Clear();
            txtCellNumber.Clear();
            txtFirstName.Clear();
            txtIDNumber.Clear();
            txtPassword.Clear();
            txtAddress.Clear();
            txtSurname.Clear();
            txtUsername.Clear();
            lblError.Content = "";
        }
        TruTexts_CustomersEntities1 _data;
        Employee model;
        #endregion

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frmManagement manage = new frmManagement();
            manage.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _data = new TruTexts_CustomersEntities1();
            model = new Employee();

            if (model == null)
            {
                txtCellNumber.Text = model.CellNumber;
                txtCustID.Text = Convert.ToString(model.EmpID);
                txtFirstName.Text = model.FirstName;
                txtIDNumber.Text = model.IDNumber;
                txtPassword.Text = model.Password;
                txtSurname.Text = model.Surname;
                txtUsername.Text = model.Username;
            }
            model.CellNumber = txtCellNumber.Text;
            model.EmpID = Convert.ToInt32(txtCustID.Text);
            model.IDNumber = txtIDNumber.Text;
            model.FirstName = txtFirstName.Text;
            model.Password = txtPassword.Text;
            model.Surname = txtSurname.Text;
            model.Username = txtUsername.Text;

            _data.Entry(model).State = EntityState.Deleted;
            _data.SaveChanges();
            MessageBox.Show("Data has been deleted.");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            _data = new TruTexts_CustomersEntities1();
            model = new Employee();

            if (string.IsNullOrEmpty(txtCellNumber.Text) ||
    string.IsNullOrEmpty(txtCustID.Text) ||
    string.IsNullOrEmpty(txtFirstName.Text) ||
    string.IsNullOrEmpty(txtIDNumber.Text) ||
    string.IsNullOrEmpty(txtPassword.Text) ||
    string.IsNullOrEmpty(txtAddress.Text) ||
    string.IsNullOrEmpty(txtSurname.Text) ||
    string.IsNullOrEmpty(txtUsername.Text))
            {
                lblError.Content = "Missing values";
            }

            if (model == null)
            {
                txtCellNumber.Text = model.CellNumber;
                txtCustID.Text = Convert.ToString(model.EmpID);
                txtFirstName.Text = model.FirstName;
                txtIDNumber.Text = model.IDNumber;
                txtPassword.Text = model.Password;
                txtSurname.Text = model.Surname;
                txtUsername.Text = model.Username;
            }
            model.CellNumber = txtCellNumber.Text;
            model.EmpID = Convert.ToInt32(txtCustID.Text);
            model.IDNumber = txtIDNumber.Text;
            model.FirstName = txtFirstName.Text;
            model.Password = txtPassword.Text;
            model.Surname = txtSurname.Text;
            model.Username = txtUsername.Text;

            _data.Entry(model).State = EntityState.Modified;
            _data.SaveChanges();
            MessageBox.Show("Data has been Updated.");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _data = new TruTexts_CustomersEntities1();
            model = new Employee();

            try
            {
                string SQLComandstring = "Insert into [Employees] values('" + txtFirstName.Text +
                    "', '" + txtSurname.Text + "','" + txtAddress.Text +"','" + txtIDNumber.Text + "','" + txtCellNumber.Text +
                    "','" + txtUsername.Text + "','" + txtPassword.Text + "')";

                if (model == null)
                {
                    txtCellNumber.Text = model.CellNumber;
                    txtCustID.Text = Convert.ToString(model.EmpID);
                    txtFirstName.Text = model.FirstName;
                    txtIDNumber.Text = model.IDNumber;
                    txtPassword.Text = model.Password;
                    txtSurname.Text = model.Surname;
                    txtUsername.Text = model.Username;
                }
                model.CellNumber = txtCellNumber.Text;
                model.EmpID = Convert.ToInt32(txtCustID.Text);
                model.IDNumber = txtIDNumber.Text;
                model.FirstName = txtFirstName.Text;
                model.Password = txtPassword.Text;
                model.Surname = txtSurname.Text;
                model.Username = txtUsername.Text;

                _data.Entry(model).State = EntityState.Added;
                _data.SaveChanges();
                MessageBox.Show("Data has been added.");
            }

            catch (Exception)
            {
                lblError.Content = "An error has occured.";
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            _data = new TruTexts_CustomersEntities1();
            model = new Employee();

            if (string.IsNullOrEmpty(txtCustID.Text))
            {
                lblError.Content = "Error: missing EmployeeID.";
            }
            else
            {
                try
                {
                    string SQLCommandstring = "Select * from [Employees] where [EmpID] = '" + txtCustID.Text;

                    foreach (var item in _data.Employees.SqlQuery(SQLCommandstring))
                    {
                        model.EmpID = item.EmpID;
                        model.FirstName = item.FirstName;
                        model.Surname = item.Surname;
                        model.IDNumber = item.IDNumber;
                        model.CellNumber = item.CellNumber;
                        model.Username = item.Username;
                        model.Password = item.Password;
                    }
                    txtCustID.Text = Convert.ToString(model.EmpID);
                    txtCellNumber.Text = model.CellNumber;
                    txtFirstName.Text = model.FirstName;
                    txtIDNumber.Text = model.IDNumber;
                    txtPassword.Text = model.Password;
                    txtSurname.Text = model.Surname;
                    txtUsername.Text = model.Username;
                }
                catch (Exception)
                {
                    Reset();
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
