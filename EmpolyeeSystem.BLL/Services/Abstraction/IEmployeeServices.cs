using EmpolyeeSystem.BLL.ModelVM.EmpolyeeVM;
using EmpolyeeSystem.DAl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.BLL.Services.Abstraction
{
    public interface IEmployeeServices
    {
        public List<GetallEmpVM> Getall();
         bool Create(CreateEmpVM emp);
        Employee GetByid(int id);
        bool Edit(EditEmpVM emp);
    }
}
