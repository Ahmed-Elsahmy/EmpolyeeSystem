using EmpolyeeSystem.DAl.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.DAl.DB
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> departments { get; set; }
        public  DbSet<User> users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {
        }
    }
}
