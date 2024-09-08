using EmpolyeeSystem.DAl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.DAl.Repo.Abstraction
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
        Department GetById(int id);
        bool Edit(Department department);
        bool Create(Department department);
    }
}
