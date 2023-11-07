using Examen_Advanced_zenodesp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Advanced_zenodesp.Data
{
    internal class Initialiser
    {

        public static void InitialiseDatabase(MyDbContext context)
        {
            if(!context.Employees.Any())
            {
                context.Add(new Employee
                {
                    Name = "-",
                    Department = "-"
                });
                context.SaveChanges();
            }

            Employee DummyEmployee = context.Employees.First(c => c.Name == "-");

            if (!context.Complaints.Any())
            {
                context.Add(new Complaint
                {
                    Date = DateTime.Now,
                    EmployeeId = DummyEmployee.Id,
                    Description = "-"
                });
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Add(new User
                {
                    //CoPilot
                    Name= "-",
                    Username = "-",
                    Password = "-"
                });
                context.SaveChanges();
            }
        }
    }
}
