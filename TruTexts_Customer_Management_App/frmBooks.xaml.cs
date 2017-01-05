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
    /// Interaction logic for frmBooks.xaml
    /// </summary>
    public partial class frmBooks : Window
    {
        public frmBooks()
        {
            InitializeComponent();
            Reset();
        }

        #region Custom method
        private void Reset()
        {
            txtAuthorName.Clear();
            txtAuthorSurname.Clear();
            txtBookID.Clear();
            txtQuantity.Clear();
            txtTitle.Clear();
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
            Book model = new Book();

            if (model == null)
            {
                txtBookID.Text = Convert.ToString(model.BookID);
                txtTitle.Text = model.Title;
                txtAuthorSurname.Text = model.AuthorSurname;
                txtAuthorName.Text = model.AuthorName;
                txtQuantity.Text = Convert.ToString(model.Quantity);
            }
            model.BookID = Convert.ToInt32(txtBookID.Text);
            model.Title = txtTitle.Text;
            model.AuthorSurname = txtAuthorSurname.Text;
            model.AuthorName = txtAuthorName.Text;
            model.Quantity = Convert.ToInt32(txtQuantity.Text);

            _data.Entry(model).State = EntityState.Deleted;
            _data.SaveChanges();

            MessageBox.Show("Data has been deleted.");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            TruTexts_CustomersEntities1 _data = new TruTexts_CustomersEntities1();
            Book model = new Book();

            if (string.IsNullOrEmpty(txtAuthorName.Text) ||
                string.IsNullOrEmpty(txtAuthorSurname.Text) ||
                string.IsNullOrEmpty(txtBookID.Text) ||
                string.IsNullOrEmpty(txtQuantity.Text) ||
                string.IsNullOrEmpty(txtTitle.Text))
            {
                lblError.Content = "Error: Missing Values";
            }
            if (model == null)
            {
                txtBookID.Text = Convert.ToString(model.BookID);
                txtTitle.Text = model.Title;
                txtAuthorSurname.Text = model.AuthorSurname;
                txtAuthorName.Text = model.AuthorName;
                txtQuantity.Text = Convert.ToString(model.Quantity);
            }
            model.BookID = Convert.ToInt32(txtBookID.Text);
            model.Title = txtTitle.Text;
            model.AuthorSurname = txtAuthorSurname.Text;
            model.AuthorName = txtAuthorName.Text;
            model.Quantity = Convert.ToInt32(txtQuantity.Text);

            _data.Entry(model).State = EntityState.Added;
            _data.SaveChanges();

            MessageBox.Show("Data has been added.");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TruTexts_CustomersEntities1 _data = new TruTexts_CustomersEntities1();
            Book model = new Book();

            try
            {
                string SQLCommandstring = "Insert into [Books] Values ( ' " + txtTitle.Text + " ' , ' "
                    + txtAuthorSurname.Text + " ' , ' " + txtAuthorName.Text +
                    " ' , " + txtQuantity.Text +  " ' )";

                if (model == null)
                {
                    txtBookID.Text = Convert.ToString(model.BookID);
                    txtTitle.Text = model.Title;
                    txtAuthorSurname.Text = model.AuthorSurname;
                    txtAuthorName.Text = model.AuthorName;
                    txtQuantity.Text = Convert.ToString(model.Quantity);
                }
                model.BookID = Convert.ToInt32(txtBookID.Text);
                model.Title = txtTitle.Text;
                model.AuthorSurname = txtAuthorSurname.Text;
                model.AuthorName = txtAuthorName.Text;
                model.Quantity = Convert.ToInt32(txtQuantity.Text);

                _data.Entry(model).State = EntityState.Added;
                _data.SaveChanges();

                MessageBox.Show("Data has been updated.");
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
            Book model = new Book();

            if (string.IsNullOrEmpty(txtBookID.Text))
            {
                MessageBox.Show("Missing BookID, Please enter Id to search!");
            }
            else
            {
                try
                {
                    string SQLCommandstring = "Select * from [Books] where [BookID] = " + txtBookID.Text;

                    foreach (var item in _data.Books.SqlQuery(SQLCommandstring))
                    {
                        model.BookID = item.BookID;
                        model.Title = item.Title;
                        model.AuthorSurname = item.AuthorSurname;
                        model.AuthorName = item.AuthorName;
                        model.Quantity = item.Quantity;
                    }
                    txtBookID.Text = Convert.ToString(model.BookID);
                    txtTitle.Text = model.Title;
                    txtAuthorSurname.Text = model.AuthorSurname;
                    txtAuthorName.Text = model.AuthorName;
                    txtQuantity.Text = Convert.ToString(model.Quantity);

                }
                catch (Exception)
                {
                    lblError.Content = "An error occured!";
                }
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
    }
}
