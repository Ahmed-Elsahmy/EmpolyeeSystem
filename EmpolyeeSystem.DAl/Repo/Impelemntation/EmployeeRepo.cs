using EmpolyeeSystem.DAl.DB;
using EmpolyeeSystem.DAl.Entities;
using EmpolyeeSystem.DAl.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.DAl.Repo.Impelemntation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly AppDbContext _appDbContext = new AppDbContext();
        public bool Create(Employee empolyee)
        {
            try
            {
                _appDbContext.Employees.Add(empolyee);
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Employee empolyee)
        {
            try
            {
                var data = _appDbContext.Employees.Where(a => a.id == empolyee.id).FirstOrDefault();
                data.IsDeleted = !data.IsDeleted;
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Employee empolyee)
        {
            try
            {
                var data = _appDbContext.Employees.Where(a => a.id == empolyee.id).FirstOrDefault();
                data.Name = empolyee.Name;
                data.Age = empolyee.Age;
                data.Salary = empolyee.Salary;
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public IQueryable<Employee> GetAll()
        {
            return _appDbContext.Employees.Include(a => a.Department).Where(a => a.DeptId != null);
        }

        public Employee GetById(int id)
        {
            var result = _appDbContext.Employees.Where(a => a.id == id).FirstOrDefault();
            return result;
        }

    }
}
