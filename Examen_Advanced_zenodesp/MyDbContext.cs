using Examen_Advanced_zenodesp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Advanced_zenodesp
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-LSB9S29\SQLEXPRESS;Database=Examen_Database;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true");

        }
    }
}
