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
    /// Interaction logic for frmEmpOrder.xaml
    /// </summary>
    public partial class frmEmpOrder : Window
    {
        public frmEmpOrder()
        {
            InitializeComponent();
            Reset();
        }

        #region Custom method
        private void Reset()
        {
            txtBookID.Clear();
            txtCustID.Clear();
            txtOrderID.Clear();
            txtQty.Clear();
            txtTimestamp.Clear();
            lblError.Content = "";
        }
        TruTexts_CustomersEntities1 _data;
        Order model;
        #endregion 

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frmstaff staff = new frmstaff();
            staff.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _data = new TruTexts_CustomersEntities1();
            model = new Order();

            if (model == null)
            {
                txtOrderID.Text = Convert.ToString(model.OrderID);
                txtBookID.Text = Convert.ToString(model.BookID);
                txtCustID.Text = Convert.ToString(model.CustomerID);
                txtQty.Text = Convert.ToString(model.Quantity);
                txtTimestamp.Text = Convert.ToString(model.Timestamp);
            }
            model.BookID = Convert.ToInt32(model.BookID);
            model.CustomerID = Convert.ToInt32(model.CustomerID);
            model.OrderID = Convert.ToInt32(model.Quantity);
            model.Quantity = Convert.ToInt32(model.Quantity);
            model.Timestamp = Convert.ToDateTime(model.Timestamp);

            _data.Entry(model).State = EntityState.Deleted;
            _data.SaveChanges();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            _data = new TruTexts_CustomersEntities1();
            model = new Order();

            string SQLCommandstring = " Insert into [Orders] values('" + txtBookID.Text +
                "','" + txtTimestamp.Text +
                "','" + txtQty.Text +
                "','" + txtCustID.Text + "')";

            if (model == null)
            {
                txtOrderID.Text = Convert.ToString(model.OrderID);
                txtBookID.Text = Convert.ToString(model.BookID);
                txtCustID.Text = Convert.ToString(model.CustomerID);
                txtQty.Text = Convert.ToString(model.Quantity);
                txtTimestamp.Text = Convert.ToString(model.Timestamp);
            }
            model.BookID = Convert.ToInt32(model.BookID);
            model.CustomerID = Convert.ToInt32(model.CustomerID);
            model.OrderID = Convert.ToInt32(model.Quantity);
            model.Quantity = Convert.ToInt32(model.Quantity);
            model.Timestamp = Convert.ToDateTime(model.Timestamp);

            _data.Entry(model).State = EntityState.Modified;
            _data.SaveChanges();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _data = new TruTexts_CustomersEntities1();
            model = new Order();

            if (string.IsNullOrEmpty(txtBookID.Text) ||
                string.IsNullOrEmpty(txtCustID.Text) ||
                string.IsNullOrEmpty(txtOrderID.Text) ||
                string.IsNullOrEmpty(txtQty.Text) ||
                string.IsNullOrEmpty(txtTimestamp.Text))
            {
                Reset();
                lblError.Content = "Missing Values.";
            }
            if (model == null)
            {
                txtOrderID.Text = Convert.ToString(model.OrderID);
                txtBookID.Text = Convert.ToString(model.BookID);
                txtCustID.Text = Convert.ToString(model.CustomerID);
                txtQty.Text = Convert.ToString(model.Quantity);
                txtTimestamp.Text = Convert.ToString(model.Timestamp);
            }
            model.BookID = Convert.ToInt32(model.BookID);
            model.CustomerID = Convert.ToInt32(model.CustomerID);
            model.OrderID = Convert.ToInt32(model.Quantity);
            model.Quantity = Convert.ToInt32(model.Quantity);
            model.Timestamp = Convert.ToDateTime(model.Timestamp);

            _data.Entry(model).State = EntityState.Added;
            _data.SaveChanges();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            _data = new TruTexts_CustomersEntities1();
            model = new Order();

            if (string.IsNullOrEmpty(txtOrderID.Text))
            {
                Reset();
                lblError.Content = "Error: missing OrderID.";
            }
            else
            {
                try
                {
                    string SQLCommandstring = "Select * from [Orders] where [OrderID] = '" + txtOrderID.Text;

                    foreach (var item in _data.Orders.SqlQuery(SQLCommandstring))
                    {
                        model.BookID = item.BookID;
                        model.Book = item.Book;
                        model.Customer = item.Customer;
                        model.CustomerID = item.CustomerID;
                        model.OrderID = item.OrderID;
                        model.Quantity = item.Quantity;
                        model.Timestamp = item.Timestamp;
                    }
                    txtOrderID.Text = Convert.ToString(model.OrderID);
                    txtBookID.Text = Convert.ToString(model.BookID);
                    txtCustID.Text = Convert.ToString(model.CustomerID);
                    txtQty.Text = Convert.ToString(model.Quantity);
                    txtTimestamp.Text = Convert.ToString(model.Timestamp);
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
