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
using System.Windows.Threading;

namespace TruTexts_Customer_Management_App
{
    /// <summary>
    /// Interaction logic for frmSplashScreen.xaml
    /// </summary>
    public partial class frmSplashScreen : Window
    {
        DispatcherTimer _Timer;
        public frmSplashScreen()
        {
            InitializeComponent();
            _Timer = new DispatcherTimer();
            _Timer.Tick += new EventHandler(Progress);
            _Timer.Interval = TimeSpan.FromMilliseconds(70);
            _Timer.Start();
        }
             private void Progress(object sender, EventArgs e)
        {
            if (pgbTimer.Value == 70)
            {
                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
                _Timer.Stop();
            }
            else if (pgbTimer.Value < 70)
            {
                pgbTimer.Value++;
            }
        }
    }
}
