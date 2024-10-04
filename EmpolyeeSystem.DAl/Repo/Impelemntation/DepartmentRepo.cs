using EmpolyeeSystem.DAl.DB;
using EmpolyeeSystem.DAl.Entities;
using EmpolyeeSystem.DAl.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.DAl.Repo.Impelemntation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool Create(Department department)
        {
            try
            {
                _appDbContext.departments.Add(department);
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Department department)
        {
            try
            {
                var data = _appDbContext.departments.Where(a => a.id == department.id).FirstOrDefault();
                data.Name = department.Name;
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<Department> GetAll()
        {
            return _appDbContext.departments.ToList();
        }

        public Department GetById(int id)
        {
            var result = _appDbContext.departments.Where(a => a.id == id).FirstOrDefault();
            return result;
        }
    }
}
