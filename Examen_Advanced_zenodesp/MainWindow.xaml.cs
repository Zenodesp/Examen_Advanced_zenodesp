using Examen_Advanced_zenodesp.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Examen_Advanced_zenodesp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        List<Complaint> complaints = new List<Complaint>();
        List<Employee> employees = new List<Employee>();
        Employee selectedEmployee = null;
        Complaint selectedComplaint = null;
        MyDbContext context = new MyDbContext();

        public MainWindow()
        {
            Initialiser.InitialiseDatabase(context);
            InitializeComponent();

            //retrieve data from the database and display it in the listboxes, save for dummy entries with "-" as name or description

            employees = context.Employees.Where(c => c.Name != "-").ToList();
            lbEmployees.ItemsSource = employees;

            complaints = context.Complaints.Where(c => c.Description != "-").ToList();
            lbComplaints.ItemsSource = complaints;
        }

        private void TbEmployee_LostFocus(object sender, RoutedEventArgs e)
        {
            spDepartment.Visibility = Visibility.Visible;
        }

        private void btAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if(tbEmployeeDepartment.Text != "") 
            { 
                context.Add(new Employee
                {
                    Name = tbEmployee.Text,
                    Department = tbEmployeeDepartment.Text
                });
                context.SaveChanges();
                tbEmployee.Text = "";
                employees = context.Employees.Where(c => c.Name != "-").ToList();
                lbEmployees.ItemsSource = employees;
            }
        }

        



        private void lbEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spEmployee.Visibility = Visibility.Visible;
            spDescription.Visibility = Visibility.Visible;
            btAddComplaint.Visibility = Visibility.Visible;
            selectedEmployee = employees[lbEmployees.SelectedIndex];
            tbEmployee2.Text = selectedEmployee.Name;
        }

        private void btAddComplaint_Click(object sender, RoutedEventArgs e)
        {
            try { 

            if (selectedComplaint == null)
            {
                context.Add(new Complaint
                {
                    Date = DateTime.Now,
                    EmployeeId = selectedEmployee.Id,
                    Description = tbDescription.Text
                });

            }
            else
            {

                selectedComplaint.employee = selectedEmployee;
                selectedComplaint.Description = tbDescription.Text;
                context.Update(selectedComplaint);
            }
            context.SaveChanges();
            tbDescription.Text = "";
            complaints = context.Complaints.Where(c => c.Description != "-").ToList();
            lbComplaints.ItemsSource = complaints;
            }
            catch
            {
                tbMessage.Text = "A problem has occurred. Please retry or edit your input.";
            }
        }

        private void lbComplaints_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //display the description and employee name of the selected complaint in the textbox tbDescription
            selectedComplaint = complaints[lbComplaints.SelectedIndex];
            tbDescription.Text = selectedComplaint.Description;
            tbEmployee2.Text = selectedComplaint.employee.Name;
            

        }

        private void Shutdown_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            var Query = from E in context.Employees
                        from c in context.Complaints
                        where E.Name != "-" && c.Description != "-"
                        select new
                        {
                            Emp = E.Name,
                            Com = c.Description,
                            Date = c.Date
                        };
            LinqList.ItemsSource = Query.ToList();

        }
    }
}
