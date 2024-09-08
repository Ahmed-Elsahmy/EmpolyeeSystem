using EmpolyeeSystem.DAl.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.DAl.DB
{
    public class AppDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AGHBKJS;Database=EmployeeSystem;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");

        }
    }
}
