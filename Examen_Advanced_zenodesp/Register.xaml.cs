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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (tbPassword.Password == "" || tbUsername.Text == "" || tbName.Text == "") { 
                App.message = "Please fill in all the fields";
                new popup().Show();

            } else if (tbPassword.Password != tbConfirmPassword.Password)
            {
                App.message = "Passwords do not match";
                new popup().Show();
            } else
            {
                User? user = null;
                try
                {
                    //create a try catch block to check if the user already exists
                    user = App.context.Users.First(c => c.Username == tbUsername.Text);
                }
                catch
                {
                    if (user != null)
                    {
                        App.message = "User already exists";
                        new popup().Show();
                    }
                    else 
                    {
                        user = new User
                        {
                            Name = tbName.Text,
                            Username = tbUsername.Text,
                            Password = tbPassword.Password
                        };
                        App.context.Add(user);
                        App.context.SaveChanges();
                        App.message = "User created";
                        new popup().Show();
                        this.Close();
                    }

                }
            }
        }
    }
}
