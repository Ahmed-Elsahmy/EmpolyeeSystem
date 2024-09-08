using EmpolyeeSystem.DAl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.DAl.Repo.Abstraction
{
    public interface IEmployeeRepo
    {
        IQueryable<Employee> GetAll();
        Employee GetById(int id);
        bool Edit(Employee empolyee);
        bool Create(Employee empolyee);
        bool Delete(Employee empolyee);
    }
}
