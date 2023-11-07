using Examen_Advanced_zenodesp.Models;
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

namespace Examen_Advanced_zenodesp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(tbPassword.Password == "" || tbUsername.Text == "")
            {
                App.message = "Please fill in all the fields";
                new popup().Show();
            } else
            {
                User? user = null;
                try
                {
                    user = App.context.Users.First(c => c.Username == tbUsername.Text && c.Password == tbPassword.Password);
                }
                catch
                {
                    App.message = "Login attempt failed!";
                    new popup().Show();
                    this.Close();
                }
                if(user != null)
                {
                    //copilot generated this code
                    App.mainwindow.signoffitem.Visibility = Visibility.Visible;
                    App.mainwindow.employeePanel.Visibility = Visibility.Visible;
                    App.mainwindow.CompAppPanel.Visibility = Visibility.Visible;
                    App.mainwindow.signonitem.Visibility = Visibility.Collapsed;
                    App.mainwindow.registeritem.Visibility = Visibility.Collapsed;
                    App.mainwindow.loggedinitem.Visibility = Visibility.Visible;
                    App.mainwindow.loggedinitem.Header = "Logged in as " + user.Name;
                    this.Close();
                }
                
            }
        }
    }
}
