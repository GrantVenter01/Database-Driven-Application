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

namespace TruTexts_Customer_Management_App
{
    /// <summary>
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
            Reset();
        }
        #region Custom method

        private void Reset()
        {
            txtUsername.Clear();
            pbxPassword.Clear();
            lblError.ClearValue(Label.ContentProperty);
            txtUsername.Focus();
        }

        #endregion

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            TruTexts_CustomersEntities1 _data = new TruTexts_CustomersEntities1();

            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) ||
                    string.IsNullOrEmpty(pbxPassword.Password))
                {
                    lblError.Content = "Missing Username or password";
                }
                else
                {
                    Login model = new Login();
                    string SQLCommandstring = "Select * from [Login] where [Username] = '"
                        + txtUsername.Text + "' and [Password] = '" + pbxPassword.Password + "'";

                    foreach (var item in _data.Logins.SqlQuery(SQLCommandstring).ToList())
                    {
                        model.Username = item.Username;
                        model.Password = item.Password;
                        model.Role = item.Role;
                        model.FirstName = item.FirstName;
                    }
                    if (string.IsNullOrEmpty(model.Username))
                    {
                        Reset();
                        lblError.Content = "Error: No user found.";
                    }
                    else if (model.Username == txtUsername.Text && model.Password == pbxPassword.Password)
                    {
                        if (model.Role == "Administrator")
                        {
                            Reset();
                            MessageBox.Show(model.FirstName+ ", You are about to log in as an Administrator.");
                            frmManagement manage = new frmManagement();
                            manage.Show();
                            this.Close();
                        }
                        else if(model.Role == "User")
                        {
                            Reset();
                            MessageBox.Show(model.FirstName+ ", You are about to log in as a user.");
                            frmstaff staff = new frmstaff();
                            staff.Show();
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                lblError.Content = "an error has occured, please try again";
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
    }
}
